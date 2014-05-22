CREATE TABLE [dbo].[users]
(
	[Username]	NVARCHAR(20)		NOT NULL,
	[Password]	NVARCHAR(20)		NOT NULL,
	[Email]		NVARCHAR(50)		NULL,
	[Welcome]	NVARCHAR(30)		NULL,
	[PersonID]	INT					NULL CONSTRAINT [FK_users_staff_ID] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[staff] ([ID]),
	[Role]		NVARCHAR(5)			NULL,
	[Guid]		uniqueidentifier	NOT NULL DEFAULT(NEWID())

	CONSTRAINT [PK_users_Username] PRIMARY KEY ([Username])
)
