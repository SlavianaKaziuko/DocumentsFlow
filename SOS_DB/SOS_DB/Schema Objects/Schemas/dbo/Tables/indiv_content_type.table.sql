CREATE TABLE [dbo].[indiv_content_type]
(
	[ID]			INT				IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL, 
	[Relates]		CHAR(3)			NOT NULL,
	[Content]		NVARCHAR(50)	NOT NULL,

	CONSTRAINT [PK_indiv_content_type_ID] PRIMARY KEY ([ID])
)