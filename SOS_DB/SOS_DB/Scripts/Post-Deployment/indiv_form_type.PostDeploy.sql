-- =============================================
-- [individ_form_type]
-- =============================================
IF NOT EXISTS (SELECT TOP(1) [ID] FROM [dbo].[indiv_form_type])
BEGIN
	SET IDENTITY_INSERT [dbo].[indiv_form_type] ON
	INSERT INTO [dbo].[indiv_form_type] ([ID], [Relates], [Form])
	VALUES (1, 'CFS', N'Психолог')
	,(2, 'CFS', N'Психотерапевт')
	,(3, 'CFS', N'Логопед-дефектолог')
	,(4, 'CFS', N'Другое')
	,(5, 'PFS', N'Психолог очно')
	,(6, 'PFS', N'Психолог по тел.')
	,(7, 'PFS', N'Психолог горячая линия')
	,(8, 'PFS', N'Психотерапевт')
	,(9, 'PFS', N'Другое')
	SET IDENTITY_INSERT [dbo].[indiv_form_type] OFF
END			
