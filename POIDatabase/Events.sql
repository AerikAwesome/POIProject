CREATE TABLE [dbo].[Events]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [PlaceId] INT NULL, 
    [Name] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_Events_ToPlaces] FOREIGN KEY ([PlaceId]) REFERENCES [Places]([Id]) 
)
