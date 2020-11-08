CREATE TABLE CasualRoles
(
[CasualRoleID] INT IDENTITY(1,1) PRIMARY KEY,
[CasualRole] NVARCHAR(255) NOT NULL,
[HourlyRateInZar] DECIMAL(16,2) NOT NULL,
[IsEnabled] BIT DEFAULT 1 NOT NULL
)

CREATE TABLE CasualEmployees
(
[CasualEmployeeID] INT IDENTITY(1,1) PRIMARY KEY,
[CasualRoleID] INT REFERENCES CasualRoles(CasualRoleID),
[Name] NVARCHAR(255) NOT NULL,
[Surname] NVARCHAR(255) NOT NULL,
[Email] NVARCHAR(255) NULL,
[ProfilePicture] VARBINARY(MAX) NULL,
[CurrentHourlyRateInZAR] DECIMAL(16,2) NOT NULL,
[IsEnabled] BIT DEFAULT 1 NOT NULL
)

CREATE TABLE CasualTasks
(
[CasualTaskID] INT IDENTITY(1,1) PRIMARY KEY,
[CasualTask] NVARCHAR(255) NOT NULL,
[TimeEstiamteInHours] DECIMAL (16,2) NOT NULL,
[DateStarted] DATETIME DEFAULT GETUTCDATE() NOT NULL,
[DateCompleted] DATETIME NULL,
[IsEnabled] BIT DEFAULT 1 NOT NULL
)

CREATE TABLE CasualEmployeesInCasualTasks
(
[CasualEmployeesInCasualTasksID] INT IDENTITY(1,1) PRIMARY KEY,
[CasualEmployeeID] INT REFERENCES CasualEmployees(CasualEmployeeID),
[CasualTaskID] INT REFERENCES CasualTasks(CasualTaskID),
[DateLinked] DATETIME DEFAULT GETUTCDATE() NOT NULL,
[DateUnlinked] DATETIME NULL,
[IsEnabled] BIT DEFAULT 1
)

CREATE TABLE CasualTasksLogs
(
[CasualTasksLogID] INT IDENTITY(1,1) PRIMARY KEY,
[CasualTaskID] INT,
[CasualEmployeeID] INT,
[HoursWorkedForDay] DECIMAL(16,2),
[DayOfWork] DATETIME,
[LogEntryDate] DATETIME
)
