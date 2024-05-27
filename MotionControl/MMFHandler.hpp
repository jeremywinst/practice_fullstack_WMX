#pragma once
#include <Windows.h>
#include <iostream>
#include "string"
#include "SharedData.hpp"

using std::string;
using std::cout;
using std::endl;

//----------------------------------------------------------------------------
// Declaration
//----------------------------------------------------------------------------

template <typename T>
class MMFHandler {
public:
    MMFHandler(string mapFileName, std::wstring mutName);
    void ReadRelease(T* inData);
    void ReadLock(T* inData);
    void Write(T* inData);
    void Release();
    void WaitForMutex(HANDLE mutext);

private:
    const int SHARED_MEMORY_SIZE = sizeof(T);
    HANDLE hMapFile;
    T* pData;
    HANDLE hMutex;
};

//----------------------------------------------------------------------------
// Definition
//----------------------------------------------------------------------------

template <typename T>
MMFHandler<T>::MMFHandler(string mapFileName, std::wstring mutName) {

    cout << SHARED_MEMORY_SIZE << endl;

    // confert name
    std::wstring wstrName(mapFileName.begin(), mapFileName.end());

    // create file mapping
    hMapFile = CreateFileMapping(
        INVALID_HANDLE_VALUE,       // use paging file
        NULL,                       // default security
        PAGE_READWRITE,             // read/write access
        0,                          // maximum object size (high-order DWORD)
        SHARED_MEMORY_SIZE,         // maximum object size (low-order DWORD)
        wstrName.c_str());               // name of mapping object

    // create map view
    pData = (T*)MapViewOfFile(
        hMapFile,               // handle to map object
        FILE_MAP_ALL_ACCESS,    // read/write permission
        0,
        0,
        SHARED_MEMORY_SIZE);

    // create mutex
    hMutex = CreateMutex(NULL, FALSE, (L"Global\\" + mutName).c_str());
    if (hMutex == NULL) {
        std::cout << "Failed to create mutex." << std::endl;
        return;
    }
}

template <typename T>
void MMFHandler<T>::ReadRelease(T* inData) {
    WaitForMutex(hMutex);
    *inData = *pData;
    ReleaseMutex(hMutex);
}

template <typename T>
void MMFHandler<T>::ReadLock(T* inData) {
    WaitForMutex(hMutex);
    *inData = *pData;
}

template <typename T>
void MMFHandler<T>::Write(T* inData) {
    memcpy(pData, inData, SHARED_MEMORY_SIZE);
    ReleaseMutex(hMutex);
}

template <typename T>
void MMFHandler<T>::Release() {
    ReleaseMutex(hMutex);
}

template <typename T>
void  MMFHandler<T>::WaitForMutex(HANDLE mtx) {
    DWORD result = WaitForSingleObject(mtx, 1000);
    if (result != WAIT_OBJECT_0) {
        std::cout << "Failed to wait for mutex" << std::endl;
    }
    else if (result == WAIT_TIMEOUT) {
        std::cout << "Timeout wait for mutex" << std::endl;
    }
}
