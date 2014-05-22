CREATE PROCEDURE [dbo].[addPFSConsult]
	@ClientID				INT,
	@SpecialistID			INT, 
	@Datetime				DATETIME,
	@STCGivingInformation	CHAR(1),
	@STCConsultation		CHAR(1),
	@STCPsychodiagnost		CHAR(1),
	@STCTerrapevtSession	CHAR(1),
	@STCAnother				NVARCHAR(40),
	@STPScheduled			CHAR(1),
	@STPAnother				NVARCHAR(40),
	@FormTypeID				INT,
	@ContentTypeID			INT,
	@ProblemDiscription		NVARCHAR(300),
	@ConversDiscription		NVARCHAR(MAX),
	@ConversResults			NVARCHAR(MAX),
	@NextSessionDate		DATETIME
AS
	INSERT INTO [dbo].[parentsFS_indiv] ([CLientID],[LocalSpecialistID],[DateTime],[STCGivingInformation],[STCConsultation],[STCPsychodiagnost],[STCTerrapevtSession]
	,[STCAnother],[STPScheduled],[STPAnother],[FormTypeID],[ContentTypeID],[ProblemDiscription],[ConversDiscription],[ConversResults],[NextSessionDate]) VALUES 
	 (@ClientID,@SpecialistID,@Datetime,@STCGivingInformation,@STCConsultation,@STCPsychodiagnost,@STCTerrapevtSession,
	  @STCAnother,@STPScheduled,@STCAnother,@FormTypeID,@ContentTypeID,@ProblemDiscription,@ConversDiscription,@ConversResults,@NextSessionDate)
	SELECT @@identity
RETURN 0