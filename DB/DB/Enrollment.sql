USE [SchoolManagement]
GO

/****** Object:  Table [dbo].[Enrollment]    Script Date: 9/7/2022 1:01:08 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Enrollment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Teacher] [nvarchar](50) NULL,
	[Subject] [nvarchar](50) NULL,
	[Student] [nvarchar](50) NULL,
 CONSTRAINT [PK_Enrollment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

