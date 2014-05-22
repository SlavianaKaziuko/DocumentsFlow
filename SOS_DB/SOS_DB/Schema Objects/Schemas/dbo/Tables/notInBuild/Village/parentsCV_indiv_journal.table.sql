CREATE TABLE [dbo].[parentsCV_indiv_journal]
(
	[ID]					INT				IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL, 
	[CLientID]				INT				NULL CONSTRAINT [FK_parentsCV_indiv_journal_CLientID] FOREIGN KEY ([ClientID]) REFERENCES [dbo].[parents_of_CV] ([ID]),

	CONSTRAINT [PK_parentsCV_indiv_journal_ID] PRIMARY KEY ([ID])
)
