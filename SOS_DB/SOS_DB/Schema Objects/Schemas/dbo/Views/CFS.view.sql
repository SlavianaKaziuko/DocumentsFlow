CREATE VIEW [dbo].[CFS]
	AS SELECT 	[ID],[Surname] + ' ' + Name + ' ' + FatherName AS N'ФИО клиента'
	FROM [children_of_FS]