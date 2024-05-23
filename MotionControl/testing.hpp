#ifndef TESING_HPP
#define TESTING_HPP

#include "AdvancedMotionApi.h"
#include "ApiBufferApi.h"
#include "CompensationApi.h"
#include "CoreMotionApi.h"
#include "CyclicBufferApi.h"
#include "EventApi.h"
#include "IOApi.h"
#include "LogApi.h"
#include "UserMemoryApi.h"
#include "WMX3Api.h"

using namespace wmx3Api;

extern int err;
extern char errString[256];

class TestWMXMain:WMX3Api {
public:
	void Init();
	void Exit();
};

class TestInputHand:Io {
public:
	int maxChNum;
	TestInputHand(int chNum);
	void GetInputChannel(int chNum, WORD* data);
	void GetInputChannelArr(int chStart, int chSize, WORD* data);
};

#endif // !TESTING_HPP
