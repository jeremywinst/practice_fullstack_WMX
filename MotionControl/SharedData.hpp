#pragma once
#pragma pack(push, 1)
typedef struct MotDataStruct {
    bool SVON;
    double pos, vel;
    int alarm;
    bool limit_min;
    bool limit_max;
};

typedef struct MotorIOStruct {
    struct MotDataStruct Motor[5];
    int DIO_channel;
    int MotorCount, InChCount, OutChCount;
    int InChSelected, OutChSelected;
    WORD DIch[10];
    WORD DOch[10];
    //unsigned char DI0, DI1, DI2, DI3;
    //unsigned char DO0, DO1, DO2, DO3;
};

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