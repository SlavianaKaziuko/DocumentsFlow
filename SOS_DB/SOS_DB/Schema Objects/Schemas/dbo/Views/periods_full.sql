CREATE VIEW [dbo].[periods_full]
	AS SELECT * FROM [dbo].[periods]
	UNION ALL
	SELECT 0, 
		'01/01/2014-Today',
		'20140101',
		GETDATE()
