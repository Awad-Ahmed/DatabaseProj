CREATE TABLE [Employees].[TelecomCompany]
(
	[E_ID] INT NOT NULL PRIMARY KEY, 
    [E_Name] VARCHAR(50) NOT NULL, 
    [since] DATE NOT NULL, 
    [FK_D_ID] INT NOT NULL FOREIGN KEY REFERENCES Departments(D_ID)
    
)
