CREATE TABLE [dbo].[Plan]
(
	[C_Phone_No] INT NOT NULL,
	[B_ID] INT NOT NULL ,
	PRIMARY KEY (C_Phone_No,B_ID),
	CONSTRAINT FK_CustomersPlan FOREIGN KEY (C_Phone_No)
	REFERENCES Customers(C_Phone_No),
	CONSTRAINT FK_BillingPlan FOREIGN KEY (B_ID)
	REFERENCES Billing(B_ID)

)
