CREATE TABLE [dbo].[Phone_Plans]
(
	[PP_NO] INT NOT NULL PRIMARY KEY, 
    [PP Name] VARCHAR(50) NOT NULL UNIQUE, 
    [PP Price] FLOAT NOT NULL
    
)
