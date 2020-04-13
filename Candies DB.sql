USE [Candies]
GO
/****** Object:  Table [dbo].[Page]    Script Date: 13/04/2020 8:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Page](
	[idPage] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](50) NULL,
	[state] [bit] NOT NULL,
 CONSTRAINT [PK_Page] PRIMARY KEY CLUSTERED 
(
	[idPage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 13/04/2020 8:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[idRole] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](50) NULL,
	[state] [bit] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[idRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RolePage]    Script Date: 13/04/2020 8:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePage](
	[idRolePage] [int] IDENTITY(1,1) NOT NULL,
	[idRole] [int] NOT NULL,
	[idPage] [int] NOT NULL,
	[state] [bit] NOT NULL,
 CONSTRAINT [PK_RolePage] PRIMARY KEY CLUSTERED 
(
	[idRolePage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 13/04/2020 8:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[idUser] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[lastName] [nvarchar](max) NULL,
	[userName] [nvarchar](max) NULL,
	[passwordHash] [varbinary](max) NULL,
	[passwordSalt] [varbinary](max) NULL,
	[estado] [tinyint] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 13/04/2020 8:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[idUserRole] [int] IDENTITY(1,1) NOT NULL,
	[idUser] [int] NOT NULL,
	[idRole] [int] NOT NULL,
	[state] [bit] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[idUserRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[RolePage]  WITH CHECK ADD  CONSTRAINT [FK_RolePage_Page_idPage] FOREIGN KEY([idPage])
REFERENCES [dbo].[Page] ([idPage])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RolePage] CHECK CONSTRAINT [FK_RolePage_Page_idPage]
GO
ALTER TABLE [dbo].[RolePage]  WITH CHECK ADD  CONSTRAINT [FK_RolePage_Role_idRole] FOREIGN KEY([idRole])
REFERENCES [dbo].[Role] ([idRole])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RolePage] CHECK CONSTRAINT [FK_RolePage_Role_idRole]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role_idRole] FOREIGN KEY([idRole])
REFERENCES [dbo].[Role] ([idRole])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role_idRole]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User_idUser] FOREIGN KEY([idUser])
REFERENCES [dbo].[User] ([idUser])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User_idUser]
GO
