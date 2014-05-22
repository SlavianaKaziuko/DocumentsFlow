CREATE PROCEDURE [dbo].[addCFS]
	@Surname NVARCHAR(30), 
	@Name NVARCHAR(30),
	@FartherName NVARCHAR(30),
	@Sex CHAR(1),
	@DateOFB DATETIME
AS
	INSERT INTO [dbo].[parents_of_FS] ([Surname],[Name],[FatherName],[Sex],[DateOfBirth]) 
	VALUES (@Surname,@Name,@FartherName,@Sex,@DateOFB)
RETURN 0