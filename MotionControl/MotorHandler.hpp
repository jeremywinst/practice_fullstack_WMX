#pragma once
#ifndef MOTOR_HANDLER_HPP
#define MOTOR_HANDLER_HPP

#include "WMX3Api.h"
#include "CoreMotionApi.h"

#include "easylogging++.h"

using namespace wmx3Api;

class MotorHandler : CoreMotion {
public:
	MotorHandler(WMX3Api* wmxlib, int cMotorID) : motorID(cMotorID), homePos(0), MotorLog(el::Loggers::getLogger("Motor")) {};
	const int motorID;
	double homePos;
	WMX3APIFUNC SetServoOn();
	WMX3APIFUNC SetServoOff();
	WMX3APIFUNC AlarmReset();
	WMX3APIFUNC MoveAbs(ProfileType::T type, double vel, int acc, int dec, double target);
	WMX3APIFUNC MoveRel(ProfileType::T type, double vel, int acc, int dec, double target);
	WMX3APIFUNC Stop();
	WMX3APIFUNC Home();
	WMX3APIFUNC SetInPosWidth(double width);
	bool GetSVON();
	double GetActPos();
	bool InPos();
	double Pos[3];

private:
	el::Logger* MotorLog;
	Motion::PosCommand pos;
	Config::SystemParam param;
	CoreMotionStatus st;
	int err;
	char errString[256];
};
#endif // !MOTOR_HANDLER_HPP