#pragma once
#ifndef OUTPUT_HANDLER_HPP
#define OUTPUT_HANDLER_HPP

#include "WMX3Api.h"
#include "IOApi.h"

#include "easylogging++.h"

using namespace wmx3Api;

class OutputHandler : Io {
public:
	OutputHandler(WMX3Api *wmxlib, int cMaxCh) : Io(wmxlib), buff(new unsigned char[cMaxCh * 2]), maxCh(cMaxCh), OutLog(el::Loggers::getLogger("Output")) {};
	const int maxCh;
	WMX3APIFUNC GetOutputChannel(int chNum, WORD* data);
	WMX3APIFUNC GetOutputChannelArray(int chStart, int chSize, WORD* data);
	WMX3APIFUNC SetOutputBit(int outch, int outbit, int outvalue);
	WMX3APIFUNC SetOutputChannel(int cnNum, WORD data);
private:
	el::Logger* OutLog;
	unsigned char* buff;
	int err;
	char errString[256];
};

#endif // !OUTPUT_HANDLER_HPP