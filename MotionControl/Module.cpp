#include "Module.hpp";

void Module::GoHome() {
	AxisX->Home();
	AxisY->Home();
	AxisZ->Home();
}

void Module::StopAll() {
	AxisZ->homePos = 5000;
	AxisX->Stop();
	AxisY->Stop();
	AxisZ->Stop();
}

void Module::Floor1(std::atomic<bool>& stop_flag) {
	
	ModLog->info("FLOOR1 START");
	int const StepNum = 11;

	double Path[StepNum][3] = { 
		{AxisX->GetActPos(), AxisY->GetActPos(), AxisZ->Pos[1] },
		{AxisX->Pos[0], AxisY->Pos[0], AxisZ->Pos[1]},
		{AxisX->Pos[0], AxisY->Pos[0], AxisZ->Pos[0]},
		{AxisX->Pos[0], AxisY->Pos[0], AxisZ->Pos[1]}, 
		{AxisX->Pos[1], AxisY->Pos[1], AxisZ->Pos[1]}, 
		{AxisX->Pos[1], AxisY->Pos[1], AxisZ->Pos[0]}, 
		{AxisX->Pos[1], AxisY->Pos[1], AxisZ->Pos[1]}, 
		{AxisX->Pos[2], AxisY->Pos[2], AxisZ->Pos[1]}, 
		{AxisX->Pos[2], AxisY->Pos[2], AxisZ->Pos[0]}, 
		{AxisX->Pos[2], AxisY->Pos[2], AxisZ->Pos[1]},
		{0, 0, AxisZ->Pos[1]} };

	for (int i = 0; i < StepNum; i++) {
		ModLog->info("===Step %v===",i);
		AxisX->MoveAbs(ProfileType::Trapezoidal, 10000, 10000, 10000, Path[i][0]);
		AxisY->MoveAbs(ProfileType::Trapezoidal, 10000, 10000, 10000, Path[i][1]);
		AxisZ->MoveAbs(ProfileType::Trapezoidal, 10000, 10000, 10000, Path[i][2]);
		while (!AxisX->InPos() || !AxisY->InPos() || !AxisZ->InPos());
		if (stop_flag) break;
	}

	ModLog->info("FLOOR1 FINISH");
	stop_flag = true;
	return;
}
void Module::Floor2(std::atomic<bool>& stop_flag) {

	ModLog->info("FLOOR2 START");
	int const StepNum = 8;

	double Path[StepNum][3] = {
		{AxisX->GetActPos(), AxisY->GetActPos(), AxisZ->Pos[1] },
		{AxisX->Pos[0], AxisY->Pos[0], AxisZ->Pos[1]},
		{AxisX->Pos[0], AxisY->Pos[0], AxisZ->Pos[0]},
		{AxisX->Pos[1], AxisY->Pos[1], AxisZ->Pos[0]},
		{AxisX->Pos[2], AxisY->Pos[2], AxisZ->Pos[0]},
		{AxisX->Pos[0], AxisY->Pos[0], AxisZ->Pos[0]},
		{AxisX->Pos[0], AxisY->Pos[0], AxisZ->Pos[1]},
		{0, 0, AxisZ->Pos[1]} };

	for (int i = 0; i < StepNum; i++) {
		ModLog->info("===Step %v===", i);
		AxisX->MoveAbs(ProfileType::Trapezoidal, 10000, 10000, 10000, Path[i][0]);
		AxisY->MoveAbs(ProfileType::Trapezoidal, 10000, 10000, 10000, Path[i][1]);
		AxisZ->MoveAbs(ProfileType::Trapezoidal, 10000, 10000, 10000, Path[i][2]);
		while (!AxisX->InPos() || !AxisY->InPos() || !AxisZ->InPos());
		if (stop_flag) break;
	}

	ModLog->info("FLOOR2 FINISH");
	stop_flag = true;
	return;
}

