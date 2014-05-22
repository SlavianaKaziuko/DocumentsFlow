-- =============================================
-- employee_post_department table
-- =============================================
IF NOT EXISTS (SELECT TOP(1) [ID] FROM [dbo].[employee_post_department])
BEGIN
	SET IDENTITY_INSERT [dbo].[employee_post_department] ON
	INSERT INTO [dbo].[employee_post_department] ([ID],[EmployeeID],[PostID],[DepartmentID],[DateStart]) VALUES
	 (1, 1, 1, 1, '20080901')
	,(2, 2, 2, 5, '20090401')
	,(3, 3, 3, 4, '20110101')
	,(4, 4, 4, 4, '20100901')
	SET IDENTITY_INSERT [dbo].[employee_post_department] OFF
END