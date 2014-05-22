 CREATE TABLE [dbo].[indiv_form_type]
(
	[ID]		INT				IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL, 
	[Relates]	CHAR(3)			NULL,
	[Form]		NVARCHAR(50)	NULL,

	CONSTRAINT [PK_indiv_form_type_ID] PRIMARY KEY ([ID])
)
