#pragma once
#ifndef INPUT_HANDLER_HPP
#define INPUT_HANDLER_HPP

#include "WMX3Api.h"
#include "IOApi.h"

#include "easylogging++.h"

using namespace wmx3Api;

class InputHandler : Io {
public:
	InputHandler(WMX3Api *wmxlib, int cMaxCh) : Io(wmxlib), buff(new unsigned char[cMaxCh * 2]), maxCh(cMaxCh), InLog(el::Loggers::getLogger("Input")) {};
	const int maxCh;
	WMX3APIFUNC GetInputChannel(int chNum, WORD* data);
	WMX3APIFUNC GetInputChannelArray(int chStart, int chSize, WORD* data);
private:
	el::Logger* InLog;
	unsigned char* buff;
	int err;
	char errString[256];
};

#endif // !INPUT_HANDLER_HPP