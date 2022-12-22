/*
 Navicat Premium Data Transfer

 Source Server         : DESKTOP-Q4OJVS5
 Source Server Type    : SQL Server
 Source Server Version : 15002000
 Source Host           : DESKTOP-Q4OJVS5:1433
 Source Catalog        : Management
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 15002000
 File Encoding         : 65001

 Date: 19/08/2022 04:06:49
*/


-- ----------------------------
-- Table structure for Enrollment
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Enrollment]') AND type IN ('U'))
	DROP TABLE [dbo].[Enrollment]
GO

CREATE TABLE [dbo].[Enrollment] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [Teacher] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Subject] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Student] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Enrollment] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Enrollment
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Enrollment] ON
GO

INSERT INTO [dbo].[Enrollment] ([Id], [Teacher], [Subject], [Student]) VALUES (N'1', N'Arthur', N'Math', N'Veron Mark')
GO

INSERT INTO [dbo].[Enrollment] ([Id], [Teacher], [Subject], [Student]) VALUES (N'2', N'Chen', N'English', N'Mark Veron')
GO

INSERT INTO [dbo].[Enrollment] ([Id], [Teacher], [Subject], [Student]) VALUES (N'4', N'Google M', N'English', N'Yahoo G')
GO

INSERT INTO [dbo].[Enrollment] ([Id], [Teacher], [Subject], [Student]) VALUES (N'5', N'Arthur Chen', N'English', N'Google Y')
GO

INSERT INTO [dbo].[Enrollment] ([Id], [Teacher], [Subject], [Student]) VALUES (N'1004', N'Google M', N'English', N'Google Y')
GO

SET IDENTITY_INSERT [dbo].[Enrollment] OFF
GO


-- ----------------------------
-- Table structure for Semester
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Semester]') AND type IN ('U'))
	DROP TABLE [dbo].[Semester]
GO

CREATE TABLE [dbo].[Semester] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [ClientId] int  NULL,
  [Name] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [FromDate] datetime  NULL,
  [EndDate] datetime  NULL,
  [Default] bit  NULL,
  [DateCreated] datetime  NULL,
  [DateModified] datetime  NULL,
  [Weeks] int  NULL
)
GO

ALTER TABLE [dbo].[Semester] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Semester
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Semester] ON
GO

INSERT INTO [dbo].[Semester] ([Id], [ClientId], [Name], [FromDate], [EndDate], [Default], [DateCreated], [DateModified], [Weeks]) VALUES (N'1', N'1', N'1', N'2022-04-20 00:00:00.000', N'2022-12-20 00:00:00.000', N'1', N'2022-08-05 00:00:00.000', N'2022-08-05 00:00:00.000', N'80')
GO

SET IDENTITY_INSERT [dbo].[Semester] OFF
GO


-- ----------------------------
-- Table structure for SemesterTeacherSubject
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SemesterTeacherSubject]') AND type IN ('U'))
	DROP TABLE [dbo].[SemesterTeacherSubject]
GO

CREATE TABLE [dbo].[SemesterTeacherSubject] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [ClientId] int  NULL,
  [SemesterId] int  NULL,
  [TeacherId] int  NULL,
  [SubjectId] int  NULL
)
GO

ALTER TABLE [dbo].[SemesterTeacherSubject] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of SemesterTeacherSubject
-- ----------------------------
SET IDENTITY_INSERT [dbo].[SemesterTeacherSubject] ON
GO

INSERT INTO [dbo].[SemesterTeacherSubject] ([Id], [ClientId], [SemesterId], [TeacherId], [SubjectId]) VALUES (N'2', N'1', N'1', N'2', N'2')
GO

INSERT INTO [dbo].[SemesterTeacherSubject] ([Id], [ClientId], [SemesterId], [TeacherId], [SubjectId]) VALUES (N'2002', N'1', N'1', N'1', N'1')
GO

INSERT INTO [dbo].[SemesterTeacherSubject] ([Id], [ClientId], [SemesterId], [TeacherId], [SubjectId]) VALUES (N'3008', N'1', N'1', N'2', N'4')
GO

INSERT INTO [dbo].[SemesterTeacherSubject] ([Id], [ClientId], [SemesterId], [TeacherId], [SubjectId]) VALUES (N'3012', N'1', N'1', N'1022', N'4')
GO

