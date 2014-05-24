﻿-- =============================================
-- Script Template
-- =============================================
IF NOT EXISTS (SELECT TOP(1) [ID] FROM [dbo].[periods])
BEGIN
	SET IDENTITY_INSERT [dbo].[periods] ON
	INSERT INTO [dbo].[periods] ([ID],[Name],[StartDate],[EndtDate]) 
	VALUES (1, '01/06/2014-30/06/2014','20140601','20140630')
	,(2, '01/05/2014-31/05/2014','20140501','20140531')
	,(3, '01/04/2014-30/04/2014','20140401','20140430')
	,(4, '01/03/2014-31/03/2014','20140301','20140331')
	,(5, '01/02/2014-28/02/2014','20140201','20140228')
	,(6, '01/01/2014-31/01/2014','20140101','20140131')
	,(7, '01/12/2013-31/12/2013','20131201','20131231')
	,(8, '01/11/2013-30/11/2013','20131101','20131130')
	,(9, '01/10/2013-31/10/2013','20131001','20131031')
	,(10, '01/09/2013-30/09/2013','20130901','20130930')
	SET IDENTITY_INSERT [dbo].[periods] OFF
END
