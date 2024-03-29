USE [GolosDetu]
GO
/****** Object:  Table [dbo].[Participant]    Script Date: 16.02.2024 17:06:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Participant](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](100) NULL,
	[Name] [nvarchar](100) NULL,
	[Patronymic] [nvarchar](100) NULL,
	[Description] [text] NULL,
	[Photo] [varbinary](max) NULL,
	[PartyId] [int] NULL,
 CONSTRAINT [PK_Participant] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Party]    Script Date: 16.02.2024 17:06:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Party](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NULL,
 CONSTRAINT [PK_Party] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Result]    Script Date: 16.02.2024 17:06:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Result](
	[ParticipantId] [int] NOT NULL,
	[Count] [int] NULL,
 CONSTRAINT [PK_Result] PRIMARY KEY CLUSTERED 
(
	[ParticipantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 16.02.2024 17:06:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 16.02.2024 17:06:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Patronymic] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](11) NOT NULL,
	[Series] [nvarchar](4) NOT NULL,
	[Number] [nvarchar](6) NOT NULL,
	[INN] [nvarchar](12) NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vote]    Script Date: 16.02.2024 17:06:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vote](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParticipantId] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Vote] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Participant]  WITH CHECK ADD  CONSTRAINT [FK_Participant_Party] FOREIGN KEY([PartyId])
REFERENCES [dbo].[Party] ([Id])
GO
ALTER TABLE [dbo].[Participant] CHECK CONSTRAINT [FK_Participant_Party]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_Participant] FOREIGN KEY([ParticipantId])
REFERENCES [dbo].[Participant] ([Id])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_Participant]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
ALTER TABLE [dbo].[Vote]  WITH CHECK ADD  CONSTRAINT [FK_Vote_Participant] FOREIGN KEY([ParticipantId])
REFERENCES [dbo].[Participant] ([Id])
GO
ALTER TABLE [dbo].[Vote] CHECK CONSTRAINT [FK_Vote_Participant]
GO
ALTER TABLE [dbo].[Vote]  WITH CHECK ADD  CONSTRAINT [FK_Vote_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Vote] CHECK CONSTRAINT [FK_Vote_User]
GO
