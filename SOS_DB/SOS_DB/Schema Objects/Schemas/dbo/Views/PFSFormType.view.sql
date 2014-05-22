CREATE VIEW [dbo].[PFSFormType]
	AS SELECT [ID],[Form] FROM [indiv_form_type]
	WHERE [Relates] LIKE N'PFS'