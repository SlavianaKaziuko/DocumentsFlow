CREATE PROCEDURE [dbo].[GetCFSJournal]
	@periodId int 
AS
SELECT 
	res.[FIO] AS N'ФИ ребёнка',
	SUM(CASE res.[FormTypeID] WHEN 1 THEN 1 ELSE 0 END) AS N'Психолог',
	SUM(CASE res.[FormTypeID] WHEN 2 THEN 1 ELSE 0 END) AS N'Психотерапевт',
	SUM(CASE res.[FormTypeID] WHEN 3 THEN 1 ELSE 0 END) AS N'Логопед-дефектолог',
	SUM(CASE res.[FormTypeID] WHEN 4 THEN 1 ELSE 0 END) AS N'Другая',
	SUM(CASE res.[ContentTypeID] WHEN 1 THEN 1 ELSE 0 END) AS N'Эмоциональное состояние',
	SUM(CASE res.[ContentTypeID] WHEN 2 THEN 1 ELSE 0 END) AS N'Познавательная сфера',
	SUM(CASE res.[ContentTypeID] WHEN 3 THEN 1 ELSE 0 END) AS N'Общение',
	SUM(CASE res.[ContentTypeID] WHEN 4 THEN 1 ELSE 0 END) AS N'Насилие',
	SUM(CASE res.[ContentTypeID] WHEN 5 THEN 1 ELSE 0 END) AS N'ДРО',
	SUM(CASE res.[ContentTypeID] WHEN 6 THEN 1 ELSE 0 END) AS N'Другое'
	FROM (SELECT 
	[Surname] + ' ' + p.[Name] AS 'FIO',
	[FormTypeID],
	[ContentTypeID]
	FROM [dbo].[childrenFS_indiv] cons
	JOIN [dbo].[children_of_FS] p ON p.ID = cons.CLientID
	JOIN [dbo].[periods_full] per ON per.[ID] = @periodId
	WHERE cons.[DateTime] BETWEEN per.[StartDate] AND per.[EndtDate]) AS res
	GROUP BY res.[FIO]
RETURN 0