#include "AutoCycle.hpp"

int AutoCycle::CheckStatus() {
//----------------------------------------------------------------------------
// Get the status of Auto Cycle and update to the shared memory
//----------------------------------------------------------------------------
    if (AxisX->GetSVON() && AxisY->GetSVON() && AxisZ->GetSVON() &&
        stop_flag && !afterStop && !homing) {
        return ACSTAT_READY;
    }
    else if (stop_flag && !afterStop && !homing) {
        return ACSTAT_IDLE;
    }
    else if (stop_flag && afterStop && !homing) {
        return ACSTAT_STOP;
    }
    else if (!stop_flag && !homing) {
        return ACSTAT_START;
    }
    else if (homing && (AxisX->GetActPos() != AxisX->homePos || AxisY->GetActPos() != AxisY->homePos || AxisZ->GetActPos() != AxisZ->homePos)) {
        return ACSTAT_HOMING;
    }
    else {
        homing = false;
    }
}

void AutoCycle::ReadCommand(CmdStruct* CmdData) {
    //----------------------------------------------------------------------------
    // Read command from HMI
    //----------------------------------------------------------------------------
    if (CmdData->COMMAND == COMMAND_AC_START1 && CmdData->ACSTAT == ACSTAT_READY) {
        AutoLog->info("EXECUTE FLOOR1");
        CmdData->COMMAND = 0;
        stop_flag = false;

        AxisX->Pos[0] = CmdData->PosX1;
        AxisX->Pos[1] = CmdData->PosX2;
        AxisX->Pos[2] = CmdData->PosX3;
        AxisY->Pos[0] = CmdData->PosY1;
        AxisY->Pos[1] = CmdData->PosY2;
        AxisY->Pos[2] = CmdData->PosY3;
        AxisZ->Pos[0] = CmdData->PosZ1;
        AxisZ->Pos[1] = CmdData->PosZ2;
        std::thread floor1Thread(&Module::Floor1, Mod, std::ref(stop_flag));
        floor1Thread.detach();
        //std::thread floor1Thread(&Module::Floor1_3DIntp, Mod, std::ref(stop_flag));
        //floor1Thread.detach();
    }
    else if (CmdData->COMMAND == COMMAND_AC_START2 && CmdData->ACSTAT == ACSTAT_READY) {
        AutoLog->info("EXECUTE FLOOR2");
        CmdData->COMMAND = 0;
        stop_flag = false;

        AxisX->Pos[0] = CmdData->PosX1;
        AxisX->Pos[1] = CmdData->PosX2;
        AxisX->Pos[2] = CmdData->PosX3;
        AxisY->Pos[0] = CmdData->PosY1;
        AxisY->Pos[1] = CmdData->PosY2;
        AxisY->Pos[2] = CmdData->PosY3;
        AxisZ->Pos[0] = CmdData->PosZ1;
        AxisZ->Pos[1] = CmdData->PosZ2;
        std::thread floor2Thread(&Module::Floor2, Mod, std::ref(stop_flag));
        floor2Thread.detach();
        //std::thread floor2Thread(&Module::Floor2_3DIntp, Mod, std::ref(stop_flag));
        //floor2Thread.detach();
    }
    else if (CmdData->COMMAND == COMMAND_HOME) {
        AutoLog->info("EXECUTE HOME");
        CmdData->COMMAND = 0;
        homing = true;
        afterStop = false;
        Mod->GoHome();
    }
    else if (CmdData->COMMAND == COMMAND_STOP_AUTO_CYCLE) {
        AutoLog->info("EXECUTE STOP");
        CmdData->COMMAND = 0;
        stop_flag = true;
        afterStop = true;
        //Mod->StopAll(); // enable this for immediate stop
    }
    else {
        
    }
}