CREATE TABLE [dbo].[log]
(
	[ID]		INT				IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL, 
	[Username]	NVARCHAR(20)	NOT NULL CONSTRAINT [FK_log_users_Username] FOREIGN KEY ([Username]) REFERENCES [dbo].[users] ([Username]), 
	[Date]		DATETIME		NOT NULL,
	[Action]	NVARCHAR(100)	NOT NULL
)
