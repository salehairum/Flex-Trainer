create database project;
use project;

------------------------------------ TABLES ----------------------------------------

/* Account */
Create Table Account
(
	accountID int Identity(1, 1) primary key not null,
	aType varchar(20),
	aPassword varchar(15) not null,
	username varchar(25) unique not null,
	email varchar(30) not null
);

/* Trainer */
Create Table Trainer
(
	trainerID int Identity(1, 1) primary key not null,
	tName varchar(35),
	dob date,
	experience varchar(25),
	accountID int not null,
	Constraint trainerFK Foreign Key(accountID) references account(accountID)
);

/* Trainer Qualifications */
Create Table TrainerQualifications
(
	qName varchar(50),
	trainerID int not null,
	Constraint trainerQ_FK Foreign Key(trainerID) references trainer(trainerID)
);

/* Trainer Specialty */
Create Table TrainerSpecialty
(
	sName varchar(50),
	trainerID int not null,
	Constraint trainerS_FK Foreign Key(trainerID) references trainer(trainerID)
);

/* Gymowner */
Create Table Gymowner
(
	gymOwnerID int Identity(1, 1) primary key not null,
	gName varchar(35),
	dob date,
	accountID int not null,
	Constraint gymOwnerFK Foreign Key(accountID) references account(accountID)
);

/* Gym */
Create Table Gym
(
	gymID int Identity(1, 1) primary key not null, 
	gLocation varchar(25),
	businessPlan varchar(25),
	size varchar(35),
	nActiveMembers int,
	gymOwnerID int not null,
	budget int,
	Constraint gymFK Foreign Key(gymOwnerID) references gymOwner(gymOwnerID)
);

/* Member */
Create Table Member
(
	memberID int Identity(1, 1) primary key not null,
	mName varchar(35),
	dob date,
	status varchar(15),
	accountID int not null,
	gymID int not null,
	Constraint memberFK1 Foreign Key(accountID) references account(accountID),
	Constraint memberFK2 Foreign Key(gymID) references gym(gymID)
);

/* Membership */
Create Table Membership
(
	membershipID int Identity(1, 1) primary key not null,
	duration varchar(25),
	mType varchar(25),
	memberID int not null,
	Constraint membershipFK Foreign Key(memberID) references member(memberID)
);

/* Admin */
Create Table Admin
(
	adminID int Identity(1, 1) primary key not null,
	aName varchar(35),
	dob date,
	accountID int not null,
	Constraint adminFK Foreign Key(accountID) references account(accountID)
);

/* WorkoutPlanTrainer */
Create Table WorkoutPlanTrainer
(
	workoutPlanID int Identity(1, 1) primary key not null, 
	muscleToWorkout varchar(25),
	dayy varchar(25),
	setss int,
	reps int,
	restIntervals int,
	experienceRequired varchar(20),
	trainerID int not null,
	purpose varchar(25),
	Constraint workoutT_FK Foreign Key(trainerID) references trainer(trainerID)
);

/* WorkoutPlanMember */
Create Table WorkoutPlanMember
(
	workoutPlanID int Identity(1, 1) primary key not null, 
	muscleToWorkout varchar(25),
	dayy varchar(25),
	setss int,
	reps int,
	restIntervals int,
	experienceRequired varchar(20),
	memberID int not null,
	purpose varchar(25),
	Constraint workoutM_FK Foreign Key(memberID) references member(memberID)
); 

/* Member Uses Workout Plan created by member */
Create Table MemberUsesWorkoutPlan
(
	workOutPlanId int not null,
	memberId int not null,
	Constraint memberWorkOutPK primary key(workOutPlanId, memberId),
	Constraint memberUsesWorkoutPlanFK_1 Foreign Key(workOutPlanId) references workOutPlanMember(workOutPlanId),
	Constraint memberUsesWorkoutPlanFK_2 Foreign Key(memberId) references member(memberId)
);

/* Member Uses Workout Plan created by trainer */
Create Table MemberUsesWorkoutPlanTrainer
(
	workOutPlanId int not null,
	memberId int not null,
	Constraint memberWorkOutTPK primary key(workOutPlanId, memberId),
	Constraint memberUsesWorkoutPlanTFK_1 Foreign Key(workOutPlanId) references workOutPlantrainer(workOutPlanId),
	Constraint memberUsesWorkoutPlanTFK_2 Foreign Key(memberId) references member(memberId)
);

