#include "testing.hpp";

int err;
char errString[256];
int counter;

const int maxCh = 10;

void TestWMXMain::Init() {
    printf("Starting application...\n");
    err = CreateDevice(_T("C:\\Program Files\\SoftServo\\WMX3"), DeviceType::DeviceTypeNormal);
    if (err != ErrorCode::None) {
        ErrorToString(err, errString, sizeof(errString));
        printf("Failed to create device. Error=%d (%s)\n", err, errString);
        TestWMXMain::Exit();
        return;
    }

    err = StartCommunication(5000); //Wait up to 5 seconds for communication to start
    if (err != ErrorCode::None) {
        ErrorToString(err, errString, sizeof(errString));
        printf("Failed to start communication. Error=%d (%s)\n", err, errString);
        TestWMXMain::Exit();
        return;
    }
    printf("WXM lib initialized\n");
    return;
}

void TestWMXMain::Exit() {
    printf("Closing application...\n");
    err = StopCommunication();
    if (err != ErrorCode::None) {
        ErrorToString(err, errString, sizeof(errString));
        printf("Failed to stop communication. Error=%d (%s)\n", err, errString);
    }

    err = CloseDevice();
    if (err != ErrorCode::None) {
        ErrorToString(err, errString, sizeof(errString));
        printf("Failed to close device. Error=%d (%s)\n", err, errString);
    }
}

//----------------------------------------------------------------------------
// Definition of InputHandler class
//----------------------------------------------------------------------------


TestInputHand::TestInputHand(int chNum) {
    maxChNum = chNum;
}

void TestInputHand::GetInputChannel(int chNum, WORD* data) {
    unsigned char buff[2];
    GetInBytes(chNum * 2, 2, buff);
    *data = buff[0] | (buff[1] << 8);
}

void TestInputHand::GetInputChannelArr(int startNum, int chSize, WORD* data) {
    unsigned char buff[maxCh * 2];
    GetInBytes(startNum * 2, chSize * 2, buff);

    for (int i = 0; i < chSize; i++) {
        data[i] = buff[2 * i] | (buff[i * 2 + 1] << 8);
    }
}