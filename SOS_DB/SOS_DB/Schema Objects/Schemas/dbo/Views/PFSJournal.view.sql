CREATE VIEW [dbo].[PFSJournal]
	AS SELECT 
	res.[FIO] AS N'ФИО матери',
	SUM(CASE res.[FormTypeID] WHEN 5 THEN 1 ELSE 0 END) AS N'Психолог очно',
	SUM(CASE res.[FormTypeID] WHEN 6 THEN 1 ELSE 0 END) AS N'Психолог по тел.',
	SUM(CASE res.[FormTypeID] WHEN 7 THEN 1 ELSE 0 END) AS N'Психолог горячая линия',
	SUM(CASE res.[FormTypeID] WHEN 8 THEN 1 ELSE 0 END) AS N'Психотерапевт',
	SUM(CASE res.[FormTypeID] WHEN 9 THEN 1 ELSE 0 END) AS N'Другая',
	SUM(CASE res.[ContentTypeID] WHEN 7 THEN 1 ELSE 0 END) AS N'Возрастные',
	SUM(CASE res.[ContentTypeID] WHEN 8 THEN 1 ELSE 0 END) AS N'Семейные',
	SUM(CASE res.[ContentTypeID] WHEN 9 THEN 1 ELSE 0 END) AS N'Воспитание',
	SUM(CASE res.[ContentTypeID] WHEN 10 THEN 1 ELSE 0 END) AS N'Насилие',
	SUM(CASE res.[ContentTypeID] WHEN 11 THEN 1 ELSE 0 END) AS N'ДРО',
	SUM(CASE res.[ContentTypeID] WHEN 12 THEN 1 ELSE 0 END) AS N'Личностные',
	SUM(CASE res.[ContentTypeID] WHEN 13 THEN 1 ELSE 0 END) AS N'Другое'
	FROM (SELECT 
	[Surname] + ' ' + [Name] + ' ' + [FatherName] AS 'FIO',
	[FormTypeID],
	[ContentTypeID]
	FROM [dbo].[parentsFS_indiv] cons
	JOIN [dbo].[parents_of_FS] p ON p.ID = cons.CLientID
	) AS res
	GROUP BY res.[FIO]