/* DietPlanTrainer */
Create table DietPlanTrainer
(
	dietPlanID int Identity(1, 1) primary key not null, 
	purpose varchar(25),
	dType varchar(25),
	portionSize varchar(25),	
	trainerID int not null,
	Constraint dietT_FK Foreign Key(trainerID) references trainer(trainerID)
);

/* Diet Plan Member */
Create Table DietPlanMember
(
	dietPlanID int Identity(1, 1) primary key not null,
	purpose varchar(100),
	dtype varchar(25),
	portionSize varchar(25),
	memberID int not null,
	Constraint dietPlanMemberFK Foreign Key(memberID) references member(memberID)
);

/* Meals */
Create Table Meals
(
	mealID int Identity(1, 1) primary key not null,
	mealName varchar(50),
	fat int,
	protein int,
	carbohydrates int,
	fiber int
);

/* Allergens */
Create Table Allergens
(
	allergenName varchar(50),
	mealID int not null,
	Constraint allergensFK Foreign Key(mealID) references meals(mealID)
);

/* Meal In Diet Plan Member */
Create Table MealInDietPlanMember
(
	dietPlanId int not null,
	mealID int not null,
	Constraint mealDietPlanPK primary key(dietPlanID, mealID),
	Constraint mealInDietPlanMemberFK_1 Foreign Key(dietPlanId) references dietPlanMember(dietPlanId),
	Constraint mealInDietPlanMemberFK_2 Foreign Key(mealID) references meals(mealID)
);

/* Meal In Diet Plan Trainer */
Create Table MealInDietPlanTrainer
(
	dietPlanId int not null,
	mealID int not null,
	Constraint mealDietPlanT_PK primary key(dietPlanID, mealID),
	Constraint mealInDietPlanTrainerFK_1 Foreign Key(dietPlanId) references dietPlanTrainer(dietPlanId),
	Constraint mealInDietPlanTrainerFK_2 Foreign Key(mealID) references meals(mealID)
);

/* Member Uses Diet Plan created by member */
Create Table MemberUsesDietPlan
(
	dietPlanId int not null,
	memberId int not null,
	Constraint memberDietPlan_PK primary key(dietPlanID, memberID),
	Constraint memberUsesDietPlanFK_1 Foreign Key(dietPlanId) references dietPlanMember(dietPlanId),
	Constraint memberUsesDietPlanFK_2 Foreign Key(memberId) references member(memberId)
);

/* Member Uses Diet Plan created by trainer */
Create Table MemberUsesDietPlanTrainer
(
	dietPlanId int not null,
	memberId int not null,
	Constraint memberDietPlanT_PK primary key(dietPlanID, memberID),
	Constraint memberUsesDietPlanTFK_1 Foreign Key(dietPlanId) references dietPlantrainer(dietPlanId),
	Constraint memberUsesDietPlanTFK_2 Foreign Key(memberId) references member(memberId)
);

/* Machine */
Create Table Machine
(
	machineID int Identity(1, 1) primary key not null,
	machineName varchar(40),
	gymID int not null,
	Constraint machineFK Foreign Key(gymID) references gym(gymID)
);

/* Exercise */
Create Table Exercise
(
	exerciseID int Identity(1, 1) primary key not null,
	machineName varchar(40),	
	machineID int not null,
	Constraint exerciseFK Foreign Key(machineID) references machine(machineID)
);

/* Feedback Trainer */
Create Table FeedbackTrainer
(
	feedbackID int Identity(1, 1) primary key not null,
	comment varchar(100),
	rating int,
	discipline int,
	help int,
	trainerID int not null,
	memberID int not null,
	Constraint feedbackTrainerFK_1 Foreign Key(trainerID) references trainer(trainerID),
	Constraint feedbackTrainerFK_2 Foreign Key(memberID) references member(memberID)
);

/* Workout Plan Contains Exercise Member */
Create Table WorkoutPlanContainsExerciseMember
(
	workOutPlanId int not null,
	exerciseID int not null,
	Constraint exerciseMember_PK primary key(workOutPlanId, exerciseID),
	Constraint workoutPlanContainsExerciseMemberFK_1 Foreign Key(workOutPlanId) references workOutPlanMember(workOutPlanId),
	Constraint workoutPlanContainsExerciseMemberFK_2 Foreign Key(exerciseID) references exercise(exerciseID)
);

