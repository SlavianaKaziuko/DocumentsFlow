CREATE PROCEDURE [dbo].[authorization]
	@Username NVARCHAR(20), 
	@Password NVARCHAR(20)
AS
	IF EXISTS(SELECT [Welcome] FROM [dbo].[users] 
				WHERE [Username] = @Username AND [Password] = @Password)
	BEGIN
		INSERT INTO [dbo].[log] ([Username], [Date], [Action]) VALUES (@Username, GETDATE(), 'Log in')
		SELECT [PersonID], [Role], [Welcome] FROM [dbo].[users] WHERE [Username] = @Username
	END
	
RETURN 0