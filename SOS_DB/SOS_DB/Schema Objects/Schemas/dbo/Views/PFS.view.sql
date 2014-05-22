CREATE VIEW [dbo].[PFS]
	AS SELECT 	[ID], [Surname] + ' ' + Name + ' ' + FatherName AS N'ФИО клиента'
	FROM [parents_of_FS]