/* Workout Plan Contains Exercise Trainer */
Create Table WorkoutPlanContainsExerciseTrainer
(
	workOutPlanId int not null,
	exerciseID int not null,
	Constraint exerciseTrainer_PK primary key(workOutPlanId, exerciseID),
	Constraint workoutPlanContainsExerciseTrainerFK_1 Foreign Key(workOutPlanId) references workOutPlanTrainer(workOutPlanId),
	Constraint workoutPlanContainsExerciseTrainerFK_2 Foreign Key(exerciseID) references exercise(exerciseID)
);

/* Book Personal Training Session */
Create Table BookPersonalTrainingSession
(
	sessionID int Identity(1, 1) primary key not null,
	trainerId int not null,
	memberId int not null,
	timee time,
	approved BIT NOT NULL DEFAULT(0)
	Constraint bookPersonalTrainingSessionFK_1 Foreign Key(trainerId) references trainer(trainerId),
	Constraint bookPersonalTrainingSessionFK_2 Foreign Key(memberId) references member(memberId)
);

/* Gym Owner Adds Trainer */
Create Table GymOwnerAddsTrainer
(
	trainerId int not null,
	gymOwnerId int not null,
	Constraint addTrainerPK primary key(trainerId, gymOwnerId),
	Constraint gymOwnerAddsTrainerFK_1 Foreign Key(trainerId) references trainer(trainerId),
	Constraint gymOwnerAddsTrainerFK_2 Foreign Key(gymOwnerId) references gymOwner(gymOwnerId)
);

/* Trainer Joins Gym */
Create Table TrainerJoinsGym
(
	trainerId int not null,
	gymId int not null,
	approved BIT NOT NULL DEFAULT(0)
	Constraint trainerInGymPK primary key(trainerId, gymId),
	Constraint trainerJoinsGymFK_1 Foreign Key(trainerId) references trainer(trainerId),
	Constraint trainerJoinsGymFK_2 Foreign Key(gymId) references gym(gymId)
);

/* Admin Manages Gym */
Create Table AdminManagesGym
(
	adminId int not null,
	gymId int not null,
	Constraint adminManageGymPK primary key(adminId, gymId),
	Constraint adminManagesGymFK_1 Foreign Key(adminId) references admin(adminId),
	Constraint adminManagesGymFK_2 Foreign Key(gymId) references gym(gymId)
);

/* Gym Owner Deletes Trainer Account */
Create Table GymOwnerDeletesTrainerAccount
(
	trainerId int not null,
	gymOwnerId int not null,
	Constraint deleteTrainerPK primary key(trainerId, gymOwnerId),
	Constraint gymOwnerDeletesTrainerAccountFK_1 Foreign Key(trainerId) references trainer(trainerId),
	Constraint gymOwnerDeletesTrainerAccountFK_2 Foreign Key(gymOwnerId) references gymOwner(gymOwnerId)
);

/* Gym Owner Deletes Member Account */
Create Table GymOwnerDeletesMemberAccount
(
	memberId int not null,
	gymOwnerId int not null,
	Constraint deleteMemberPK primary key(gymOwnerId, memberID),
	Constraint gymOwnerDeletesMemberAccountFK_1 Foreign Key(memberId) references member(memberId),
	Constraint gymOwnerDeletesMemberAccountFK_2 Foreign Key(gymOwnerId) references gymOwner(gymOwnerId)
);

/* gymowner applies for gym */
create table GymOwnerAppliesForGymReg
(
	gymownerID int, 
	gLocation varchar(25),
	businessPlan varchar(25),
	size varchar(35),
	nActiveMembers int,
	budget int,
	Constraint gymownerAppliesFK1 Foreign Key(gymownerID) references gymowner(gymownerID)
);

/* audit table */
Create Table AuditTrail
(
	auditId int Identity(1, 1) primary key not null,
	action nvarchar(50),
	timestamp datetime2,
	details nvarchar(50)
);

/* Insert Trigger on Book Training Session Table */

CREATE TRIGGER TrainingSessionInsertTrigger
ON BookPersonalTrainingSession
AFTER INSERT
AS
BEGIN
    DECLARE @action nvarchar(50);
    DECLARE @timestamp datetime2;
	DECLARE @details nvarchar(50);
	DECLARE @memberId int;
	DECLARE @trainerId int;

	select @memberId = memberId from inserted;
	select @trainerId = trainerId from inserted;

	select @action = 'Book Training Session',
           @timestamp = GETDATE(),
		   @details = concat('Member with memberId ', @memberId, ' booked a personal training session with trainer having trainerId ', @trainerId); 
		   
    INSERT INTO AuditTrail( action, timestamp, details) 
	VALUES ( @action, @timestamp, @details);
