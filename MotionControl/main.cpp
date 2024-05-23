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
HANDLE MotorIOMMF = CreateFileMappingW(INVALID_HANDLE_VALUE, NULL, PAGE_READWRITE, 0, 1024, L"MotorIOFileMap");
MotorIOStruct* MotorIOData = (MotorIOStruct*)MapViewOfFile(MotorIOMMF, FILE_MAP_ALL_ACCESS, 0, 0, 0);

HANDLE CmdMMF = CreateFileMappingW(INVALID_HANDLE_VALUE, NULL, PAGE_READWRITE, 0, 1024, L"CmdFileMap");
CmdStruct* CmdData = (CmdStruct*)MapViewOfFile(CmdMMF, FILE_MAP_ALL_ACCESS, 0, 0, 0);

// max number of motor and IO
const int MotorCount = MotorIOData->MotorCount; // determined by HMI init code
const int InChCount = MotorIOData->InChCount; // determined by HMI init code
const int OutChCount = MotorIOData->OutChCount; // determined by number of axis in .ini file (the MHI read the .ini file)

int main() {

    // check shared memory size
    //cout << sizeof(MotorIOStruct) << endl;
    //cout << sizeof(CmdStruct) << endl;

    //----------------------------------------------------------------------------
    // Initialize logger
    //----------------------------------------------------------------------------
    
    el::Logger *MainLog = el::Loggers::getLogger("Main");

    char cCurrentPath[FILENAME_MAX];
    _getcwd(cCurrentPath, sizeof(cCurrentPath));
    char cConfName[] = "\\log_config.conf";

    char combPath[FILENAME_MAX];
    strcpy_s(combPath, _countof(combPath), cCurrentPath);
    strcat_s(combPath, _countof(combPath), cConfName);

    el::Configurations conf(combPath);
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
    AutoCycle* Auto = new AutoCycle(Mod, AxisX, AxisY, AxisZ);

    //----------------------------------------------------------------------------
    // Start monitoring and executing CMD
    //----------------------------------------------------------------------------
    // Loop until the HMI is closed
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

        for (int i = 0; i < 5; i++) {
            switch (i) {
            case 0:
                MotorIOData->Motor0.SVON = st.axesStatus[i].servoOn;
                MotorIOData->Motor0.pos = st.axesStatus[i].actualPos;
                MotorIOData->Motor0.vel = st.axesStatus[i].actualVelocity;
                MotorIOData->Motor0.alarm = st.axesStatus[i].ampAlarmCode;
                MotorIOData->Motor0.limit_max = st.axesStatus[i].positiveSoftLimit;
                MotorIOData->Motor0.limit_min = st.axesStatus[i].negativeSoftLimit;
                break;
            case 1:
                MotorIOData->Motor1.SVON = st.axesStatus[i].servoOn;
                MotorIOData->Motor1.pos = st.axesStatus[i].actualPos;
                MotorIOData->Motor1.vel = st.axesStatus[i].actualVelocity;
                MotorIOData->Motor1.alarm = st.axesStatus[i].ampAlarmCode;
                MotorIOData->Motor1.limit_max = st.axesStatus[i].positiveSoftLimit;
                MotorIOData->Motor1.limit_min = st.axesStatus[i].negativeSoftLimit;
                break;
            case 2:
                MotorIOData->Motor2.SVON = st.axesStatus[i].servoOn;
                MotorIOData->Motor2.pos = st.axesStatus[i].actualPos;
                MotorIOData->Motor2.vel = st.axesStatus[i].actualVelocity;
                MotorIOData->Motor2.alarm = st.axesStatus[i].ampAlarmCode;
                MotorIOData->Motor2.limit_max = st.axesStatus[i].positiveSoftLimit;
                MotorIOData->Motor2.limit_min = st.axesStatus[i].negativeSoftLimit;
                break;
            case 3:
                MotorIOData->Motor3.SVON = st.axesStatus[i].servoOn;
                MotorIOData->Motor3.pos = st.axesStatus[i].actualPos;
                MotorIOData->Motor3.vel = st.axesStatus[i].actualVelocity;
                MotorIOData->Motor3.alarm = st.axesStatus[i].ampAlarmCode;
                MotorIOData->Motor3.limit_max = st.axesStatus[i].positiveSoftLimit;
                MotorIOData->Motor3.limit_min = st.axesStatus[i].negativeSoftLimit;
                break;
            case 4:
                MotorIOData->Motor4.SVON = st.axesStatus[4].servoOn;
                MotorIOData->Motor4.pos = st.axesStatus[4].actualPos;
                MotorIOData->Motor4.vel = st.axesStatus[4].actualVelocity;
                MotorIOData->Motor4.alarm = st.axesStatus[4].ampAlarmCode;
                MotorIOData->Motor4.limit_max = st.axesStatus[4].positiveSoftLimit;
                MotorIOData->Motor4.limit_min = st.axesStatus[4].negativeSoftLimit;
                break;
            default:
                break;
            }
        }

        // get I/O and update the shared memory
        Input.GetInputChannel(MotorIOData->InChSelected, &MotorIOData->DIch);
        Output.GetOutputChannel(MotorIOData->OutChSelected, &MotorIOData->DOch);

        //----------------------------------------------------------------------------
        // Read command from HMI
        //----------------------------------------------------------------------------
        if (CmdData->COMMAND == COMMAND_SVON) {
            CmdData->COMMAND = 0;
            Motors[CmdData->axis]->SetServoOn();
        }
        else if (CmdData->COMMAND == COMMAND_SVOFF) {
            CmdData->COMMAND = 0;
            Motors[CmdData->axis]->SetServoOff();
        }
        else if (CmdData->COMMAND == COMMAND_ALARM_RESET) {
            CmdData->COMMAND = 0;
            for (int i = 0; i < MotorCount; i++) Motors[i]->AlarmReset();
            MainLog->info("Reset Alarm all motor");
        }
        else if (CmdData->COMMAND == COMMAND_MOVE_ABS) {
            CmdData->COMMAND = 0;
            Motors[CmdData->axis]->MoveAbs(ProfileType::Trapezoidal, CmdData->ComVel, 10000, 10000, CmdData->ComPos);
        }
        else if (CmdData->COMMAND == COMMAND_MOVE_REL) {
            CmdData->COMMAND = 0;
            Motors[CmdData->axis]->MoveRel(ProfileType::Trapezoidal, CmdData->ComVel, 10000, 10000, CmdData->ComPos);
        }
        else if (CmdData->COMMAND == COMMAND_STOP) {
            CmdData->COMMAND = 0;
            Motors[CmdData->axis]->Stop();
        }
        else if (CmdData->COMMAND == COMMAND_SET_OUTPUT) {
            CmdData->COMMAND = 0;
            Output.SetOutputBit(CmdData->OutCh, CmdData->OutBit, CmdData->OutValue);
        }
        else if (CmdData->COMMAND == COMMAND_SET_OUTPUT_CH) {
            CmdData->COMMAND = 0;
            Output.SetOutputChannel(CmdData->OutCh, CmdData->OutChValue);
        }
        // simulation for GetOutputChannelArray
        else if (CmdData->COMMAND == COMMAND_GET_OUTPUT_CH_ARRAY) {
            CmdData->COMMAND = 0;
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

        }

        //----------------------------------------------------------------------------
        // AutoCycle section
        //----------------------------------------------------------------------------
        CmdData->ACSTAT = Auto->CheckStatus();
        Auto->ReadCommand(CmdData);
    };
    
    //----------------------------------------------------------------------------
    // Terminate comunication and close device
    //----------------------------------------------------------------------------
    //thread_AC.join();
    MainLog->info("Closing application...\n");
    wmxlib.StopCommunication();
    wmxlib.CloseDevice();

    //printf("Press any key to exit.\n");
    //getchar();

    return 0;
}