void Module::Floor1_3DIntp(std::atomic<bool>& stop_flag) {
	ModLog->info("FLOOR1(ADV) START");
	path.axis[0] = 0;
	path.axis[1] = 1;
	path.axis[2] = 2;

	//Use single motion profile for entire path
	path.enableConstProfile = 1;
	path.profile[0].type = ProfileType::Trapezoidal;
	path.profile[0].velocity = 10000;
	path.profile[0].acc = 10000;
	path.profile[0].dec = 10000;

	//Define linear and circular segments
	path.numPoints = 11;

	// move Z up
	path.type[0] = AdvMotion::PathIntplSegmentType::Linear;
	path.target[0][0] = AxisX->GetActPos();
	path.target[1][0] = AxisY->GetActPos();
	path.target[2][0] = AxisZ->Pos[1];

	// move p1
	path.type[1] = AdvMotion::PathIntplSegmentType::Linear;
	path.target[0][1] = AxisX->Pos[0];
	path.target[1][1] = AxisY->Pos[0];
	path.target[2][1] = AxisZ->Pos[1];

	// z down up
	path.type[2] = AdvMotion::PathIntplSegmentType::Linear;
	path.target[0][2] = AxisX->Pos[0];
	path.target[1][2] = AxisY->Pos[0];
	path.target[2][2] = AxisZ->Pos[0];
	path.type[3] = AdvMotion::PathIntplSegmentType::Linear;
	path.target[0][3] = AxisX->Pos[0];
	path.target[1][3] = AxisY->Pos[0];
	path.target[2][3] = AxisZ->Pos[1];

	// move p2
	path.type[4] = AdvMotion::PathIntplSegmentType::Linear;
	path.target[0][4] = AxisX->Pos[1];
	path.target[1][4] = AxisY->Pos[1];
	path.target[2][4] = AxisZ->Pos[1];

	// z down up
	path.type[5] = AdvMotion::PathIntplSegmentType::Linear;
	path.target[0][5] = AxisX->Pos[1];
	path.target[1][5] = AxisY->Pos[1];
	path.target[2][5] = AxisZ->Pos[0];
	path.type[6] = AdvMotion::PathIntplSegmentType::Linear;
	path.target[0][6] = AxisX->Pos[1];
	path.target[1][6] = AxisY->Pos[1];
	path.target[2][6] = AxisZ->Pos[1];

	// move p3
	path.type[7] = AdvMotion::PathIntplSegmentType::Linear;
	path.target[0][7] = AxisX->Pos[2];
	path.target[1][7] = AxisY->Pos[2];
	path.target[2][7] = AxisZ->Pos[1];

	// z down up
	path.type[8] = AdvMotion::PathIntplSegmentType::Linear;
	path.target[0][8] = AxisX->Pos[2];
	path.target[1][8] = AxisY->Pos[2];
	path.target[2][8] = AxisZ->Pos[0];
	path.type[9] = AdvMotion::PathIntplSegmentType::Linear;
	path.target[0][9] = AxisX->Pos[2];
	path.target[1][9] = AxisY->Pos[2];
	path.target[2][9] = AxisZ->Pos[1];

	// move home
	path.type[7] = AdvMotion::PathIntplSegmentType::Linear;
	path.target[0][10] = 0;
	path.target[1][10] = 0;
	path.target[2][10] = AxisZ->Pos[1];

	// still fail immediately go to exit
	advMotion->StartPathIntpl3DPos(&path);
	while (!AxisX->InPos() && !AxisY->InPos() && !AxisZ->InPos()) if (stop_flag) break;

	ModLog->info("FLOOR1(ADV) FINISH");
	stop_flag = true;
	return;
}
void Module::Floor2_3DIntp(std::atomic<bool>& stop_flag) {
	ModLog->info("FLOOR2(ADV) START");
	path.axis[0] = 0;
	path.axis[1] = 1;
	path.axis[2] = 2;

	//Use single motion profile for entire path
	path.enableConstProfile = 1;
	path.profile[0].type = ProfileType::Trapezoidal;
	path.profile[0].velocity = 10000;
	path.profile[0].acc = 10000;
	path.profile[0].dec = 10000;

	//Define linear and circular segments
	path.numPoints = 8;

	// move Z up
	path.type[0] = AdvMotion::PathIntplSegmentType::Linear;
	path.target[0][0] = AxisX->GetActPos();
	path.target[1][0] = AxisY->GetActPos();
	path.target[2][0] = AxisZ->Pos[1];

	// move p1
	path.type[1] = AdvMotion::PathIntplSegmentType::Linear;
	path.target[0][1] = AxisX->Pos[0];
	path.target[1][1] = AxisY->Pos[0];
	path.target[2][1] = AxisZ->Pos[1];

	// z down
	path.type[2] = AdvMotion::PathIntplSegmentType::Linear;
	path.target[0][2] = AxisX->Pos[0];
	path.target[1][2] = AxisY->Pos[0];
	path.target[2][2] = AxisZ->Pos[0];

	// move p2
	path.type[3] = AdvMotion::PathIntplSegmentType::Linear;
	path.target[0][3] = AxisX->Pos[1];
	path.target[1][3] = AxisY->Pos[1];
	path.target[2][3] = AxisZ->Pos[0];

	// move p3
	path.type[4] = AdvMotion::PathIntplSegmentType::Linear;
	path.target[0][4] = AxisX->Pos[2];
	path.target[1][4] = AxisY->Pos[2];
	path.target[2][4] = AxisZ->Pos[0];

	// move p1
	path.type[5] = AdvMotion::PathIntplSegmentType::Linear;
	path.target[0][5] = AxisX->Pos[0];
	path.target[1][5] = AxisY->Pos[0];
	path.target[2][5] = AxisZ->Pos[0];

	// z up
	path.type[6] = AdvMotion::PathIntplSegmentType::Linear;
	path.target[0][6] = AxisX->Pos[0];
	path.target[1][6] = AxisY->Pos[0];
	path.target[2][6] = AxisZ->Pos[1];

	// move home
	path.type[7] = AdvMotion::PathIntplSegmentType::Linear;
	path.target[0][7] = 0;
	path.target[1][7] = 0;
	path.target[2][7] = AxisZ->Pos[1];

	advMotion->StartPathIntpl3DPos(&path);
	
	// still fail immediately go to exit
	while (!AxisX->InPos() && !AxisY->InPos() && !AxisZ->InPos()) if (stop_flag) break;
	
	ModLog->info("FLOOR2(ADV) FINISH");
	stop_flag = true;
	return;
}