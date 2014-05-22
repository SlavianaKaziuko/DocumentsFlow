CREATE TABLE [dbo].[employee_post_department]
(
	[ID]			INT				IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL, 
	[EmployeeID]	INT				NULL CONSTRAINT [FK_posts_EmployeeID] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[staff] ([ID]),
	[PostID]		INT				NULL CONSTRAINT [FK_posts_PostID] FOREIGN KEY ([PostID]) REFERENCES [dbo].[posts] ([ID]),
	[DepartmentID]	INT				NULL CONSTRAINT [FK_posts_DepartmentID] FOREIGN KEY ([DepartmentID]) REFERENCES [dbo].[departments] ([ID]),
	[DateStart]		DATETIME		NULL
	
	CONSTRAINT [PK_employee_post_department_ID] PRIMARY KEY ([ID])
)
