CREATE TABLE [dbo].[parents_of_CV]
(
	[ID]			INT				IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL, 
	[Surname]		NVARCHAR(30)	NULL,
	[Name]			NVARCHAR(30)	NULL,
	[FatherName]	NVARCHAR(30)	NULL,
	[Sex]			CHAR(1)			NULL,
	[DateOfBirth]	DATETIME		NOT NULL,
	[HouseID]		INT				NOT NULL CONSTRAINT [FK_parents_of_CV_HouseID] FOREIGN KEY ([HouseID]) REFERENCES [dbo].[houses] ([ID])

	CONSTRAINT [PK_parents_of_CV_ID] PRIMARY KEY ([ID])

)
