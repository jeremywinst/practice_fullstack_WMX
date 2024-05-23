//#pragma once
//#ifndef WMX_MOTOR_IO_HPP
//#define WMX_MOTOR_IO_HPP
//
//#include <iostream>
//
//#include "WMX3Api.h"
//#include "CoreMotionApi.h"
//#include "IOApi.h"
//
//#include "easylogging++.h"
//
//using namespace wmx3Api;
//
//extern int err;
//extern char errString[256];
//extern int counter;
//
//extern WMX3Api wmxlib;
//extern CoreMotion wmxlib_cm;
//extern CoreMotionStatus st;
//extern Motion::PosCommand pos;
//
//class WMXMain:CoreMotion {
//public:
//	el::Logger* WMXLog = el::Loggers::getLogger("WMX");
//	WMX3APIFUNC Init(int motorCount);
//	WMX3APIFUNC Exit();
//};
//
//class MotorControl :CoreMotion {
//public:
//	MotorControl(int cMotorID) : motorID(cMotorID), homePos(0), MotorLog(el::Loggers::getLogger("Motor")) {};
//	el::Logger* MotorLog;
//	const int motorID;
//	double homePos;
//	WMX3APIFUNC SetServoOn();
//	WMX3APIFUNC SetServoOff();
//	WMX3APIFUNC AlarmReset();
//	WMX3APIFUNC MoveAbs(ProfileType::T type, double vel, int acc, int dec, double target);
//	WMX3APIFUNC MoveRel(ProfileType::T type, double vel, int acc, int dec, double target);
//	WMX3APIFUNC Stop();
//	WMX3APIFUNC Home();
//	bool GetSVON();
//	double GetActPos();
//	bool InPos();
//	double Pos[3];
//};
//
//class InputHandler:Io {
//public:
//	el::Logger* InLog = el::Loggers::getLogger("Input");
//	InputHandler(int cMaxCh) : buff(new	unsigned char[cMaxCh * 2]), maxCh(cMaxCh), Io(&wmxlib) {};
//	const int maxCh;
//	WMX3APIFUNC GetInputChannel(int chNum, WORD *data);
//	WMX3APIFUNC GetInputChannelArray(int chStart, int chSize, WORD *data);
//private:
//	unsigned char* buff;
//};
//
//class OutputHandler:Io {
//public:
//	el::Logger* OutLog = el::Loggers::getLogger("Output");
//	OutputHandler(int cMaxCh) : buff(new unsigned char[cMaxCh * 2]), maxCh(cMaxCh), Io(&wmxlib) {};
//	const int maxCh;
//	WMX3APIFUNC GetOutputChannel(int chNum, WORD *data);
//	WMX3APIFUNC GetOutputChannelArray(int chStart, int chSize, WORD *data);
//	WMX3APIFUNC SetOutputBit(int outch, int outbit, int outvalue);
//	WMX3APIFUNC SetOutputChannel(int cnNum, WORD data);
//private:
//	unsigned char* buff;
//};
//
//#endif // !WMX_MOTOR_IO_INT_HPP