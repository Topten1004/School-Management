USE [SchoolManagement]
GO

/****** Object:  Table [dbo].[Semester]    Script Date: 9/7/2022 1:01:25 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Semester](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[FromDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Default] [bit] NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL,
	[Weeks] [int] NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

