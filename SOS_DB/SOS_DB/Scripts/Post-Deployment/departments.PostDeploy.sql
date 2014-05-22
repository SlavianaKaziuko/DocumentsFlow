-- =============================================
-- departments table
-- =============================================
IF NOT EXISTS (SELECT TOP(1) [ID] FROM [dbo].[departments])
BEGIN
	SET IDENTITY_INSERT [dbo].[departments] ON
	INSERT INTO [dbo].[departments] ([ID], [Code], [DepartmentName]) VALUES
	 (1, N'А', N'Администрация')
	,(2, N'ОДО', N'Отдел долгосрочной опеки')
	,(3, N'СКЦ', N'Социально-кризисный центр')
	,(4, N'ОПСР', N'Отдел поддержки семьи и ребенка')
	,(5, N'ОП', N'Образовательная программа')
	,(6, N'ИТО', N'Инженерно-технический отдел')
	SET IDENTITY_INSERT [dbo].[departments] OFF
END