CREATE TABLE [Employees].[TelecomCompany]
(
	[E_ID] INT NOT NULL PRIMARY KEY, 
    [No of Hours] INT NOT NULL,
	[Hourly Rate] FLOAT NOT NULL, 
    CHECK([No of Hours] > 0),
	CHECK([Hourly Rate] > 0.0)

    
)
