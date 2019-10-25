CREATE TABLE [dbo].[Schedules]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [EventId] INT NOT NULL, 
    [Name] NVARCHAR(50) NULL, 
    [Enabled] TINYINT NULL, 
    [FrequencyType] INT NULL, 
    [FrequencyInterval] INT NULL, 
    [FrequencySubDayType] INT NULL, 
    [FrequencySubDayInterval] INT NULL, 
    [FrequencyRelativeInterval] INT NULL, 
    [FrequencyRecurrenceFactor] INT NULL, 
    [StartDate] DATETIME2 NULL, 
    [EndDate] DATETIME2 NULL, 
    CONSTRAINT [FK_Schedules_ToEvents] FOREIGN KEY (EventId) REFERENCES Events(Id)
)
