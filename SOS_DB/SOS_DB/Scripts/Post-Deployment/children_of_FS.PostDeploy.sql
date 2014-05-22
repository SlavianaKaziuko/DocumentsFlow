-- =============================================
-- Script Template
-- =============================================
IF NOT EXISTS (SELECT TOP(1) [ID] FROM [dbo].[children_of_FS])
BEGIN
	SET IDENTITY_INSERT [dbo].[children_of_FS] ON
	INSERT INTO [dbo].[children_of_FS] ([ID],[Surname],[Name],[FatherName],[Sex],[DateOfBirth]) VALUES 
	 (1,N'Иванова',N'Анна',N'Юрьевна',N'F','19950208')
	,(2,N'Воянов',N'Дмитрий',N'Антонович',N'M','20001105')
	SET IDENTITY_INSERT [dbo].[children_of_FS] OFF
END