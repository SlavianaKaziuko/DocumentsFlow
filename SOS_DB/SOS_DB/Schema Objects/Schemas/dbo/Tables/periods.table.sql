﻿CREATE TABLE [dbo].[periods]
(
	[ID]		INT				IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL, 
	[Name]		NVARCHAR(30)	NULL,
	[StartDate]	DATETIME		NULL,
	[EndtDate]	DATETIME		NULL
)
