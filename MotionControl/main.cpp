#include <iostream>
#include <chrono>
#include <thread>
#include <future>
#include <vector>
#include <string>

#include "DataTypes.hpp"
#include "MotorHandler.hpp"
#include "OutputHandler.hpp"
#include "InputHandler.hpp"
#include "Module.hpp"
#include "AutoCycle.hpp"
#include "MMFHandler.hpp"

#include "easylogging++.h"
INITIALIZE_EASYLOGGINGPP

using std::cout;
using std::endl;
using namespace std::chrono;

//----------------------------------------------------------------------------
// Need to run HMI first before run this program or otherwise there will be error
// The HMI will automatically open this program so just need to open HMI
// 
// The log file can be found in the log folder located at the same folder with the HMI.exe
//----------------------------------------------------------------------------

// initialize shared memory
//HANDLE MotorIOMMF = CreateFileMappingW(INVALID_HANDLE_VALUE, NULL, PAGE_READWRITE, 0, 1024, L"MotorIOFileMap");
//MotorIOStruct* MotorIOData = (MotorIOStruct*)MapViewOfFile(MotorIOMMF, FILE_MAP_ALL_ACCESS, 0, 0, 0);
//
//HANDLE CmdMMF = CreateFileMappingW(INVALID_HANDLE_VALUE, NULL, PAGE_READWRITE, 0, 1024, L"CmdFileMap");
//CmdStruct* CmdData = (CmdStruct*)MapViewOfFile(CmdMMF, FILE_MAP_ALL_ACCESS, 0, 0, 0);

//----------------------------------------------------------------------------
// Initialize shared memory
//----------------------------------------------------------------------------
MMFHandler<MotorIOStruct> MotorIOMMF("MotorIOFileMap", L"MotorIOMut");
MMFHandler<CmdStruct> CmdMMF("CmdFileMap", L"MotorIOMut");
MotorIOStruct* MotorIOData = new MotorIOStruct;
CmdStruct* CmdData = new CmdStruct;

