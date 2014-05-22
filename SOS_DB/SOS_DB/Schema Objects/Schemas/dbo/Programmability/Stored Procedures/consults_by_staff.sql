CREATE PROCEDURE [dbo].[consults_by_staff]
	@specialistID int
AS
	SELECT 'CFS' AS N'Клиент (тип)',
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
	WHERE CFSindiv.LocalSpecialistID = @specialistID
	UNION
	SELECT 'PFS' AS N'Клиент (тип)',
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
	WHERE PFSindiv.LocalSpecialistID = @specialistID
RETURN 0
