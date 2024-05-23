#pragma once
#ifndef MODULE_HPP
#define MODULE_HPP

#include "MotorHandler.hpp"
#include "AdvancedMotionApi.h"

#include "easylogging++.h"

using namespace wmx3Api;

class Module:AdvancedMotion {
public:
	Module(MotorHandler *cAxisX, MotorHandler *cAxisY, MotorHandler *cAxisZ) :
		AxisX(cAxisX), AxisY(cAxisY), AxisZ(cAxisZ), ModLog(el::Loggers::getLogger("Module")) {}
	void GoHome();
	void StopAll();
	void Floor1(std::atomic<bool>& stop_flag);
	void Floor2(std::atomic<bool>& stop_flag);
	void Floor1_3DIntp(std::atomic<bool>& stop_flag);
	void Floor2_3DIntp(std::atomic<bool>& stop_flag);

private:
	el::Logger* ModLog;
	AdvMotion::PathIntpl3DCommand path;
	MotorHandler *AxisX, *AxisY, *AxisZ;
};

#endif // !MODULE_HPP