int main() {

    // check shared memory size
    //cout << sizeof(MotorIOStruct) << endl;
    //cout << sizeof(CmdStruct) << endl;

    //----------------------------------------------------------------------------
    // Initialize max number of motor and IO
    //----------------------------------------------------------------------------
    MotorIOMMF.ReadRelease(MotorIOData);
    const int MotorCount = MotorIOData->MotorCount; // determined by HMI init code
    const int InChCount = MotorIOData->InChCount; // determined by HMI init code
    const int OutChCount = MotorIOData->OutChCount; // determined by number of axis in .ini file (the MHI read the .ini file)

    //----------------------------------------------------------------------------
    // Initialize logger
    //----------------------------------------------------------------------------
    string log_conf_path = "..\\..\\..\\..\\settings\\log_config.conf";
    el::Configurations conf(log_conf_path);
    
    el::Logger* MainLog = el::Loggers::getLogger("Main");
    el::Loggers::reconfigureAllLoggers(conf);

    //----------------------------------------------------------------------------
    // Initialize WMX library and its obbject
    //----------------------------------------------------------------------------
    
    // initialize WMXlib obj
    WMX3Api wmxlib;
    CoreMotionStatus st;
    CoreMotion wmxlib_cm(&wmxlib);
    Config::SystemParam param;

    // Initilize WMX lib: create device and start communication
    MainLog->info("Starting application...");
    wmxlib.CreateDevice(_T("C:\\Program Files\\SoftServo\\WMX3"), DeviceType::DeviceTypeNormal);
    wmxlib.StartCommunication(5000); // Wait up to 5 seconds for communication to start
    MainLog->info("WXM lib initialized");

    // make MotorHandler obj
    std::vector<MotorHandler*> Motors; // using vector because cannot make an array of object with constructor with for loop
    Motors.reserve(MotorCount);
    for (int i = 0; i < MotorCount; i++) {
        Motors.push_back(new MotorHandler(&wmxlib, i));
        Motors[i]->SetInPosWidth(0);
        Motors[i]->SetServoOn();
    }

    // make InputHandle and Output Handler
    InputHandler Input(&wmxlib, InChCount); // maximum channel = 10
    OutputHandler Output(&wmxlib, OutChCount); // maximum channel = 10

    // define AutoCycle Components
    MotorHandler* AxisX = Motors[0];
    MotorHandler* AxisY = Motors[1];
    MotorHandler* AxisZ = Motors[2];
    Module* Mod = new Module(AxisX, AxisY, AxisZ);
    AutoCycle* Auto = new AutoCycle(Mod, AxisX, AxisY, AxisZ, &CmdMMF);

    // reconfigure logger for motor, DIO, module, and autocycle
    el::Loggers::reconfigureAllLoggers(conf);

    //----------------------------------------------------------------------------
    // Start monitoring and executing CMD
    //----------------------------------------------------------------------------
    // Loop until the HMI is closed
    CmdMMF.ReadRelease(CmdData);
    while (!CmdData->is_closed) {
        // debug code here
        /*
        //double ACPosX[3] = { 10000, 20000, 30000 };
        //double ACPosY[3] = { 10000, 20000, 30000 };
        //double ACPosZ[3] = { 100, 10000 };
        //AC.Floor1(ACPosX, ACPosY, ACPosZ);
        //printf("");



        
        unsigned char  inData[constants::maxIoInSize];
        unsigned char  outData[constants::maxIoOutSize];

        for (int i = 0; i < 8000; i++)
        {
            outData[i] = 0xFF;
        }


        // MAX_INPUT_BUFF_SIZE  Byte Get Input  Memory Read
        printf("MAX_OUTPUT_BUFF_SIZE Byte Get Output Memory Read\n");
        wxmlib_io.GetOutBytes(0x00, 2, &outData[0]);

        unsigned char data = 16;
        wxmlib_io.SetOutByte(0x01, 1);

        wxmlib_io.GetOutBytes(0x00, 2, &outData[0]);

        printf("");
        */

        //----------------------------------------------------------------------------
        // Get the motor and I/O status and update the shared memory
        //----------------------------------------------------------------------------
        // get all the motor status and update the shared memory
        wmxlib_cm.GetStatus(&st);
        MotorIOMMF.ReadLock(MotorIOData);
        for (int i = 0; i < 5; i++) {
            MotorIOData->Motor[i].SVON = st.axesStatus[i].servoOn;
            MotorIOData->Motor[i].pos = st.axesStatus[i].actualPos;
            MotorIOData->Motor[i].vel = st.axesStatus[i].actualVelocity;
            MotorIOData->Motor[i].alarm = st.axesStatus[i].ampAlarmCode;
            MotorIOData->Motor[i].limit_max = st.axesStatus[i].positiveSoftLimit;
            MotorIOData->Motor[i].limit_min = st.axesStatus[i].negativeSoftLimit;
        }
        MotorIOMMF.Write(MotorIOData);

        // get I/O and update the shared memory
        for (int i = 0; i < sizeof(MotorIOData->DIch); i++) {
            MotorIOMMF.ReadLock(MotorIOData);
            Input.GetInputChannel(i, &MotorIOData->DIch[i]);
            MotorIOMMF.Write(MotorIOData);
        }

        for (int i = 0; i < sizeof(MotorIOData->DOch); i++) {
            MotorIOMMF.ReadLock(MotorIOData);
            Output.GetOutputChannel(i, &MotorIOData->DOch[i]);
            MotorIOMMF.Write(MotorIOData);
        }

        //----------------------------------------------------------------------------
        // Read command from HMI
        //----------------------------------------------------------------------------
        CmdMMF.ReadLock(CmdData); 
        if (CmdData->COMMAND == COMMAND_SVON) {
            CmdData->COMMAND = 0;
            CmdMMF.Write(CmdData);
            Motors[CmdData->axis]->SetServoOn();
        }
        else if (CmdData->COMMAND == COMMAND_SVOFF) {
            CmdData->COMMAND = 0;
            CmdMMF.Write(CmdData);
            Motors[CmdData->axis]->SetServoOff();
        }
        else if (CmdData->COMMAND == COMMAND_ALARM_RESET) {
            CmdData->COMMAND = 0;
            CmdMMF.Write(CmdData);
            for (int i = 0; i < MotorCount; i++) Motors[i]->AlarmReset();
            MainLog->info("Reset Alarm all motor");
        }
        else if (CmdData->COMMAND == COMMAND_MOVE_ABS) {
            CmdData->COMMAND = 0;
            CmdMMF.Write(CmdData);
            Motors[CmdData->axis]->MoveAbs(ProfileType::Trapezoidal, CmdData->ComVel, 10000, 10000, CmdData->ComPos);
        }
        else if (CmdData->COMMAND == COMMAND_MOVE_REL) {
            CmdData->COMMAND = 0;
            CmdMMF.Write(CmdData);
            Motors[CmdData->axis]->MoveRel(ProfileType::Trapezoidal, CmdData->ComVel, 10000, 10000, CmdData->ComPos);
        }
        else if (CmdData->COMMAND == COMMAND_STOP) {
            CmdData->COMMAND = 0;
            CmdMMF.Write(CmdData);
            Motors[CmdData->axis]->Stop();
        }
        else if (CmdData->COMMAND == COMMAND_SET_OUTPUT) {
            CmdData->COMMAND = 0;
            CmdMMF.Write(CmdData);
            Output.SetOutputBit(CmdData->OutCh, CmdData->OutBit, CmdData->OutValue);
        }
        else if (CmdData->COMMAND == COMMAND_SET_OUTPUT_CH) {
            CmdData->COMMAND = 0;
            CmdMMF.Write(CmdData);
            Output.SetOutputChannel(CmdData->OutCh, CmdData->OutChValue);
        }
        // simulation for GetOutputChannelArray
        else if (CmdData->COMMAND == COMMAND_GET_OUTPUT_CH_ARRAY) {
            CmdData->COMMAND = 0;
            CmdMMF.Write(CmdData);
            WORD *word = new WORD[OutChCount * 2];
            Output.GetOutputChannelArray(CmdData->OutChArrStart, CmdData->OutChArrSize, word);

            for (int i = 0; i < CmdData->OutChArrSize; i++) {
                std::string chOutArr_buff = "Out Channel ";
                chOutArr_buff.append(std::to_string(CmdData->OutChArrStart + i));
                chOutArr_buff.append(" ");
                for (int j = 0; j != 8; j++) chOutArr_buff.append(std::to_string((word[i] & (1 << j)) != 0));
                chOutArr_buff.append(" ");
                for (int j = 8; j != 16; j++) chOutArr_buff.append(std::to_string((word[i] & (1 << j)) != 0));
                MainLog->info(chOutArr_buff);

                //cout << "Out Channel " << CmdData->OutChArrStart + i << " ";
                //for (int j = 0; j != 8; j++) cout << ((word[i] & (1 << j)) != 0);
                //cout << " ";
                //for (int j = 8; j != 16; j++) cout << ((word[i] & (1 << j)) != 0);
                //cout << endl;
            }
            delete[] word;
        }
        else {
            CmdMMF.Release();
        }

        //----------------------------------------------------------------------------
        // AutoCycle section
        //----------------------------------------------------------------------------
        CmdMMF.ReadLock(CmdData);
        Auto->ReadCommand(CmdData); // there is write CmdData inside (set cmd = 0)
        
        CmdMMF.ReadLock(CmdData);
        CmdData->ACSTAT = Auto->CheckStatus();
        CmdMMF.Write(CmdData);



        std::this_thread::sleep_for(1ms); // give the HMI time to acquire the mutex. without this the program become unresponsive
        CmdMMF.ReadRelease(CmdData);
    };
    
    //----------------------------------------------------------------------------
    // Terminate comunication and close device
    //----------------------------------------------------------------------------
    //thread_AC.join();
    MainLog->info("Closing application...\n");
    wmxlib.StopCommunication();
    wmxlib.CloseDevice();

    printf("Press any key to exit.\n");
    getchar();

    return 0;
}