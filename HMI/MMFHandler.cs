using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HMI {

    internal class NativeMethods {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateFileMapping(IntPtr hFile, IntPtr lpFileMappingAttributes, uint flProtect, uint dwMaximumSizeHigh, uint dwMaximumSizeLow, string lpName);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr MapViewOfFile(IntPtr hFileMappingObject, uint dwDesiredAccess, uint dwFileOffsetHigh, uint dwFileOffsetLow, uint dwNumberOfBytesToMap);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnmapViewOfFile(IntPtr lpBaseAddress);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr hObject);
    }

    internal class MMFHandler<T> where T : struct {
        private nint hMapFile;
        private nint mapViewData;
        private Mutex mutex;

        private uint SHARED_MEMORY_SIZE;

        private const uint FILE_MAP_ALL_ACCESS = 0xF001F;
        private const uint PAGE_READWRITE = 0x04;
        private const uint INFINITE = 0xFFFFFFFF;

        public MMFHandler(string mapFileName, string mutName) {

            SHARED_MEMORY_SIZE = (uint)Marshal.SizeOf(typeof(T));
            Debug.WriteLine(SHARED_MEMORY_SIZE);

            hMapFile = NativeMethods.CreateFileMapping(
                IntPtr.Zero,                  // use paging file
                IntPtr.Zero,                 // default security
                PAGE_READWRITE,              // read/write access
                0,                           // maximum object size (high-order DWORD)
                SHARED_MEMORY_SIZE,                 // maximum object size (low-order DWORD)
                mapFileName);           // name of mapping object

            mapViewData = NativeMethods.MapViewOfFile(hMapFile, FILE_MAP_ALL_ACCESS, 0, 0, SHARED_MEMORY_SIZE);

            if (mapViewData == IntPtr.Zero) {
                Debug.WriteLine("Could not map view of file. Error: " + Marshal.GetLastWin32Error());
                NativeMethods.CloseHandle(hMapFile);
                return;
            }

            mutex = new Mutex(false, String.Format("Global\\{0}", mutName));

        }

        public void ReadRelease(ref T inData) {
            WaitForMutex(mutex);
            inData = Marshal.PtrToStructure<T>(mapViewData);
            mutex.ReleaseMutex();
        }

        // ReadDataLock() must be followed by WriteData() becuase the release mutex is in WriteData()
        public void ReadLock(ref T inData) {
            WaitForMutex(mutex);
            inData = Marshal.PtrToStructure<T>(mapViewData);
        }

        // WriteData() must be called after ReadDataLock() was called
        public void Write(ref T inData) {
            Marshal.StructureToPtr(inData, mapViewData, true);
            mutex.ReleaseMutex();
        }

        private void WaitForMutex(Mutex mtx) {
            bool stat = mtx.WaitOne(1000);
            if (!stat) {
                Debug.WriteLine("Failed to wait for mutex");
            }
        }
    }
}
