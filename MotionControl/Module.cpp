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

	const int StepNum = 11;
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
	path.numPoints = StepNum;
	double Path[StepNum][3] = {
		{ AxisX->GetActPos(), AxisY->GetActPos(), AxisZ->Pos[1] },
		{ AxisX->Pos[0], AxisY->Pos[0], AxisZ->Pos[1] },
		{ AxisX->Pos[0], AxisY->Pos[0], AxisZ->Pos[0] },
		{ AxisX->Pos[0], AxisY->Pos[0], AxisZ->Pos[1] },
		{ AxisX->Pos[1], AxisY->Pos[1], AxisZ->Pos[1] },
		{ AxisX->Pos[1], AxisY->Pos[1], AxisZ->Pos[0] },
		{ AxisX->Pos[1], AxisY->Pos[1], AxisZ->Pos[1] },
		{ AxisX->Pos[2], AxisY->Pos[2], AxisZ->Pos[1] },
		{ AxisX->Pos[2], AxisY->Pos[2], AxisZ->Pos[0] },
		{ AxisX->Pos[2], AxisY->Pos[2], AxisZ->Pos[1] },
		{ 0, 0, AxisZ->Pos[1] }
	};

	for (int i = 0; i < StepNum; i++) {
		path.type[i] = AdvMotion::PathIntplSegmentType::Linear;
		path.target[0][i] = Path[i][0];
		path.target[1][i] = Path[i][1];
		path.target[2][i] = Path[i][2];
	}

	// still fail immediately go to exit
	advMotion->StartPathIntpl3DPos(&path);
	while (!AxisX->InPos() && !AxisY->InPos() && !AxisZ->InPos()) if (stop_flag) break;

	ModLog->info("FLOOR1(ADV) FINISH");
	stop_flag = true;
	return;
}
void Module::Floor2_3DIntp(std::atomic<bool>& stop_flag) {
	ModLog->info("FLOOR2(ADV) START");

	const int StepNum = 8;
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
	path.numPoints = StepNum;
	double Path[StepNum][3] = {
		{ AxisX->GetActPos(), AxisY->GetActPos(), AxisZ->Pos[1] },
		{ AxisX->Pos[0], AxisY->Pos[0], AxisZ->Pos[1] },
		{ AxisX->Pos[0], AxisY->Pos[0], AxisZ->Pos[0] },
		{ AxisX->Pos[1], AxisY->Pos[1], AxisZ->Pos[0] },
		{ AxisX->Pos[2], AxisY->Pos[2], AxisZ->Pos[0] },
		{ AxisX->Pos[0], AxisY->Pos[0], AxisZ->Pos[0] },
		{ AxisX->Pos[0], AxisY->Pos[0], AxisZ->Pos[1] },
		{ 0, 0, AxisZ->Pos[1] }
	};

	for (int i = 0; i < StepNum; i++) {
		path.type[i] = AdvMotion::PathIntplSegmentType::Linear;
		path.target[0][i] = Path[i][0];
		path.target[1][i] = Path[i][1];
		path.target[2][i] = Path[i][2];
	}

	advMotion->StartPathIntpl3DPos(&path);
	
	// still fail immediately go to exit
	while (!AxisX->InPos() && !AxisY->InPos() && !AxisZ->InPos()) if (stop_flag) break;
	
	ModLog->info("FLOOR2(ADV) FINISH");
	stop_flag = true;
	return;
}