INSERT INTO [dbo].[SemesterTeacherSubject] ([Id], [ClientId], [SemesterId], [TeacherId], [SubjectId]) VALUES (N'3015', N'1', N'1', N'1022', N'1')
GO

SET IDENTITY_INSERT [dbo].[SemesterTeacherSubject] OFF
GO


-- ----------------------------
-- Table structure for StudentAbsense
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentAbsense]') AND type IN ('U'))
	DROP TABLE [dbo].[StudentAbsense]
GO

CREATE TABLE [dbo].[StudentAbsense] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [ClientId] int  NULL,
  [StudentId] int  NULL,
  [Date] date  NULL,
  [AbsenseType] int  NULL,
  [AuditDate] datetime  NULL,
  [Note] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Teacher] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Subject] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[StudentAbsense] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of StudentAbsense
-- ----------------------------
SET IDENTITY_INSERT [dbo].[StudentAbsense] ON
GO

INSERT INTO [dbo].[StudentAbsense] ([Id], [ClientId], [StudentId], [Date], [AbsenseType], [AuditDate], [Note], [Teacher], [Subject]) VALUES (N'1', N'1', N'4', N'2022-08-19', N'1', N'2022-12-12 00:00:00.000', N'1111111111', N'Arthur Chen', N'English')
GO

INSERT INTO [dbo].[StudentAbsense] ([Id], [ClientId], [StudentId], [Date], [AbsenseType], [AuditDate], [Note], [Teacher], [Subject]) VALUES (N'2', N'1', N'4', N'2022-08-19', N'1', N'2020-12-12 00:00:00.000', N'1111111111', N'Arthur Chen', N'English')
GO

INSERT INTO [dbo].[StudentAbsense] ([Id], [ClientId], [StudentId], [Date], [AbsenseType], [AuditDate], [Note], [Teacher], [Subject]) VALUES (N'3', N'2', N'4', N'2022-08-19', N'1', N'2021-12-12 00:00:00.000', N'1111111111', N'Arthur Chen', N'English')
GO

INSERT INTO [dbo].[StudentAbsense] ([Id], [ClientId], [StudentId], [Date], [AbsenseType], [AuditDate], [Note], [Teacher], [Subject]) VALUES (N'1002', N'1', N'4', N'2022-08-19', N'1', N'2022-08-18 23:17:45.297', N'2222222222', N'Google M', N'English')
GO

INSERT INTO [dbo].[StudentAbsense] ([Id], [ClientId], [StudentId], [Date], [AbsenseType], [AuditDate], [Note], [Teacher], [Subject]) VALUES (N'1003', N'1', N'5', N'2022-08-19', N'1', N'2022-08-18 23:17:59.117', N'2222222222', N'Google M', N'English')
GO

INSERT INTO [dbo].[StudentAbsense] ([Id], [ClientId], [StudentId], [Date], [AbsenseType], [AuditDate], [Note], [Teacher], [Subject]) VALUES (N'1004', N'1', N'4', N'2022-08-20', N'3', N'2022-08-19 01:45:05.547', N'3333', N'Google M', N'English')
GO

INSERT INTO [dbo].[StudentAbsense] ([Id], [ClientId], [StudentId], [Date], [AbsenseType], [AuditDate], [Note], [Teacher], [Subject]) VALUES (N'1005', N'1', N'5', N'2022-08-20', N'3', N'2022-08-19 01:45:05.593', N'5555', N'Google M', N'English')
GO

SET IDENTITY_INSERT [dbo].[StudentAbsense] OFF
GO


-- ----------------------------
-- Table structure for Subject
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Subject]') AND type IN ('U'))
	DROP TABLE [dbo].[Subject]
GO

CREATE TABLE [dbo].[Subject] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [Name] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [DateCreated] datetime  NULL,
  [DateModified] datetime  NULL,
  [PeriodCount] int  NULL
)
GO

ALTER TABLE [dbo].[Subject] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Subject
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Subject] ON
GO

INSERT INTO [dbo].[Subject] ([Id], [Name], [DateCreated], [DateModified], [PeriodCount]) VALUES (N'1', N'English', N'2022-07-20 00:00:00.000', N'2022-07-30 00:00:00.000', N'2')
GO

INSERT INTO [dbo].[Subject] ([Id], [Name], [DateCreated], [DateModified], [PeriodCount]) VALUES (N'2', N'Maths', N'2022-05-30 00:00:00.000', N'2022-05-20 00:00:00.000', N'3')
GO

