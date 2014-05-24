CREATE PROCEDURE [dbo].[getPFSconsults_by_staff]
	@specialistID int
AS
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
