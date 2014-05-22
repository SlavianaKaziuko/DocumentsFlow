CREATE VIEW [dbo].[CFSFormType]
	AS SELECT [ID],[Form] FROM [indiv_form_type]
	WHERE [Relates] LIKE N'PFS'