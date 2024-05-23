#include "OutputHandler.hpp"

//----------------------------------------------------------------------------
// Definition of OutputHandler class
//----------------------------------------------------------------------------

WMX3APIFUNC OutputHandler::GetOutputChannel(int chNum, WORD* data) {
    err = GetOutBytes(chNum * 2, 2, buff);
    if (err != ErrorCode::None) {
        ErrorToString(err, errString, sizeof(errString));
        OutLog->error("Failed to get output. Error=%v (%v)", err, errString);
        return err;
    }
    *data = buff[0] | (buff[1] << 8);
    return err;
}

WMX3APIFUNC OutputHandler::GetOutputChannelArray(int startNum, int chSize, WORD* data) {
    err = GetOutBytes(startNum * 2, chSize * 2, buff);
    if (err != ErrorCode::None) {
        ErrorToString(err, errString, sizeof(errString));
        OutLog->error("Failed to get output array. Error=%v (%v)", err, errString);
        return err;
    }
    for (int i = 0; i < chSize; i++) {
        data[i] = buff[2 * i] | (buff[i * 2 + 1] << 8);
    }
    return err;
}

WMX3APIFUNC OutputHandler::SetOutputBit(int outch, int outbit, int outvalue) {
    int outbit_ori = outbit;
    int outch_ori = outch;
    if (outbit >= 8) {
        outch = outch * 2 + 1;
        outbit -= 8;
    }
    else {
        outch = outch * 2;
    }
    err = SetOutBit(outch, outbit, outvalue);
    if (err != ErrorCode::None) {
        ErrorToString(err, errString, sizeof(errString));
        OutLog->error("Failed to set output bit. Error=%v (%)", err, errString);
        return err;
    }
    OutLog->info("Set Output Ch: %v Bit: %v Value: %v", outch_ori, outbit_ori, outvalue);
    return err;
}

WMX3APIFUNC OutputHandler::SetOutputChannel(int chNum, WORD data) {
    unsigned char first = data & 0x00FF;
    unsigned char second = (data >> 8) & 0x00FF;

    err = SetOutByte(chNum * 2, first);
    if (err != ErrorCode::None) {
        ErrorToString(err, errString, sizeof(errString));
        OutLog->error("Failed to set output channel. Error=%v (%v)", err, errString);
        return err;
    }
    err = SetOutByte(chNum * 2 + 1, second);
    if (err != ErrorCode::None) {
        ErrorToString(err, errString, sizeof(errString));
        OutLog->error("Failed to set output channel. Error=%v (%v)", err, errString);
        return err;
    }

    std::string text = "Set Output Channel ";
    text.append(std::to_string(chNum));
    text.append(" ");
    for (int j = 0; j != 8; j++) text.append(std::to_string((data & (1 << j)) != 0));
    text.append(" ");
    for (int j = 8; j != 16; j++) text.append(std::to_string((data & (1 << j)) != 0));
    OutLog->info(text);
    return err;
}