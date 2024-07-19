## WMX Motion Control Interface

This project demonstrates the use of the WMX motion control library through a combination of a C++ app and a WinForm application.

- C++ application (MotionControl): Implements the WMX motion control library, handling all motion control functionalities.
- WinForm application (HMI): Serves as the user interface, enabling users to interact with and control the motion system.

Key features:

- I/O control and monitoring
- Motor control (manual or auto) and monitoring
- Customizable motor/axis name and count
- Logging functionality
- Shared memory for communication between C++ and WinForm applications

## How to run the code:
1. Install WMX motion control library with default installation dir https://www.movensys.com/solutions/core_technology/wmx
2. Open `MotionControl.sln` and build the program
3. Open `HMI.sln`, build and run the program
4. On the `Job List` tab click the `Browse` button and select the `joblist` folder (\practice_fullstack_WMX\HMI\joblist)
5. Enjoy :)

## Preview

<p align="center">
  <img src="/figures/job_list_tab.png" style="width:500px;"/>
  <img src="/figures/hardware_status_tab.png" style="width:500px;"/>
</p>

<p align="center">
  <img src="/figures/motor_command_tab.png" style="width:500px;"/>
  <img src="/figures/auto_cycle_tab.png" style="width:500px;"/>
</p>

<p align="center">
  <img src="/figures/console.png" style="width:500px;"/>
</p>

## Update log before first commit
====== MotionControl (Full Stack) - AutoCycle ====== 

This project is the updated version of MotionControl - Costum Class2 project with added new tab.
Project log:
- MotionControl->SingleMotorAxis.hpp contain: motor class, input class and output class
- Each classes mentioned above inherit WMXLib directly
- With input channel max count and output channel max count. Adjust the number of Input and Ouput channel based on Class init.
- With dynamically allocate motor count base on the axis.ini file.
- 2 shared memory: 1 for motor and I/O status, 1 for command only
- The shared memory for IO only store 1 channel at a time (because dynamic allocation input channel and output channel)
- The shared memory for motor store 5 motor status at all time
- Each motor need an object of class MotorClass. MotorControl class req motor ID when create object. 
  So then in the main make an array of MotorControl object
- Add clear alarm / reset alarm
- Fix joblist saving (always reducing the numbes of joblist because of -1 code every save button clicked)

- Add go to home (manually move absolute to desired home position, because the home position actually req switch)
- Make module class (handle all the function of autocycle)
- Autocycle floor 1 and floor 2 successfull

- the auto class get the module class and the module class get the motor classs. (with pass by reference). Niceee.
- using a proper log engine (WMX, Main, Motor, Input, and Output category) with costum .log name
- the position index is on the motor not module

- delete unused files in HMI
- directory aware app for launch the MotorControl.exe (C#) and read easylogging .conf file (C++) 
  the log_config.conf file (for easylogging++) is located in two folders
	- in the MotionControl project folder for local run
	- in the same folder with HMI.exe for running from HMI (i think this is more important because usually run from HMI)

Latest update:
- change file name to main
- seperate motor and IO class
so in the main we initialize the wmxlib and start communication then we pass the reference of the wmxlib to motor and I/O class. then since that class inherit from the wmx module then in the constructor initializer we pass the wmxlib to the respective module.

- make an vector (list) of motor obj
- AxisX, AxisY, and AxisZ get the motor from the motor obj vector
- not using global variable in the class (wmxlib, err, charerr >> all become part of the private modifier inside the class)

- in the main. remove editparam function and make it a method inside the motorhandler


Possible improvement:
- console app may also update axis name everytime
- console app can recieve an simple command (like cmd)
