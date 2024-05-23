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

#pragma pack(push, 1)
typedef struct MotorData {
    bool SVON;
    double pos, vel;
    int alarm;
    bool limit_min;
    bool limit_max;
};

typedef struct MotorIOStruct {
    struct MotorData Motor0;
    struct MotorData Motor1;
    struct MotorData Motor2;
    struct MotorData Motor3;
    struct MotorData Motor4;
    int DIO_channel;
    int MotorCount, InChCount, OutChCount;
    int InChSelected, OutChSelected;
    WORD DIch, DOch;
    //unsigned char DI0, DI1, DI2, DI3;
    //unsigned char DO0, DO1, DO2, DO3;
} ;

typedef struct CmdStruct {
    int COMMAND;
    int ACSTAT;
    int axis;
    double ComPos, ComVel;
    WORD OutChValue;
    int OutBit, OutValue, OutCh;
    int OutChArrStart, OutChArrSize;
    double PosX1, PosX2, PosX3;
    double PosY1, PosY2, PosY3;
    double PosZ1, PosZ2;
    bool is_closed;
};
#pragma pack(pop)
