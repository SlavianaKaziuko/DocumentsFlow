CREATE TABLE [dbo].[parentsFS_indiv]
(
	[ID]					INT				IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL, 
	[CLientID]				INT				NULL CONSTRAINT [FK_parentsFS_indiv_CLientID] FOREIGN KEY ([ClientID]) REFERENCES [dbo].[parents_of_FS] ([ID]),
	[LocalSpecialistID]		INT				NULL CONSTRAINT [FK_parentsFS_indiv_LocalSpecialistID] FOREIGN KEY ([LocalSpecialistID]) REFERENCES [dbo].[staff] ([ID]),
	[DateTime]				DATETIME		NULL,
--	[InvitedSpecialist]		NVARCHAR(300)	NULL,
--	[InvitedSpecialistType]	NVARCHAR(60)	NULL,
--	[InvitedOrganization]	NVARCHAR(500)	NULL,
	[STCGivingInformation]	CHAR(1)			NULL,
	[STCConsultation]		CHAR(1)			NULL,
	[STCPsychodiagnost]		CHAR(1)			NULL,
	[STCTerrapevtSession]	CHAR(1)			NULL,
	[STCAnother]			NVARCHAR(40)	NULL,
	[STPScheduled]			CHAR(1)			NULL,
	[STPAnother]			NVARCHAR(100)	NULL,
	[FormTypeID]			INT				NULL, CONSTRAINT [FK_parentsFS_indiv_FormTypeID] FOREIGN KEY ([FormTypeID]) REFERENCES [dbo].[indiv_form_type] ([ID]),
	[ContentTypeID]			INT				NULL, CONSTRAINT [FK_parentsFS_indiv_ContentTypeID] FOREIGN KEY ([ContentTypeID]) REFERENCES [dbo].[indiv_content_type] ([ID]),
	[ProblemDiscription]	NVARCHAR(300)	NULL,
	[ConversDiscription]	NVARCHAR(MAX)	NULL,
	[ConversResults]		NVARCHAR(MAX)	NULL,
	[NextSessionDate]		DATETIME		NULL,

	CONSTRAINT [PK_parentsFS_indiv_ID] PRIMARY KEY ([ID])
)
