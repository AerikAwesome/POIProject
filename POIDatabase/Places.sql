CREATE TABLE [dbo].[Places]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Type] INT NULL, 
    [Name] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Coordinates] [sys].[geography] NULL
)
