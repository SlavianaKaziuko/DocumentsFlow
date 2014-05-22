CREATE VIEW [dbo].[CFSContentTypes]
	AS SELECT [ID],[Content] FROM [indiv_content_type]
	WHERE [Relates] LIKE N'CFS'