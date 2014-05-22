﻿CREATE VIEW [dbo].[CFSConsult]
	AS SELECT cind.[ID] AS N'№',
	s.[Surname] + ' ' + s.[Name] AS N'Специалист',
	cind.[DateTime] AS N'Дата проведения',
	c.[Surname] + ' ' + c.Name + ' ' + c.FatherName AS N'ФИО клиента',
	DATEDIFF(yy, c.DateOfBirth, GETDATE()) AS N'Возраст клиента',
	ft.[Form] AS N'Тип формы',
	ct.[Content] AS N'Тип содержания',
	cind.[ProblemDiscription] AS N'Описание проблемы, запрос',
	cind.[Discription] AS N'Основные моменты разговора',
	cind.[Results] AS N'Результаты',
	cind.[NextSessionDate] AS N'Дата след.'

	FROM [dbo].[childrenFS_indiv] AS cind
	JOIN [dbo].[children_of_FS] AS c ON c.[ID] = cind.[CLientID]
	JOIN [dbo].[staff] AS s ON s.[ID] = cind.[LocalSpecialistID]
	JOIN [dbo].[indiv_content_type] AS ct ON ct.[ID] = cind.[ContentTypeID]
	JOIN [dbo].[indiv_form_type] AS ft ON ft.[ID] = cind.[FormTypeID]