END;

INSERT INTO BookPersonalTrainingSession (trainerId, memberId, timee)
VALUES (1, 53, '12:30');

/* Insert Trigger on Account Table */

CREATE TRIGGER AccountInsertTrigger
ON Account
AFTER INSERT
AS
BEGIN
    DECLARE @action nvarchar(50);
    DECLARE @timestamp datetime2;
	DECLARE @details nvarchar(50);
	DECLARE @accountId int;
	DECLARE @type varchar(20);

	select @accountId = accountID from inserted;
	select @type = aType from inserted;

	select @action = 'Add new Account',
           @timestamp = GETDATE(),
		   @details = concat('Account ', @accountId, ' added having type ', @type); 
		   
    INSERT INTO AuditTrail( action, timestamp, details) 
	VALUES ( @action, @timestamp, @details);
END;

/* Insert Triggger on GymOwnerAddsTrainer */

CREATE TRIGGER GymOwnerAddsTrainerInsertTrigger
ON GymOwnerAddsTrainer
AFTER INSERT
AS
BEGIN
    DECLARE @action nvarchar(50);
    DECLARE @timestamp datetime2;
	DECLARE @details nvarchar(50);
	DECLARE @gymownerId int;
	DECLARE @trainerId varchar(20);

	select @gymownerId= gymOwnerId from inserted;
	select @trainerId = trainerId from inserted;

	select @action = 'Add Trainer',
           @timestamp = GETDATE(),
		   @details = concat('Gym Owner having Id ',  @gymownerId, ' added trainer with id ', @trainerId); 
		   
    INSERT INTO AuditTrail( action, timestamp, details) 
	VALUES ( @action, @timestamp, @details);
END;

/* Insert Triggger on GymOwnerDeletesMemberAccount */

CREATE TRIGGER GymOwnerDeletesMemberAccount_
ON GymOwnerDeletesMemberAccount
AFTER INSERT
AS
BEGIN
    DECLARE @action nvarchar(50);
    DECLARE @timestamp datetime2;
	DECLARE @details nvarchar(50);
	DECLARE @gymownerId int;
	DECLARE @memberId varchar(20);

	select @gymownerId= gymOwnerId from inserted;
	select @memberId = memberId from inserted;

	select @action = 'Remove Member Account',
           @timestamp = GETDATE(),
		   @details = concat('Gym Owner having Id ',  @gymownerId, ' removed member with id ', @memberId); 
		   
    INSERT INTO AuditTrail( action, timestamp, details) 
	VALUES ( @action, @timestamp, @details);
END;

/* Insert Triggger on GymOwnerDeletesTrainerAccount */

CREATE TRIGGER GymOwnerDeletesTrainerAccount_
ON GymOwnerDeletesTrainerAccount
AFTER INSERT
AS
BEGIN
    DECLARE @action nvarchar(50);
    DECLARE @timestamp datetime2;
	DECLARE @details nvarchar(50);
	DECLARE @gymownerId int;
	DECLARE @trainerId varchar(20);

	select @gymownerId= gymOwnerId from inserted;
	select @trainerId = trainerId from inserted;

	select @action = 'Remove Trainer Account',
           @timestamp = GETDATE(),
		   @details = concat('Gym Owner having Id ',  @gymownerId, ' removed trainer with id ', @trainerId); 
		   
    INSERT INTO AuditTrail( action, timestamp, details) 
	VALUES ( @action, @timestamp, @details);
END;

/* Insert Trigger on Trainer joins gym */

CREATE TRIGGER TrainerJoinsGymTrigger
ON TrainerJoinsGym
AFTER INSERT
AS
BEGIN
    DECLARE @action nvarchar(50);
    DECLARE @timestamp datetime2;
	DECLARE @details nvarchar(50);
	DECLARE @gymId int;
	DECLARE @trainerId varchar(20);

	select @gymId= gymId from inserted;
	select @trainerId = trainerId from inserted;

	select @action = 'Trainer Joins Gym',
           @timestamp = GETDATE(),
		   @details = concat('A new trainer having trainerId ', @trainerId, ' joined gym with gymId ', @gymId); 
		   
    INSERT INTO AuditTrail( action, timestamp, details) 
	VALUES ( @action, @timestamp, @details);
