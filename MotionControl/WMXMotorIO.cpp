//#include "WMXMotorIO.hpp";
//
//int err;
//char errString[256];
//int counter;
//
//WMX3Api wmxlib;
//CoreMotion wmxlib_cm;
//CoreMotionStatus st;
//Motion::PosCommand pos;
//
//WMX3APIFUNC WMXMain::Init(int motorCount) {
//    int initErr = 0;
//    WMXLog->info("Starting application...");
//    initErr = wmxlib.CreateDevice(_T("C:\\Program Files\\SoftServo\\WMX3"), DeviceType::DeviceTypeNormal);
//    if (err != ErrorCode::None) {
//        ErrorToString(initErr, errString, sizeof(errString));
//        WMXLog->error("Failed to create device. Error=%v (%v)", initErr, errString);
//        WMXMain::Exit();
//        return initErr;
//    }
//
//    initErr = wmxlib.StartCommunication(5000); //Wait up to 5 seconds for communication to start
//    if (err != ErrorCode::None) {
//        ErrorToString(err, errString, sizeof(errString));
//        WMXLog->error("Failed to start communication. Error=%v (%v)", initErr, errString);
//        WMXMain::Exit();
//        return initErr;
//    }
//    for (int i = 0; i < motorCount; i++) axisControl->SetServoOn(i, 1);
//    WMXLog->info("WXM lib initialized");
//    return initErr;
//}
//
//WMX3APIFUNC WMXMain::Exit() {
//    WMXLog->info("Closing application...\n");
//    err = wmxlib.StopCommunication();
//    if (err != ErrorCode::None) {
//        wmxlib.ErrorToString(err, errString, sizeof(errString));
//        WMXLog->error("Failed to stop communication. Error=%v (%v)", err, errString);
//    }
//
//    err = wmxlib.CloseDevice();
//    if (err != ErrorCode::None) {
//        wmxlib.ErrorToString(err, errString, sizeof(errString));
//        WMXLog->error("Failed to close device. Error=%v (%v)", err, errString);
//    }
//    return err;
//}
//
////----------------------------------------------------------------------------
//// Definition of MotorControl class
////----------------------------------------------------------------------------
//
//WMX3APIFUNC MotorControl::SetServoOn() {
//    err = axisControl->SetServoOn(motorID, 1);
//    if (err != ErrorCode::None) {
//        ErrorToString(err, errString, sizeof(errString));
//        MotorLog->error("Failed to set servo off. Error=%v (%v)", err, errString);
//        return err;
//    }
//    MotorLog->info("Axis %v SVON", motorID);
//    return err;
//}
//
//WMX3APIFUNC MotorControl::SetServoOff() {
//    err = axisControl->SetServoOn(motorID, 0);
//    if (err != ErrorCode::None) {
//        ErrorToString(err, errString, sizeof(errString));
//        MotorLog->error("Failed to set servo off. Error=%v (%v)", err, errString);
//        return err;
//    }
//    MotorLog->info("Axis %v SVOFF", motorID);
//    return err;
//}
//
//WMX3APIFUNC MotorControl::AlarmReset() {
//    err = axisControl->ClearAxisAlarm(motorID);
//    if (err != ErrorCode::None) {
//        ErrorToString(err, errString, sizeof(errString));
//        MotorLog->error("Failed to reset alarm. Error=%v (%v)", err, errString);
//    }
//    return err;
//}
//
//WMX3APIFUNC MotorControl::MoveAbs(ProfileType::T type, double vel, int acc, int dec, double target) {
//    pos.axis = motorID;
//    pos.profile.type = type;
//    pos.profile.velocity = vel;
//    pos.profile.acc = acc;
//    pos.profile.dec = dec;
//    pos.target = target;
//    //std::cout << err;
//    err = motion->StartPos(&pos);
//    //std::cout << err; // this will return 0 if run this function on different thread
//    if (err != ErrorCode::None) {
//        ErrorToString(err, errString, sizeof(errString));
//        MotorLog->error("Failed to execute motion. Error=%v (%v)", err, errString);
//        return err;
//    }
//    MotorLog->info("Axis %v MOVE ABS Pos: %v Vel %v", motorID, target, vel);
//    return err;
//}
//
//WMX3APIFUNC MotorControl::MoveRel(ProfileType::T type, double vel, int acc, int dec, double target) {
//    pos.axis = motorID;
//    pos.profile.type = type;
//    pos.profile.velocity = vel;
//    pos.profile.acc = acc;
//    pos.profile.dec = dec;
//    pos.target = target;
//    err = motion->StartMov(&pos);
//    if (err != ErrorCode::None) {
//        ErrorToString(err, errString, sizeof(errString));
//        MotorLog->error("Failed to execute motion. Error=%v (%v)", err, errString);
//        return err;
//    }
//    MotorLog->info("Axis %v MOVE REL Pos: %v Vel %v", motorID, target, vel);
//    return err;
//}
//
//WMX3APIFUNC MotorControl::Stop() {
//    err = motion->Stop(motorID, 50000);
//    if (err != ErrorCode::None) {
//        ErrorToString(err, errString, sizeof(errString));
//        MotorLog->error("Failed to stop axis. Error=%v (%v)", err, errString);
//        return err;
//    }
//    MotorLog->info("Axis %v STOP", motorID);
//    return err;
//}
//
//WMX3APIFUNC MotorControl::Home() {
//    pos.axis = motorID;
//    pos.profile.type = ProfileType::Trapezoidal;
//    pos.profile.velocity = 10000;
//    pos.profile.acc = 10000;
//    pos.profile.dec = 10000;
//    pos.target = homePos;
//    err = motion->StartPos(&pos);
//    //std::cout << err; // this will return 0 if run this function on different thread
//    if (err != ErrorCode::None) {
//        ErrorToString(err, errString, sizeof(errString));
//        MotorLog->error("Failed to execute motion. Error=%v (%v)", err, errString);
//        return err;
//    }
//    MotorLog->info("Axis %v HOMING", motorID);
//    return err;
//
//    //err = home->StartHome(motorID);
//    //if (err != ErrorCode::None) {
//    //    ErrorToString(err, errString, sizeof(errString));
//    //    Log->info("Failed to start homing. Error=%v (%v)", err, errString);
//    //    return err;
//    //}
//    //Log->info("Axis %v HOME", motorID);
//    //return err;
//    //// Homing
//    //for (int i = 0; i < 5; i++) {
//    //    Log->info("Homing axis %v", i);
//    //    ServoOn();
//    //    Config::HomeParam homeParam;
//    //    config->GetHomeParam(0, &homeParam);
//    //    homeParam.homeType = Config::HomeType::CurrentPos;
//    //    err = config->SetHomeParam(0, &homeParam);
//    //    home->StartHome(0);
//    //    motion->Wait(0);
//    //}
//    //return err;
//}
//
//bool MotorControl::GetSVON() {
//    GetStatus(&st);
//    return st.axesStatus[motorID].servoOn;
//}
//
//double MotorControl::GetActPos() {
//    GetStatus(&st);
//    return st.axesStatus[motorID].actualPos;
//}
//
//bool MotorControl::InPos() {
//    GetStatus(&st);
//    return st.axesStatus[motorID].inPos;
//}
//
////----------------------------------------------------------------------------
//// Definition of InputHandler class
////----------------------------------------------------------------------------
//
//WMX3APIFUNC InputHandler::GetInputChannel(int chNum, WORD* data) {
//    err = GetInBytes(chNum * 2, 2, buff);
//    if (err != ErrorCode::None) {
//        ErrorToString(err, errString, sizeof(errString));
//        InLog->error("Failed to get input. Error=%v (%v)", err, errString);
//        return err;
//    }
//    *data = buff[0] | (buff[1] << 8);
//    return err;
//}
//
//WMX3APIFUNC InputHandler::GetInputChannelArray(int startNum, int chSize, WORD* data) {
//    err = GetInBytes(startNum * 2, chSize * 2, buff);
//    if (err != ErrorCode::None) {
//        ErrorToString(err, errString, sizeof(errString));
//        InLog->error("Failed to get input array. Error=%v (%v)", err, errString);
//        return err;
//    }
//    for (int i = 0; i < chSize; i++) {
//        data[i] = buff[2 * i] | (buff[i * 2 + 1] << 8);
//    }
//    return err;
//}
//
////----------------------------------------------------------------------------
//// Definition of OutputHandler class
////----------------------------------------------------------------------------
//
//WMX3APIFUNC OutputHandler::GetOutputChannel(int chNum, WORD *data) {
//    err = GetOutBytes(chNum * 2, 2, buff);
//    if (err != ErrorCode::None) {
//        ErrorToString(err, errString, sizeof(errString));
//        OutLog->error("Failed to get output. Error=%v (%v)", err, errString);
//        return err;
//    }
//    *data = buff[0] | (buff[1] << 8);
//    return err;
//}
//
//WMX3APIFUNC OutputHandler::GetOutputChannelArray(int startNum, int chSize, WORD *data) {
//    err = GetOutBytes(startNum * 2, chSize * 2, buff);
//    if (err != ErrorCode::None) {
//        ErrorToString(err, errString, sizeof(errString));
//        OutLog->error("Failed to get output array. Error=%v (%v)", err, errString);
//        return err;
//    }
//    for (int i = 0; i < chSize; i++) {
//        data[i] = buff[2 * i] | (buff[i * 2 + 1] << 8);
//    }
//    return err;
//}
//
//WMX3APIFUNC OutputHandler::SetOutputBit(int outch, int outbit, int outvalue) {
//    int outbit_ori = outbit;
//    int outch_ori = outch;
//    if (outbit >= 8) {
//        outch = outch*2+1;
//        outbit -= 8;
//    }
//    else {
//        outch = outch * 2;
//    }
//    err = SetOutBit(outch, outbit, outvalue);
//    if (err != ErrorCode::None) {
//        ErrorToString(err, errString, sizeof(errString));
//        OutLog->error("Failed to set output bit. Error=%v (%)", err, errString);
//        return err;
//    }
//    OutLog->info("Set Output Ch: %v Bit: %v Value: %v", outch_ori, outbit_ori, outvalue);
//    return err;
//}
//
//WMX3APIFUNC OutputHandler::SetOutputChannel(int chNum, WORD data) {
//    unsigned char first = data & 0x00FF;
//    unsigned char second = (data >> 8) & 0x00FF;
//
//    err = SetOutByte(chNum * 2, first);
//    if (err != ErrorCode::None) {
//        ErrorToString(err, errString, sizeof(errString));
//        OutLog->error("Failed to set output channel. Error=%v (%v)", err, errString);
//        return err;
//    }
//    err = SetOutByte(chNum * 2 + 1, second);
//    if (err != ErrorCode::None) {
//        ErrorToString(err, errString, sizeof(errString));
//        OutLog->error("Failed to set output channel. Error=%v (%v)", err, errString);
//        return err;
//    }
//
//    std::string text = "Set Output Channel ";
//    text.append(std::to_string(chNum));
//    text.append(" ");
//    for (int j = 0; j != 8; j++) text.append(std::to_string((data & (1 << j)) != 0));
//    text.append(" ");
//    for (int j = 8; j != 16; j++) text.append(std::to_string((data & (1 << j)) != 0));
//    OutLog->info(text);
//    return err;
//}