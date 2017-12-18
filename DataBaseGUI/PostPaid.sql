CREATE TABLE [dbo].[PostPaid]
(
	[B_ID] INT NOT NULL PRIMARY KEY, 
    [LastPayment] DATETIME NULL, 
    [Interval] NCHAR(10) NULL, 
    [Charge] MONEY NULL,
	CONSTRAINT FK_PostPaidISABilling FOREIGN KEY (B_ID)
	REFERENCES Billing(B_ID)
	
)
