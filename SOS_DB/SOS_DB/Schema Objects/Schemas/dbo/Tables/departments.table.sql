CREATE TABLE [dbo].[departments]
(
	[ID]				INT				IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL, 
	[Code]				NVARCHAR(10)	NOT NULL,
	[DepartmentName]	NVARCHAR(60)	NOT NULL

	CONSTRAINT [PK_departments_ID] PRIMARY KEY ([ID])
)