INSERT INTO [dbo].[Subject] ([Id], [Name], [DateCreated], [DateModified], [PeriodCount]) VALUES (N'4', N'Google', N'2022-08-04 12:26:44.277', N'2022-08-04 12:26:44.277', N'3')
GO

INSERT INTO [dbo].[Subject] ([Id], [Name], [DateCreated], [DateModified], [PeriodCount]) VALUES (N'1003', N'Language', N'2022-08-04 12:26:44.277', N'2022-08-04 12:26:44.277', N'3')
GO

SET IDENTITY_INSERT [dbo].[Subject] OFF
GO


-- ----------------------------
-- Table structure for sysdiagrams
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[sysdiagrams]') AND type IN ('U'))
	DROP TABLE [dbo].[sysdiagrams]
GO

CREATE TABLE [dbo].[sysdiagrams] (
  [name] sysname  NOT NULL,
  [principal_id] int  NOT NULL,
  [diagram_id] int  IDENTITY(1,1) NOT NULL,
  [version] int  NULL,
  [definition] varbinary(max)  NULL
)
GO

ALTER TABLE [dbo].[sysdiagrams] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for User
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type IN ('U'))
	DROP TABLE [dbo].[User]
GO

CREATE TABLE [dbo].[User] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [ClientId] int  NULL,
  [FirstName] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [LastName] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Title] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Email] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Password] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [DateCreated] datetime  NULL,
  [DateModified] datetime  NULL
)
GO

ALTER TABLE [dbo].[User] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of User
-- ----------------------------
SET IDENTITY_INSERT [dbo].[User] ON
GO

INSERT INTO [dbo].[User] ([Id], [ClientId], [FirstName], [LastName], [Title], [Email], [Password], [DateCreated], [DateModified]) VALUES (N'1', N'1', N'Google', N'M', N'teacher', N'g@gmail.com', N'a', N'2022-02-22 00:00:00.000', N'2022-02-22 00:00:00.000')
GO

INSERT INTO [dbo].[User] ([Id], [ClientId], [FirstName], [LastName], [Title], [Email], [Password], [DateCreated], [DateModified]) VALUES (N'2', N'2', N'Veron', N'Mark', N'admin', N'a@gmail.com', N'b', N'2022-05-20 00:00:00.000', N'2022-05-20 00:00:00.000')
GO

INSERT INTO [dbo].[User] ([Id], [ClientId], [FirstName], [LastName], [Title], [Email], [Password], [DateCreated], [DateModified]) VALUES (N'4', N'4', N'Yahoo', N'G', N'student', N'b@gmail.com', N'c', N'2002-05-30 00:00:00.000', N'2022-05-11 00:00:00.000')
GO

INSERT INTO [dbo].[User] ([Id], [ClientId], [FirstName], [LastName], [Title], [Email], [Password], [DateCreated], [DateModified]) VALUES (N'5', N'5', N'Google', N'Y', N'student', N'c@gmail.com', N'd', N'2022-05-11 00:00:00.000', N'2022-01-30 00:00:00.000')
GO

INSERT INTO [dbo].[User] ([Id], [ClientId], [FirstName], [LastName], [Title], [Email], [Password], [DateCreated], [DateModified]) VALUES (N'1020', N'6', N'Teacher', N'1', N'teacher', N'd@gmail.com', N'e', N'2022-05-11 00:00:00.000', N'2022-05-11 00:00:00.000')
GO

INSERT INTO [dbo].[User] ([Id], [ClientId], [FirstName], [LastName], [Title], [Email], [Password], [DateCreated], [DateModified]) VALUES (N'1021', N'7', N'Teacher', N'2', N'teacher', N'e@gmail.com', N'f', N'2022-05-11 00:00:00.000', N'2022-05-11 00:00:00.000')
GO

INSERT INTO [dbo].[User] ([Id], [ClientId], [FirstName], [LastName], [Title], [Email], [Password], [DateCreated], [DateModified]) VALUES (N'1022', N'8', N'Teacher', N'3', N'teacher', N'f@gmail.com', N'g', N'2022-05-11 00:00:00.000', N'2022-05-11 00:00:00.000')
GO

SET IDENTITY_INSERT [dbo].[User] OFF
GO


