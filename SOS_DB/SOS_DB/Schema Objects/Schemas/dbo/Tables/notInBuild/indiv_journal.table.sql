CREATE TABLE [dbo].[indiv_journal]
(
	[ID]					INT				IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL, 
	[ClientType]			INT				NOT NULL,
	[CLientID]				INT				NULL CONSTRAINT [FK_indiv_journal_CLientID] FOREIGN KEY ([ClientID]) REFERENCES [dbo].[children_of_FS] ([ID]),
	[SpecialistID]			INT				NULL CONSTRAINT [FK_indiv_journal_LocalSpecialistID] FOREIGN KEY ([SpecialistID]) REFERENCES [dbo].[staff] ([ID]),
	[Topic]					NVARCHAR(150)	NULL,
	[Discription]			NVARCHAR(MAX)	NULL,
	[Results]				NVARCHAR(MAX)	NULL,
	[Comments]				NVARCHAR(300)	NULL,
	[NextSessionReasons]	NVARCHAR(300)	NULL,
	[NextSessionDate]		DATETIME		NULL,

	CONSTRAINT [PK_childrenFS_indiv_journal_ID] PRIMARY KEY ([ID])
)
