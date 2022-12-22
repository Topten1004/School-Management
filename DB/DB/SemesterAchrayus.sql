USE [SchoolManagement]
GO

/****** Object:  Table [dbo].[SemesterAchrayus]    Script Date: 9/7/2022 12:59:52 AM ******/
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