-- ----------------------------
-- procedure structure for sp_upgraddiagrams
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_upgraddiagrams]') AND type IN ('FN', 'FS', 'FT', 'IF', 'TF'))
	DROP PROCEDURE[dbo].[sp_upgraddiagrams]
GO

CREATE PROCEDURE [dbo].[sp_upgraddiagrams]
	AS
	BEGIN
		IF OBJECT_ID(N'dbo.sysdiagrams') IS NOT NULL
			return 0;
	
		CREATE TABLE dbo.sysdiagrams
		(
			name sysname NOT NULL,
			principal_id int NOT NULL,	-- we may change it to varbinary(85)
			diagram_id int PRIMARY KEY IDENTITY,
			version int,
	
			definition varbinary(max)
			CONSTRAINT UK_principal_name UNIQUE
			(
				principal_id,
				name
			)
		);


		/* Add this if we need to have some form of extended properties for diagrams */
		/*
		IF OBJECT_ID(N'dbo.sysdiagram_properties') IS NULL
		BEGIN
			CREATE TABLE dbo.sysdiagram_properties
			(
				diagram_id int,
				name sysname,
				value varbinary(max) NOT NULL
			)
		END
		*/

		IF OBJECT_ID(N'dbo.dtproperties') IS NOT NULL
		begin
			insert into dbo.sysdiagrams
			(
				[name],
				[principal_id],
				[version],
				[definition]
			)
			select	 
				convert(sysname, dgnm.[uvalue]),
				DATABASE_PRINCIPAL_ID(N'dbo'),			-- will change to the sid of sa
				0,							-- zero for old format, dgdef.[version],
				dgdef.[lvalue]
			from dbo.[dtproperties] dgnm
				inner join dbo.[dtproperties] dggd on dggd.[property] = 'DtgSchemaGUID' and dggd.[objectid] = dgnm.[objectid]	
				inner join dbo.[dtproperties] dgdef on dgdef.[property] = 'DtgSchemaDATA' and dgdef.[objectid] = dgnm.[objectid]
				
			where dgnm.[property] = 'DtgSchemaNAME' and dggd.[uvalue] like N'_EA3E6268-D998-11CE-9454-00AA00A3F36E_' 
			return 2;
		end
		return 1;
	END
GO


-- ----------------------------
-- procedure structure for sp_helpdiagrams
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_helpdiagrams]') AND type IN ('FN', 'FS', 'FT', 'IF', 'TF'))
	DROP PROCEDURE[dbo].[sp_helpdiagrams]
GO

CREATE PROCEDURE [dbo].[sp_helpdiagrams]
	(
		@diagramname sysname = NULL,
		@owner_id int = NULL
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		DECLARE @user sysname
		DECLARE @dboLogin bit
		EXECUTE AS CALLER;
			SET @user = USER_NAME();
			SET @dboLogin = CONVERT(bit,IS_MEMBER('db_owner'));
		REVERT;
		SELECT
			[Database] = DB_NAME(),
			[Name] = name,
			[ID] = diagram_id,
			[Owner] = USER_NAME(principal_id),
			[OwnerID] = principal_id
		FROM
			sysdiagrams
		WHERE
			(@dboLogin = 1 OR USER_NAME(principal_id) = @user) AND
			(@diagramname IS NULL OR name = @diagramname) AND
			(@owner_id IS NULL OR principal_id = @owner_id)
		ORDER BY
			4, 5, 1
	END
GO


-- ----------------------------
-- procedure structure for sp_helpdiagramdefinition
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_helpdiagramdefinition]') AND type IN ('FN', 'FS', 'FT', 'IF', 'TF'))
	DROP PROCEDURE[dbo].[sp_helpdiagramdefinition]
GO

CREATE PROCEDURE [dbo].[sp_helpdiagramdefinition]
	(
		@diagramname 	sysname,
		@owner_id	int	= null 		
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		set nocount on

		declare @theId 		int
		declare @IsDbo 		int
		declare @DiagId		int
		declare @UIDFound	int
	
		if(@diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner');
		if(@owner_id is null)
			select @owner_id = @theId;
		revert; 
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname;
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId ))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end

		select version, definition FROM dbo.sysdiagrams where diagram_id = @DiagId ; 
		return 0
	END
GO


-- ----------------------------
-- procedure structure for sp_creatediagram
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_creatediagram]') AND type IN ('FN', 'FS', 'FT', 'IF', 'TF'))
	DROP PROCEDURE[dbo].[sp_creatediagram]
