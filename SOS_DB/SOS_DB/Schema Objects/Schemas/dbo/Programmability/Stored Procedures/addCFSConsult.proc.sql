CREATE PROCEDURE [dbo].[addCFSConsult]
	@ClientID				INT,
	@SpecialistID			INT, 
	@Datetime				DATETIME,
	@FormTypeID				INT,
	@ContentTypeID			INT,
	@ProblemDiscription		NVARCHAR(300),
	@ConversDiscription		NVARCHAR(MAX),
	@ConversResults			NVARCHAR(MAX),
	@NextSessionDate		DATETIME
AS
	INSERT INTO [dbo].[childrenFS_indiv]([CLientID],[LocalSpecialistID],[DateTime],[FormTypeID],[ContentTypeID],
	[ProblemDiscription],[Discription],[Results],[NextSessionDate]) VALUES 
	 (@ClientID,@SpecialistID,@Datetime,@FormTypeID,@ContentTypeID,@ProblemDiscription,@ConversDiscription,@ConversResults,@NextSessionDate)
	SELECT @@identity
RETURN 0