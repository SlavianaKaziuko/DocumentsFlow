CREATE PROCEDURE [dbo].[updateCFSConsult]
	@ID						INT,
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
	UPDATE [dbo].[childrenFS_indiv]
	SET [CLientID] = @ClientID,
	[LocalSpecialistID] = @SpecialistID,
	[DateTime] = @Datetime,
	[FormTypeID] = @FormTypeID,
	[ContentTypeID] = @ContentTypeID,	
	[ProblemDiscription] = @ProblemDiscription,
	[Discription] = @ConversDiscription,
	[Results] = @ConversResults,
	[NextSessionDate] = @NextSessionDate
	WHERE [ID] = @ID
	SELECT @@identity
RETURN 0