USE [SchoolManagement]
GO

/****** Object:  Table [dbo].[SubjectAttendance]    Script Date: 9/7/2022 1:00:22 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SubjectAttendance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubjectId] [int] NULL,
	[TeacherId] [int] NULL,
	[Date] [datetime] NULL,
	[Period] [int] NULL,
	[PeriodTimeOfDay] [int] NULL,
 CONSTRAINT [PK_SubjectAttendance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

