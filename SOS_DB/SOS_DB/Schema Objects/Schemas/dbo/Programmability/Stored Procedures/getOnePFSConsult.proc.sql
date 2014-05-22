﻿CREATE PROCEDURE [dbo].[getOnePFSConsult]
	@ConsultID int 
AS 
	SELECT pind.[ID] AS N'№',
	s.[Surname] + ' ' + s.[Name] AS N'Специалист',
	pind.[DateTime] AS N'Дата проведения',
	p.[Surname] + ' ' + p.Name + ' ' + p.FatherName AS N'ФИО клиента',
	p.[ID] AS 'ClientID',
	DATEDIFF(yy, p.DateOfBirth, GETDATE()) AS N'Возраст клиента',
	ft.[Form] AS N'Тип формы',
	ft.[ID] AS 'FormID',
	ct.[Content] AS N'Тип содержания',
	ct.[ID] AS 'ContentID',
	[STCGivingInformation] AS N'Предоставление информации',
	[STCConsultation] AS N'Консультация',
	[STCPsychodiagnost] AS N'Психодиагностика',
	[STCTerrapevtSession] AS N'Терапевтическая сессия',
	[STCAnother] AS N'Другая',
	[STPScheduled] AS N'По расписанию',
	[STPAnother] AS N'Другое',
	[ProblemDiscription] AS N'Описание проблемы, запрос',
	[ConversDiscription] AS N'Основные моменты разговора',
	[ConversResults] AS N'Результаты',
	[NextSessionDate] AS N'Дата след.'

	FROM [dbo].[parentsFS_indiv] AS pind
	JOIN [dbo].[parents_of_FS] AS p ON p.[ID] = pind.[CLientID]
	JOIN [dbo].[staff] AS s ON s.[ID] = pind.[LocalSpecialistID]
	JOIN [dbo].[indiv_content_type] AS ct ON ct.[ID] = pind.[ContentTypeID]
	JOIN [dbo].[indiv_form_type] AS ft ON ft.[ID] = pind.[FormTypeID]
	WHERE pind.[ID] = @ConsultID
RETURN 0