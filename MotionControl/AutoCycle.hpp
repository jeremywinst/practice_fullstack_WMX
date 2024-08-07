#pragma once
#ifndef AUTO_CYCLE_HPP
#define AUTO_CYCLE_HPP

#include <thread>

#include "DataTypes.hpp"
#include "Module.hpp";
#include "MMFHandler.hpp"

#include "easylogging++.h"

class AutoCycle {
public:
	AutoCycle(Module *cMod, MotorHandler *cAxisX, MotorHandler *cAxisY, MotorHandler *cAxisZ, MMFHandler<CmdStruct>* cCmdMMF)
		: Mod(cMod), AxisX(cAxisX), AxisY(cAxisY), AxisZ(cAxisZ), stop_flag(true), AutoLog(el::Loggers::getLogger("Auto")), CmdMMF(cCmdMMF) {};
	int CheckStatus();
	void ReadCommand(CmdStruct* CmdData);
	
private:
	el::Logger* AutoLog;
	Module* Mod;
	MotorHandler* AxisX, * AxisY, * AxisZ;
	MMFHandler<CmdStruct>* CmdMMF;

	// define auto cycle prop
	std::atomic<bool> stop_flag;
	bool afterStop = false;
	bool homing = false;
};

#endif // !AUTO_CYCLE_HPP
