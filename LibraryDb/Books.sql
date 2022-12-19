CREATE TABLE [dbo].[Books]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [Title] NVARCHAR(MAX) NULL, 
    [Author] NVARCHAR(50) NULL, 
    [Genre] INT NOT NULL, 
    [Available] BIT NOT NULL, 
    [Image] NVARCHAR(50) NULL

)
