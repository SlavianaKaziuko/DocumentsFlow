CREATE TABLE [dbo].[childrenFS_indiv]
(
	[ID]					INT				IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL, 
	[CLientID]				INT				NULL CONSTRAINT [FK_childrenFS_indiv_CLientID] FOREIGN KEY ([ClientID]) REFERENCES [dbo].[children_of_FS] ([ID]),
	[LocalSpecialistID]		INT				NULL CONSTRAINT [FK_childrenFS_indiv_LocalSpecialistID] FOREIGN KEY ([LocalSpecialistID]) REFERENCES [dbo].[staff] ([ID]),
	[DateTime]				DATETIME		NULL,
--	[InvitedSpecialist]		NVARCHAR(300)	NULL,
--	[InvitedSpecialistType]	NVARCHAR(60)	NULL,
--	[InvitedOrganization]	NVARCHAR(500)	NULL,
	[FormTypeID]			INT				NULL, CONSTRAINT [FK_childrenFS_indiv_FormTypeID] FOREIGN KEY ([FormTypeID]) REFERENCES [dbo].[indiv_form_type] ([ID]),
	[ContentTypeID]			INT				NULL, CONSTRAINT [FK_childrenFS_indiv_ContentTypeID] FOREIGN KEY ([ContentTypeID]) REFERENCES [dbo].[indiv_content_type] ([ID]),
	[ProblemDiscription]	NVARCHAR(150)	NULL,
	[Discription]			NVARCHAR(MAX)	NULL,
	[Results]				NVARCHAR(MAX)	NULL,
	[NextSessionDate]		DATETIME		NULL,

	CONSTRAINT [PK_childrenFS_indiv_ID] PRIMARY KEY ([ID])
)
