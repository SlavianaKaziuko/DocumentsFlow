-- =============================================
-- staff table
-- =============================================
IF NOT EXISTS (SELECT TOP(1) [ID] FROM [dbo].[staff])
BEGIN
	SET IDENTITY_INSERT [dbo].[staff] ON
	INSERT INTO [dbo].[staff] ([ID],[Surname],[Name],[FatherName],[DateOfBirth]) VALUES
	 (1, N'Казюко', N'Павел', N'Анатольевич', '19661128')
	,(2, N'Шестопалов', N'Сергей', N'Николаевич', '19750101')
	,(3, N'Шестопалова', N'Татьяна', N'Викторовна', '19750101')
	,(4, N'Шман', N'Татьяна', N'Владимировна', '19780121')
	SET IDENTITY_INSERT [dbo].[staff] OFF
END