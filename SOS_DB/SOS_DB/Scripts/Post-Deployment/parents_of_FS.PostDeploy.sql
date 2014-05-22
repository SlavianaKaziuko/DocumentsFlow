-- =============================================
-- Script Template
-- =============================================
IF NOT EXISTS (SELECT TOP(1) [ID] FROM [dbo].[parents_of_FS])
BEGIN
	SET IDENTITY_INSERT [dbo].[parents_of_FS] ON
	INSERT INTO [dbo].[parents_of_FS] ([ID],[Surname],[Name],[FatherName],[Sex],[DateOfBirth]) VALUES 
	 (1,N'Иванова',N'Анна',N'Юрьевна',N'F','19750208')
	,(2,N'Серова',N'Дарина',N'Антоновна',N'F','19851105')
	SET IDENTITY_INSERT [dbo].[parents_of_FS] OFF
END
