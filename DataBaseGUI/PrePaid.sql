CREATE TABLE [dbo].[PrePaid]
(
	[B_ID] INT NOT NULL PRIMARY KEY, 
    [Balance] MONEY NULL,
	CONSTRAINT FK_PrePaidISABilling Foreign Key (B_ID)
	REFERENCES Billing(B_ID)

)
