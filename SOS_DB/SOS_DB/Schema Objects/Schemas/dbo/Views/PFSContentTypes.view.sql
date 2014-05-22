CREATE VIEW [dbo].[PFSContentTypes]
	AS SELECT [ID],[Content] FROM [indiv_content_type]
	WHERE [Relates] LIKE N'PFS'