GO

CREATE PROCEDURE [dbo].[sp_creatediagram]
	(
		@diagramname 	sysname,
		@owner_id		int	= null, 	
		@version 		int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId int
		declare @retval int
		declare @IsDbo	int
		declare @userName sysname
		if(@version is null or @diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID(); 
		select @IsDbo = IS_MEMBER(N'db_owner');
		revert; 
		
		if @owner_id is null
		begin
			select @owner_id = @theId;
		end
		else
		begin
			if @theId <> @owner_id
			begin
				if @IsDbo = 0
				begin
					RAISERROR (N'E_INVALIDARG', 16, 1);
					return -1
				end
				select @theId = @owner_id
			end
		end
		-- next 2 line only for test, will be removed after define name unique
		if EXISTS(select diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @diagramname)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end
	
		insert into dbo.sysdiagrams(name, principal_id , version, definition)
				VALUES(@diagramname, @theId, @version, @definition) ;
		
		select @retval = @@IDENTITY 
		return @retval
	END
GO


-- ----------------------------
-- procedure structure for sp_renamediagram
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_renamediagram]') AND type IN ('FN', 'FS', 'FT', 'IF', 'TF'))
	DROP PROCEDURE[dbo].[sp_renamediagram]
GO

CREATE PROCEDURE [dbo].[sp_renamediagram]
	(
		@diagramname 		sysname,
		@owner_id		int	= null,
		@new_diagramname	sysname
	
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @DiagIdTarg		int
		declare @u_name			sysname
		if((@diagramname is null) or (@new_diagramname is null))
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT;
	
		select @u_name = USER_NAME(@owner_id)
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		-- if((@u_name is not null) and (@new_diagramname = @diagramname))	-- nothing will change
		--	return 0;
	
		if(@u_name is null)
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @new_diagramname
		else
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @owner_id and name = @new_diagramname
	
		if((@DiagIdTarg is not null) and  @DiagId <> @DiagIdTarg)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end		
	
		if(@u_name is null)
			update dbo.sysdiagrams set [name] = @new_diagramname, principal_id = @theId where diagram_id = @DiagId
		else
			update dbo.sysdiagrams set [name] = @new_diagramname where diagram_id = @DiagId
		return 0
	END
GO


-- ----------------------------
-- procedure structure for sp_alterdiagram
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_alterdiagram]') AND type IN ('FN', 'FS', 'FT', 'IF', 'TF'))
	DROP PROCEDURE[dbo].[sp_alterdiagram]
GO

CREATE PROCEDURE [dbo].[sp_alterdiagram]
	(
		@diagramname 	sysname,
		@owner_id	int	= null,
		@version 	int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId 			int
		declare @retval 		int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @ShouldChangeUID	int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid ARG', 16, 1)
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();	 
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		revert;
	
		select @ShouldChangeUID = 0
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		
		if(@DiagId IS NULL or (@IsDbo = 0 and @theId <> @UIDFound))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end
	
		if(@IsDbo <> 0)
		begin
			if(@UIDFound is null or USER_NAME(@UIDFound) is null) -- invalid principal_id
			begin
				select @ShouldChangeUID = 1 ;
			end
		end

		-- update dds data			
		update dbo.sysdiagrams set definition = @definition where diagram_id = @DiagId ;

		-- change owner
		if(@ShouldChangeUID = 1)
			update dbo.sysdiagrams set principal_id = @theId where diagram_id = @DiagId ;

		-- update dds version
		if(@version is not null)
			update dbo.sysdiagrams set version = @version where diagram_id = @DiagId ;

		return 0
	END
GO


-- ----------------------------
-- procedure structure for sp_dropdiagram
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_dropdiagram]') AND type IN ('FN', 'FS', 'FT', 'IF', 'TF'))
	DROP PROCEDURE[dbo].[sp_dropdiagram]
GO

CREATE PROCEDURE [dbo].[sp_dropdiagram]
	(
		@diagramname 	sysname,
		@owner_id	int	= null
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT; 
		
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		delete from dbo.sysdiagrams where diagram_id = @DiagId;
	
		return 0;
	END
GO


-- ----------------------------
-- function structure for fn_diagramobjects
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_diagramobjects]') AND type IN ('FN', 'FS', 'FT', 'IF', 'TF'))
	DROP FUNCTION[dbo].[fn_diagramobjects]
GO

CREATE FUNCTION [dbo].[fn_diagramobjects]() 
	RETURNS int
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		declare @id_upgraddiagrams		int
		declare @id_sysdiagrams			int
		declare @id_helpdiagrams		int
		declare @id_helpdiagramdefinition	int
		declare @id_creatediagram	int
		declare @id_renamediagram	int
		declare @id_alterdiagram 	int 
		declare @id_dropdiagram		int
		declare @InstalledObjects	int

		select @InstalledObjects = 0

		select 	@id_upgraddiagrams = object_id(N'dbo.sp_upgraddiagrams'),
			@id_sysdiagrams = object_id(N'dbo.sysdiagrams'),
			@id_helpdiagrams = object_id(N'dbo.sp_helpdiagrams'),
			@id_helpdiagramdefinition = object_id(N'dbo.sp_helpdiagramdefinition'),
			@id_creatediagram = object_id(N'dbo.sp_creatediagram'),
			@id_renamediagram = object_id(N'dbo.sp_renamediagram'),
			@id_alterdiagram = object_id(N'dbo.sp_alterdiagram'), 
			@id_dropdiagram = object_id(N'dbo.sp_dropdiagram')

		if @id_upgraddiagrams is not null
			select @InstalledObjects = @InstalledObjects + 1
		if @id_sysdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 2
		if @id_helpdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 4
		if @id_helpdiagramdefinition is not null
			select @InstalledObjects = @InstalledObjects + 8
		if @id_creatediagram is not null
			select @InstalledObjects = @InstalledObjects + 16
		if @id_renamediagram is not null
			select @InstalledObjects = @InstalledObjects + 32
		if @id_alterdiagram  is not null
			select @InstalledObjects = @InstalledObjects + 64
		if @id_dropdiagram is not null
			select @InstalledObjects = @InstalledObjects + 128
		
		return @InstalledObjects 
	END
GO


-- ----------------------------
-- Auto increment value for Enrollment
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Enrollment]', RESEED, 1004)
GO


