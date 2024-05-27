#pragma once
#include <windows.h>

const int COMMAND_SVON = 1;
const int COMMAND_SVOFF = 2;
const int COMMAND_MOVE_ABS = 3;
const int COMMAND_MOVE_REL = 4;
const int COMMAND_STOP = 5;
const int COMMAND_SET_OUTPUT = 6;
const int COMMAND_SET_OUTPUT_CH = 7;
const int COMMAND_GET_OUTPUT_CH_ARRAY = 8;
const int COMMAND_ALARM_RESET = 9;
const int COMMAND_AC_START1 = 10;
const int COMMAND_AC_START2 = 11;
const int COMMAND_HOME = 12;
const int COMMAND_STOP_AUTO_CYCLE = 13;

const int ACSTAT_READY = 1;
const int ACSTAT_IDLE = 2;
const int ACSTAT_START = 3;
const int ACSTAT_STOP = 4;
const int ACSTAT_HOMING = 5;