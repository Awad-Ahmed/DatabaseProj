﻿CREATE TABLE [dbo].[Charges]
(
	[FK_B_ID] INT NOT NULL FOREIGN KEY REFERENCES Billing(B_ID), 
    [FK_PP_NO] INT NOT NULL FOREIGN KEY REFERENCES B(B_ID), 
    PRIMARY KEY ([FK_B_ID], [FK_PP_NO])
)