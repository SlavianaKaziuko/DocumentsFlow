
IF NOT EXISTS (SELECT TOP(1) [Username] FROM [dbo].[users])
BEGIN
	INSERT INTO [dbo].[users] ([Username],[Password],[PersonID],[Welcome],[Role]) VALUES
	 ('Daddy', '25747425', 1, N'Павел','Super')
	,('Tatiana', 'ShT3', 3, N'Татьяна','User')
	,('Serg', '123456', 2,N'Сергей','Super')
END