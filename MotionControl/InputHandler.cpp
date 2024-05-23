#include "InputHandler.hpp"

//----------------------------------------------------------------------------
// Definition of InputHandler class
//----------------------------------------------------------------------------

WMX3APIFUNC InputHandler::GetInputChannel(int chNum, WORD* data) {
    err = GetInBytes(chNum * 2, 2, buff);
    if (err != ErrorCode::None) {
        ErrorToString(err, errString, sizeof(errString));
        InLog->error("Failed to get input. Error=%v (%v)", err, errString);
        return err;
    }
    *data = buff[0] | (buff[1] << 8);
    return err;
}

WMX3APIFUNC InputHandler::GetInputChannelArray(int startNum, int chSize, WORD* data) {
    err = GetInBytes(startNum * 2, chSize * 2, buff);
    if (err != ErrorCode::None) {
        ErrorToString(err, errString, sizeof(errString));
        InLog->error("Failed to get input array. Error=%v (%v)", err, errString);
        return err;
    }
    for (int i = 0; i < chSize; i++) {
        data[i] = buff[2 * i] | (buff[i * 2 + 1] << 8);
    }
    return err;
}