-- ----------------------------
-- Primary Key structure for table Enrollment
-- ----------------------------
ALTER TABLE [dbo].[Enrollment] ADD CONSTRAINT [PK_Enrollment] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Semester
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Semester]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table Semester
-- ----------------------------
ALTER TABLE [dbo].[Semester] ADD CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for SemesterTeacherSubject
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[SemesterTeacherSubject]', RESEED, 3016)
GO


-- ----------------------------
-- Primary Key structure for table SemesterTeacherSubject
-- ----------------------------
ALTER TABLE [dbo].[SemesterTeacherSubject] ADD CONSTRAINT [PK_SemesterTeacherSubject] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for StudentAbsense
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[StudentAbsense]', RESEED, 1005)
GO


-- ----------------------------
-- Primary Key structure for table StudentAbsense
-- ----------------------------
ALTER TABLE [dbo].[StudentAbsense] ADD CONSTRAINT [PK_StudentAbsense] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Subject
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Subject]', RESEED, 1003)
GO


-- ----------------------------
-- Primary Key structure for table Subject
-- ----------------------------
ALTER TABLE [dbo].[Subject] ADD CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for sysdiagrams
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[sysdiagrams]', RESEED, 1)
GO


-- ----------------------------
-- Uniques structure for table sysdiagrams
-- ----------------------------
ALTER TABLE [dbo].[sysdiagrams] ADD CONSTRAINT [UK_principal_name] UNIQUE NONCLUSTERED ([principal_id] ASC, [name] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table sysdiagrams
-- ----------------------------
ALTER TABLE [dbo].[sysdiagrams] ADD CONSTRAINT [PK__sysdiagr__C2B05B613A455172] PRIMARY KEY CLUSTERED ([diagram_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for User
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[User]', RESEED, 1022)
GO


-- ----------------------------
-- Primary Key structure for table User
-- ----------------------------
ALTER TABLE [dbo].[User] ADD CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

-- ----------------------------
-- Uniques structure for table SemesterAchrayus
-- ----------------------------
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SemesterAchrayus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NULL,
	[Email] [nchar](255) NULL,
	[SemesterName] [nchar](255) NULL,
	[Achrayus] [int] NULL,
 CONSTRAINT [PK_SemesterAchrayus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

