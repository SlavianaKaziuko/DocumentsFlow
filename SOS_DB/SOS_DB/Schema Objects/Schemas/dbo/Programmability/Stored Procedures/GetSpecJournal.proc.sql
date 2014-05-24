CREATE PROCEDURE [dbo].[GetSpecJournal]
	@periodId int 
	AS SELECT 
	unionres.[Специалист],
	SUM(unionres.[Психолог очно]) AS N'Психолог очно',
	SUM(unionres.[Психолог по тел]) AS N'Психолог по тел',
	SUM(unionres.[Психолог горячая линия]) AS N'Психолог горячая линия',
	SUM(unionres.[Психотерапевт]) AS N'Психотерапевт',
	SUM(unionres.[Логопед дефектолог]) AS N'Логопед дефектолог',
	SUM(unionres.[Другая]) AS N'Другая',
	SUM(unionres.[Эмоциональное состояние]) AS N'Эмоциональное состояние',
	SUM(unionres.[Познавательная сфера]) AS N'Познавательная сфера',
	SUM(unionres.[Общение]) AS N'Общение',
	SUM(unionres.[Возрастные]) AS N'Возрастные',
	SUM(unionres.[Семейные]) AS N'Семейные',
	SUM(unionres.[Воспитание]) AS N'Воспитание',
	SUM(unionres.[Личностные]) AS N'Личностные',
	SUM(unionres.[Насилие])		AS N'Насилие',
	SUM(unionres.[ДРО]) AS N'ДРО',
	SUM(unionres.[Другое]) AS N'Другое'
	FROM (
	SELECT
		res.LocalSpecialistID,
		res.[FIO] AS N'Специалист',
		SUM(CASE res.[FormTypeID] WHEN 1 THEN 1 ELSE 0 END) AS N'Психолог очно',
		0 AS N'Психолог по тел',
		0 AS N'Психолог горячая линия',
		SUM(CASE res.[FormTypeID] WHEN 2 THEN 1 ELSE 0 END) AS N'Психотерапевт',
		SUM(CASE res.[FormTypeID] WHEN 3 THEN 1 ELSE 0 END) AS N'Логопед дефектолог',
		SUM(CASE res.[FormTypeID] WHEN 4 THEN 1 ELSE 0 END) AS N'Другая',
		SUM(CASE res.[ContentTypeID] WHEN 1 THEN 1 ELSE 0 END) AS N'Эмоциональное состояние',
		SUM(CASE res.[ContentTypeID] WHEN 2 THEN 1 ELSE 0 END) AS N'Познавательная сфера',
		SUM(CASE res.[ContentTypeID] WHEN 3 THEN 1 ELSE 0 END) AS N'Общение',
		0 AS N'Возрастные',
		0 AS N'Семейные',
		0 AS N'Воспитание',
		0 AS N'Личностные',
		SUM(CASE res.[ContentTypeID] WHEN 4 THEN 1 ELSE 0 END) AS N'Насилие',
		SUM(CASE res.[ContentTypeID] WHEN 5 THEN 1 ELSE 0 END) AS N'ДРО',
		SUM(CASE res.[ContentTypeID] WHEN 6 THEN 1 ELSE 0 END) AS N'Другое'
	FROM (SELECT cons.LocalSpecialistID,
		p.[Surname] + ' ' + LEFT(p.[Name],1)+ '. ' + LEFT([FatherName],1)+ '.'  AS 'FIO',
		[FormTypeID],
		[ContentTypeID]
		FROM [dbo].[childrenFS_indiv] cons
		JOIN [dbo].[staff] p ON p.ID = cons.LocalSpecialistID
		JOIN [dbo].[periods_full] per ON per.[ID] = @periodId
		WHERE cons.[DateTime] BETWEEN per.[StartDate] AND per.[EndtDate]) AS res
	GROUP BY res.[FIO],res.LocalSpecialistID
	
	UNION
	
	SELECT 
		res2.LocalSpecialistID,
		res2.[FIO] AS N'Специалист',
		SUM(CASE res2.[FormTypeID] WHEN 5 THEN 1 ELSE 0 END) AS N'Психолог очно',
		SUM(CASE res2.[FormTypeID] WHEN 6 THEN 1 ELSE 0 END) AS N'Психолог по_тел',
		SUM(CASE res2.[FormTypeID] WHEN 7 THEN 1 ELSE 0 END) AS N'Психолог горячая линия',
		SUM(CASE res2.[FormTypeID] WHEN 8 THEN 1 ELSE 0 END) AS N'Психотерапевт',
		0 AS N'Логопед дефектолог',
		SUM(CASE res2.[FormTypeID] WHEN 9 THEN 1 ELSE 0 END) AS N'Другая',
		0 AS N'Эмоциональное состояние',
		0 AS N'Познавательная сфера',
		0 AS N'Общение',
		SUM(CASE res2.[ContentTypeID] WHEN 7 THEN 1 ELSE 0 END) AS N'Возрастные',
		SUM(CASE res2.[ContentTypeID] WHEN 8 THEN 1 ELSE 0 END) AS N'Семейные',
		SUM(CASE res2.[ContentTypeID] WHEN 9 THEN 1 ELSE 0 END) AS N'Воспитание',
		SUM(CASE res2.[ContentTypeID] WHEN 12 THEN 1 ELSE 0 END) AS N'Личностные',
		SUM(CASE res2.[ContentTypeID] WHEN 10 THEN 1 ELSE 0 END) AS N'Насилие',
		SUM(CASE res2.[ContentTypeID] WHEN 11 THEN 1 ELSE 0 END) AS N'ДРО',
		SUM(CASE res2.[ContentTypeID] WHEN 13 THEN 1 ELSE 0 END) AS N'Другое'
	FROM 
		(SELECT cons.LocalSpecialistID,
			p.[Surname] + ' '+ LEFT(p.[Name],1)+ '. ' + LEFT(p.[FatherName],1)+ '.'  AS 'FIO',
			[FormTypeID],
			[ContentTypeID]
		FROM [dbo].[parentsFS_indiv] cons
		JOIN [dbo].[staff] p ON p.ID = cons.LocalSpecialistID
		JOIN [dbo].[periods_full] per ON per.[ID] = @periodId
		WHERE cons.[DateTime] BETWEEN per.[StartDate] AND per.[EndtDate]
		) AS res2
		GROUP BY res2.[FIO],res2.LocalSpecialistID
	) AS unionres
	GROUP BY unionres.LocalSpecialistID, unionres.[Специалист]
RETURN 0