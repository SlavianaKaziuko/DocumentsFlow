CREATE PROCEDURE [dbo].[updatePFSConsult]
	@ID						INT,
	@ClientID				INT,
	@SpecialistID			INT, 
	@Datetime				DATETIME,
	@STCGivingInformation	CHAR(1),
	@STCConsultation		CHAR(1),
	@STCPsychodiagnost		CHAR(1),
	@STCTerrapevtSession	CHAR(1),
	@STCAnother				NVARCHAR(40) = '',
	@STPScheduled			CHAR(1),
	@STPAnother				NVARCHAR(40) = '',
	@FormTypeID				INT,
	@ContentTypeID			INT,
	@ProblemDiscription		NVARCHAR(300),
	@ConversDiscription		NVARCHAR(MAX),
	@ConversResults			NVARCHAR(MAX),
	@NextSessionDate		DATETIME
AS
	UPDATE [dbo].[parentsFS_indiv]
	SET [CLientID]=@ClientID,
	[LocalSpecialistID]=@SpecialistID,
	[DateTime]=@Datetime,
	[STCGivingInformation]=@STCGivingInformation,
	[STCConsultation]=@STCConsultation,
	[STCPsychodiagnost]=@STCPsychodiagnost,
	[STCTerrapevtSession]=@STCTerrapevtSession,
	[STCAnother]=@STCAnother,
	[STPScheduled]=@STPScheduled,
	[STPAnother]=@STCAnother,
	[FormTypeID]=@FormTypeID,
	[ContentTypeID]=@ContentTypeID,
	[ProblemDiscription]=@ProblemDiscription,
	[ConversDiscription]=@ConversDiscription,
	[ConversResults]=@ConversResults,
	[NextSessionDate]=@NextSessionDate
	WHERE [ID] = @ID
	SELECT @@identity
RETURN 0