CREATE TABLE [dbo].[staff]
(
	[ID]			INT				IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
	[Surname]		NVARCHAR(30)	NULL,
	[Name]			NVARCHAR(30)	NULL,
	[FatherName]	NVARCHAR(30)	NULL,
	[Sex]			CHAR(1)			NULL,
	[DateOfBirth]	DATETIME		NULL,

	CONSTRAINT [PK_staff_ID] PRIMARY KEY ([ID])
)

--	CONSTRAINT [XPKstaff] PRIMARY KEY NONCLUSTERED 
--	(
--	[ID_employee] ASC
--	)	
--	WITH (PAD_INDEX  = OFF, 
--		STATISTICS_NORECOMPUTE  = OFF, 
--		IGNORE_DUP_KEY = OFF, 
--		ALLOW_ROW_LOCKS  = ON, 
--		ALLOW_PAGE_LOCKS  = ON
--	) ON [PRIMARY]
--)


