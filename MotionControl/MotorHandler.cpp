#include "MotorHandler.hpp"

//----------------------------------------------------------------------------
// Definition of MotorControl class
//----------------------------------------------------------------------------

WMX3APIFUNC MotorHandler::SetServoOn() {
    err = axisControl->SetServoOn(motorID, 1);
    if (err != ErrorCode::None) {
        ErrorToString(err, errString, sizeof(errString));
        MotorLog->error("Failed to set servo off. Error=%v (%v)", err, errString);
        return err;
    }
    MotorLog->info("Axis %v SVON", motorID);
    return err;
}

WMX3APIFUNC MotorHandler::SetServoOff() {
    err = axisControl->SetServoOn(motorID, 0);
    if (err != ErrorCode::None) {
        ErrorToString(err, errString, sizeof(errString));
        MotorLog->error("Failed to set servo off. Error=%v (%v)", err, errString);
        return err;
    }
    MotorLog->info("Axis %v SVOFF", motorID);
    return err;
}

WMX3APIFUNC MotorHandler::AlarmReset() {
    err = axisControl->ClearAxisAlarm(motorID);
    if (err != ErrorCode::None) {
        ErrorToString(err, errString, sizeof(errString));
        MotorLog->error("Failed to reset alarm. Error=%v (%v)", err, errString);
    }
    return err;
}

WMX3APIFUNC MotorHandler::MoveAbs(ProfileType::T type, double vel, int acc, int dec, double target) {
    pos.axis = motorID;
    pos.profile.type = type;
    pos.profile.velocity = vel;
    pos.profile.acc = acc;
    pos.profile.dec = dec;
    pos.target = target;
    //std::cout << err;
    err = motion->StartPos(&pos);
    //std::cout << err; // this will return 0 if run this function on different thread
    if (err != ErrorCode::None) {
        ErrorToString(err, errString, sizeof(errString));
        MotorLog->error("Failed to execute motion. Error=%v (%v)", err, errString);
        return err;
    }
    MotorLog->info("Axis %v MOVE ABS Pos: %v Vel %v", motorID, target, vel);
    return err;
}

WMX3APIFUNC MotorHandler::MoveRel(ProfileType::T type, double vel, int acc, int dec, double target) {
    pos.axis = motorID;
    pos.profile.type = type;
    pos.profile.velocity = vel;
    pos.profile.acc = acc;
    pos.profile.dec = dec;
    pos.target = target;
    err = motion->StartMov(&pos);
    if (err != ErrorCode::None) {
        ErrorToString(err, errString, sizeof(errString));
        MotorLog->error("Failed to execute motion. Error=%v (%v)", err, errString);
        return err;
    }
    MotorLog->info("Axis %v MOVE REL Pos: %v Vel %v", motorID, target, vel);
    return err;
}

WMX3APIFUNC MotorHandler::Stop() {
    err = motion->Stop(motorID, 50000);
    if (err != ErrorCode::None) {
        ErrorToString(err, errString, sizeof(errString));
        MotorLog->error("Failed to stop axis. Error=%v (%v)", err, errString);
        return err;
    }
    MotorLog->info("Axis %v STOP", motorID);
    return err;
}

WMX3APIFUNC MotorHandler::Home() {
    pos.axis = motorID;
    pos.profile.type = ProfileType::Trapezoidal;
    pos.profile.velocity = 10000;
    pos.profile.acc = 10000;
    pos.profile.dec = 10000;
    pos.target = homePos;
    err = motion->StartPos(&pos);
    //std::cout << err; // this will return 0 if run this function on different thread
    if (err != ErrorCode::None) {
        ErrorToString(err, errString, sizeof(errString));
        MotorLog->error("Failed to execute motion. Error=%v (%v)", err, errString);
        return err;
    }
    MotorLog->info("Axis %v HOMING", motorID);
    return err;
}

WMX3APIFUNC MotorHandler::SetInPosWidth(double width) {
    err = config->GetParam(&param);
    if (err != ErrorCode::None) {
        ErrorToString(err, errString, sizeof(errString));
        MotorLog->error("Failed to stop axis. Error=%v (%v)", err, errString);
        return err;
    }
    param.feedbackParam[motorID].inPosWidth = width;
    err = config->SetParam(&param);
    if (err != ErrorCode::None) {
        ErrorToString(err, errString, sizeof(errString));
        MotorLog->error("Failed to stop axis. Error=%v (%v)", err, errString);
        return err;
    }
}

bool MotorHandler::GetSVON() {
    GetStatus(&st);
    return st.axesStatus[motorID].servoOn;
}

double MotorHandler::GetActPos() {
    GetStatus(&st);
    return st.axesStatus[motorID].actualPos;
}

bool MotorHandler::InPos() {
    GetStatus(&st);
    return st.axesStatus[motorID].inPos;
}