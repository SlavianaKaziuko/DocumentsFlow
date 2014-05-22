-- =============================================
-- indiv_content_type table
-- =============================================
IF NOT EXISTS (SELECT TOP(1) [ID] FROM [dbo].[indiv_content_type])
BEGIN
	SET IDENTITY_INSERT [dbo].[indiv_content_type] ON
	INSERT INTO [dbo].[indiv_content_type] ([ID], [Relates], [Content]) 
	VALUES (1, 'CFS', N'Эмоциональное состояние')
	,(2, 'CFS', N'Познавательная сфера')
	,(3, 'CFS', N'Общение')
	,(4, 'CFS', N'Насилие')
	,(5, 'CFS', N'ДРО')
	,(6, 'CFS', N'Другое')
	,(7, 'PFS', N'Возрастные')
	,(8, 'PFS', N'Семейные')
	,(9, 'PFS', N'Воспитание')
	,(10, 'PFS', N'Насилие')
	,(11, 'PFS', N'ДРО')
	,(12, 'PFS', N'Личностные')
	,(13, 'PFS', N'Другое')
	SET IDENTITY_INSERT [dbo].[indiv_content_type] OFF
END
					