END;

/* Update Trigger on Member */

CREATE TRIGGER MemberStatus
ON Member
AFTER UPDATE
AS
BEGIN
    DECLARE @action nvarchar(50);
    DECLARE @timestamp datetime2;
    DECLARE @details nvarchar(50);

    -- Check if the status column was updated
    IF UPDATE(status)
    BEGIN
        SELECT @action = 'Update Member Status',
               @timestamp = GETDATE(),
               @details = 'Member status updated due to removal of gym'; 

        INSERT INTO AuditTrail (action, timestamp, details) 
        VALUES (@action, @timestamp, @details);
    END;
END;

/* Update Trigger on Machine */

CREATE TRIGGER MachineUpdate
ON Machine
AFTER UPDATE
AS
BEGIN
    DECLARE @action nvarchar(50);
    DECLARE @timestamp datetime2;
	DECLARE @details nvarchar(50);
	DECLARE @machineId int;

	select @machineId= (select machineId from inserted);

	select @action = 'Update Machine',
           @timestamp = getdate(),
		   @details = concat('Machine with Id ', @machineId, ' updated'); 
		   
    INSERT INTO AuditTrail( action, timestamp, details) 
	VALUES ( @action, @timestamp, @details);
END;

/* Delete Trigger on Trainer Joins Gym */

CREATE TRIGGER TrainerJoinsGymDelTrigger
ON TrainerJoinsGym
AFTER DELETE
AS
BEGIN
    DECLARE @action nvarchar(50);
    DECLARE @timestamp datetime2;
	DECLARE @details nvarchar(50);
	DECLARE @gymId int;
	DECLARE @trainerId int;

	select @gymId= gymId from deleted;
	select @trainerId = trainerId from deleted;

	select @action = 'Remove Trainer Gym Relation',
           @timestamp = getdate(),
		   @details = concat('Trainer ', @trainerId, ' does not longer work for gym ', @gymId); 
		   
    INSERT INTO AuditTrail( action, timestamp, details) 
	VALUES ( @action, @timestamp, @details);
END;

/* Delete Trigger on AdminManagesGym */

CREATE TRIGGER AdminManagesGymTrigger
ON AdminManagesGym
AFTER DELETE
AS
BEGIN
    DECLARE @action nvarchar(50);
    DECLARE @timestamp datetime2;
	DECLARE @details nvarchar(50);
	DECLARE @gymId int;
	DECLARE @adminId int;

	select @gymId= gymId from deleted;
	select @adminId = adminId from deleted;

	select @action = 'Remove Admin Gym Relation',
           @timestamp = getdate(),
		   @details = concat('Admin ', @adminId, ' does not longer manages gym ', @gymId); 
		  
    INSERT INTO AuditTrail( action, timestamp, details) 
	VALUES ( @action, @timestamp, @details);
END;

/* Delete Trigger on Admin Removes Gym */

CREATE TRIGGER AdminRemovesGym
ON Gym
AFTER DELETE
AS
BEGIN
    DECLARE @action nvarchar(50);
    DECLARE @timestamp datetime2;
	DECLARE @details nvarchar(50);
	DECLARE @gymId int;

	select @gymId= gymId from deleted;

	select @action = 'Remove Gym',
           @timestamp = getdate(),
		   @details = concat('Gym ', @gymId, ' removed'); 
		   
    INSERT INTO AuditTrail( action, timestamp, details) 
	VALUES ( @action, @timestamp, @details);
END;

/* Insert Trigger on Member */

CREATE TRIGGER MemberInsertTrigger
ON Member
AFTER INSERT
AS
BEGIN
    DECLARE @action nvarchar(50);
    DECLARE @timestamp datetime2;
	DECLARE @details nvarchar(50);
	DECLARE @memberId int;
	DECLARE @gymId int;

	select @gymId= gymId from inserted;
	select @memberId = memberId from inserted;

	select @action = 'Add new Member',
           @timestamp = getdate(),
		   @details = concat('Member ', @memberId, ' joined gym ', @gymId); 
		   
    INSERT INTO AuditTrail( action, timestamp, details) 
	VALUES ( @action, @timestamp, @details);
END;