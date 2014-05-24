CREATE PROCEDURE [dbo].[consults_by_staff]
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
	UNION
	SELECT PFSindiv.ID AS 'ID',
		'PFS' AS N'Клиент (тип)',
		PFS.[Surname] AS N'Фамилия',
		PFS.Name AS N'Имя',
		PFS.FatherName AS N'Отчество',
		f.Form AS N'Форма',
		c.Content AS N'Содержание',
		PFSindiv.[DateTime] AS N'Дата'
	FROM parentsFS_indiv as PFSindiv
	JOIN parents_of_FS as PFS on PFS.ID = PFSindiv.CLientID
	JOIN indiv_form_type AS f on f.ID = PFSindiv.FormTypeID
	JOIN indiv_content_type AS c on c.ID = PFSindiv.ContentTypeID
	JOIN [dbo].[periods_full] per ON per.[ID] = 0
	WHERE PFSindiv.[DateTime] BETWEEN per.[StartDate] AND per.[EndtDate]
	AND PFSindiv.LocalSpecialistID = @specialistID
RETURN 0
