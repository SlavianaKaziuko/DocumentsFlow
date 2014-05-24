CREATE PROCEDURE [dbo].[getCFSconsults_by_staff]
	@specialistID int
AS
	SELECT CFSindiv.ID AS 'ID',
		'CFS' AS N'Клиент (тип)',
		CFS.[Surname] AS N'Фамилия',
		CFS.Name AS N'Имя',
		CFS.FatherName AS N'Отчество',
		f.Form AS N'Форма',
		c.Content AS N'Содержание',
		CFSindiv.[DateTime] AS N'Дата'
	FROM childrenFS_indiv as CFSindiv
	JOIN children_of_FS as CFS on CFS.ID = CFSindiv.CLientID
	JOIN indiv_form_type AS f on f.ID = CFSindiv.FormTypeID
	JOIN indiv_content_type AS c on c.ID = CFSindiv.ContentTypeID
	JOIN [dbo].[periods_full] per ON per.[ID] = 0
	WHERE CFSindiv.[DateTime] BETWEEN per.[StartDate] AND per.[EndtDate]
	AND CFSindiv.LocalSpecialistID = @specialistID
RETURN 0
