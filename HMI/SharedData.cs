using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HMI {

    [StructLayout(LayoutKind.Sequential, Pack = 1)] // Ensure fields are laid out in memory sequentially
    public struct MotorData {
        [MarshalAs(UnmanagedType.I1)]
        public bool SVON;
        public double pos, vel;
        public int alarm;
        [MarshalAs(UnmanagedType.I1)]
        public bool limit_min;
        [MarshalAs(UnmanagedType.I1)]
        public bool limit_max;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)] // Ensure fields are laid out in memory sequentially
                                                    // initialize struct for memory mapped file
    public struct MotorIOStruct {
        public MotorData Motor0;
        public MotorData Motor1;
        public MotorData Motor2;
        public MotorData Motor3;
        public MotorData Motor4;
        public int DIO_channel;
        public int MotorCount, InChCount, OutChCount;
        public int InChSelected, OutChSelected;
        public ushort DIch, DOch;
        //public byte DI0, DI1, DI2, DI3;
        //public byte DO0, DO1, DO2, DO3;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)] // Ensure fields are laid out in memory sequentially
    public struct CmdStruct {
        public int COMMAND;
        public int ACSTAT;
        public int axis;
        public double ComPos, ComVel;
        public ushort OutChValue;
        public int OutBit, OutValue, OutCh;
        public int OutChArrStart, OutChArrSize;
        public double PosX1, PosX2, PosX3;
        public double PosY1, PosY2, PosY3;
        public double PosZ1, PosZ2;
        [MarshalAs(UnmanagedType.I1)]
        public bool is_closed;
    }
}
