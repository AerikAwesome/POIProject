CREATE TABLE [dbo].[Places]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Visible] BIT NULL,
    [Name] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Address] NVARCHAR(50) NULL,
    [Coordinates] [sys].[geography] NULL
)
