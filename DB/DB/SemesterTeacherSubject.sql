USE [SchoolManagement]
GO

/****** Object:  Table [dbo].[SemesterTeacherSubject]    Script Date: 9/7/2022 1:01:40 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SemesterTeacherSubject](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NULL,
	[SemesterId] [int] NULL,
	[TeacherId] [int] NULL,
	[SubjectId] [int] NULL,
 CONSTRAINT [PK_SemesterTeacherSubject] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

