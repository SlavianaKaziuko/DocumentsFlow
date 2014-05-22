-- =============================================
-- posts table
-- =============================================
IF NOT EXISTS (SELECT TOP(1) [ID] FROM [dbo].[employee_post_department])
BEGIN
	SET IDENTITY_INSERT [dbo].[posts] ON
	INSERT INTO [dbo].[posts] ([ID], [PostName]) VALUES
	 (1, N'директор')
	,(2, N'заместитель директора')
	,(3, N'психолог')
	,(4, N'руководитель ОПСР')
	SET IDENTITY_INSERT [dbo].[posts] OFF
END