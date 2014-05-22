CREATE TABLE [dbo].[parents_of_FS]
(
	[ID]			INT				IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL, 
	[Surname]		NVARCHAR(30)	NULL,
	[Name]			NVARCHAR(30)	NULL,
	[FatherName]	NVARCHAR(30)	NULL,
	[Sex]			CHAR(1)			NULL,
	[DateOfBirth]	DATETIME		NOT NULL,

	CONSTRAINT [PK_parents_of_FS_ID] PRIMARY KEY ([ID])
)
