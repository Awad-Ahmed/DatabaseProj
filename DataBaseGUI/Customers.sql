CREATE TABLE Customers
(
	[C_PhoneNo] INT NOT NULL , 
    [Land_Line] INT NOT NULL ,
	CONSTRAINT PK_Customers PRIMARY KEY (C_PhoneNo,Land_Line)
)
