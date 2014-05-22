-- =============================================
-- Script Template
-- =============================================
IF NOT EXISTS (SELECT TOP(1) [ID] FROM [dbo].[childrenFS_indiv])
BEGIN
	SET IDENTITY_INSERT [dbo].[childrenFS_indiv] ON
	INSERT INTO [dbo].[childrenFS_indiv]([ID],[CLientID],[LocalSpecialistID],[DateTime],[FormTypeID],[ContentTypeID],
	[ProblemDiscription],[Discription],[Results],[NextSessionDate]) VALUES 
	 (1,1,3,'20131123',1,1,N'Problem',N'Discription',N'Result','20131130')
	,(2,1,3,'20131125',1,1,N'Problem1',N'Discription1',N'Result1','20131128')
	,(3,1,3,'20131123',1,1,N'Problem',N'Discription',N'Result','20131130')
	,(4,1,3,'20140425',1,1,N'Problem1',N'Discription1',N'Result1','20131128')
	SET IDENTITY_INSERT [dbo].[childrenFS_indiv] OFF
END