-- =============================================
-- Script Template
-- =============================================
IF NOT EXISTS (SELECT TOP(1) [ID] FROM [dbo].[parentsFS_indiv])
BEGIN
	SET IDENTITY_INSERT [dbo].[parentsFS_indiv] ON
	INSERT INTO [dbo].[parentsFS_indiv] ([ID],[CLientID],[LocalSpecialistID],[DateTime],[STCGivingInformation],[STCConsultation],[STCPsychodiagnost],[STCTerrapevtSession],[STCAnother],
	[STPScheduled],[STPAnother],[FormTypeID],[ContentTypeID],[ProblemDiscription],[ConversDiscription],[ConversResults],[NextSessionDate]) VALUES 
	 (1,1,3,'20131115','Y','N','N','N', NULL,'Y',NULL,5,7,N'Problem',N'Conversation',N'Result','20131101')
	,(2,1,3,'20131112','N','Y','N','N', NULL,'Y',NULL,5,7,N'Problem1',N'Conversation1',N'Result1','20131102')
	SET IDENTITY_INSERT [dbo].[parentsFS_indiv] OFF
END
