USE [CodereTecnicalTest]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/8/2024 11:33:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 8/8/2024 11:33:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[code] [nvarchar](max) NOT NULL,
	[timezone] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Externals]    Script Date: 8/8/2024 11:33:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Externals](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tvrage] [int] NULL,
	[thetvdb] [int] NULL,
	[imdb] [nvarchar](max) NULL,
 CONSTRAINT [PK_Externals] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 8/8/2024 11:33:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GenreShow]    Script Date: 8/8/2024 11:33:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GenreShow](
	[genresid] [int] NOT NULL,
	[showsid] [int] NOT NULL,
 CONSTRAINT [PK_GenreShow] PRIMARY KEY CLUSTERED 
(
	[genresid] ASC,
	[showsid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 8/8/2024 11:33:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[medium] [nvarchar](max) NOT NULL,
	[original] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Links]    Script Date: 8/8/2024 11:33:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Links](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[selfid] [int] NOT NULL,
	[previousepisodeid] [int] NOT NULL,
 CONSTRAINT [PK_Links] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Networks]    Script Date: 8/8/2024 11:33:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Networks](
	[id] [int] NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[countryid] [int] NULL,
	[officialSite] [nvarchar](max) NULL,
 CONSTRAINT [PK_Networks] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Previousepisodes]    Script Date: 8/8/2024 11:33:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Previousepisodes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[href] [nvarchar](max) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Previousepisodes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ratings]    Script Date: 8/8/2024 11:33:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ratings](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[average] [real] NULL,
 CONSTRAINT [PK_Ratings] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedules]    Script Date: 8/8/2024 11:33:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedules](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[time] [nvarchar](max) NOT NULL,
	[days] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Schedules] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Selves]    Script Date: 8/8/2024 11:33:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Selves](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[href] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Selves] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shows]    Script Date: 8/8/2024 11:33:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shows](
	[id] [int] NOT NULL,
	[url] [nvarchar](max) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[type] [nvarchar](max) NOT NULL,
	[language] [nvarchar](max) NULL,
	[status] [nvarchar](max) NOT NULL,
	[runtime] [int] NULL,
	[averageRuntime] [int] NULL,
	[premiered] [nvarchar](max) NULL,
	[ended] [nvarchar](max) NULL,
	[officialSite] [nvarchar](max) NULL,
	[scheduleid] [int] NOT NULL,
	[ratingid] [int] NOT NULL,
	[weight] [int] NOT NULL,
	[networkid] [int] NULL,
	[webChannelid] [int] NULL,
	[dvdCountryid] [int] NULL,
	[externalsid] [int] NOT NULL,
	[imageid] [int] NULL,
	[summary] [nvarchar](max) NULL,
	[updated] [int] NOT NULL,
	[_linksid] [int] NOT NULL,
 CONSTRAINT [PK_Shows] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[GenreShow]  WITH CHECK ADD  CONSTRAINT [FK_GenreShow_Genres_genresid] FOREIGN KEY([genresid])
REFERENCES [dbo].[Genres] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GenreShow] CHECK CONSTRAINT [FK_GenreShow_Genres_genresid]
GO
ALTER TABLE [dbo].[GenreShow]  WITH CHECK ADD  CONSTRAINT [FK_GenreShow_Shows_showsid] FOREIGN KEY([showsid])
REFERENCES [dbo].[Shows] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GenreShow] CHECK CONSTRAINT [FK_GenreShow_Shows_showsid]
GO
ALTER TABLE [dbo].[Links]  WITH CHECK ADD  CONSTRAINT [FK_Links_Previousepisodes_previousepisodeid] FOREIGN KEY([previousepisodeid])
REFERENCES [dbo].[Previousepisodes] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Links] CHECK CONSTRAINT [FK_Links_Previousepisodes_previousepisodeid]
GO
ALTER TABLE [dbo].[Links]  WITH CHECK ADD  CONSTRAINT [FK_Links_Selves_selfid] FOREIGN KEY([selfid])
REFERENCES [dbo].[Selves] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Links] CHECK CONSTRAINT [FK_Links_Selves_selfid]
GO
ALTER TABLE [dbo].[Networks]  WITH CHECK ADD  CONSTRAINT [FK_Networks_Countries_countryid] FOREIGN KEY([countryid])
REFERENCES [dbo].[Countries] ([id])
GO
ALTER TABLE [dbo].[Networks] CHECK CONSTRAINT [FK_Networks_Countries_countryid]
GO
ALTER TABLE [dbo].[Shows]  WITH CHECK ADD  CONSTRAINT [FK_Shows_Countries_dvdCountryid] FOREIGN KEY([dvdCountryid])
REFERENCES [dbo].[Countries] ([id])
GO
ALTER TABLE [dbo].[Shows] CHECK CONSTRAINT [FK_Shows_Countries_dvdCountryid]
GO
ALTER TABLE [dbo].[Shows]  WITH CHECK ADD  CONSTRAINT [FK_Shows_Externals_externalsid] FOREIGN KEY([externalsid])
REFERENCES [dbo].[Externals] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Shows] CHECK CONSTRAINT [FK_Shows_Externals_externalsid]
GO
ALTER TABLE [dbo].[Shows]  WITH CHECK ADD  CONSTRAINT [FK_Shows_Images_imageid] FOREIGN KEY([imageid])
REFERENCES [dbo].[Images] ([id])
GO
ALTER TABLE [dbo].[Shows] CHECK CONSTRAINT [FK_Shows_Images_imageid]
GO
ALTER TABLE [dbo].[Shows]  WITH CHECK ADD  CONSTRAINT [FK_Shows_Links__linksid] FOREIGN KEY([_linksid])
REFERENCES [dbo].[Links] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Shows] CHECK CONSTRAINT [FK_Shows_Links__linksid]
GO
ALTER TABLE [dbo].[Shows]  WITH CHECK ADD  CONSTRAINT [FK_Shows_Networks_networkid] FOREIGN KEY([networkid])
REFERENCES [dbo].[Networks] ([id])
GO
ALTER TABLE [dbo].[Shows] CHECK CONSTRAINT [FK_Shows_Networks_networkid]
GO
ALTER TABLE [dbo].[Shows]  WITH CHECK ADD  CONSTRAINT [FK_Shows_Networks_webChannelid] FOREIGN KEY([webChannelid])
REFERENCES [dbo].[Networks] ([id])
GO
ALTER TABLE [dbo].[Shows] CHECK CONSTRAINT [FK_Shows_Networks_webChannelid]
GO
ALTER TABLE [dbo].[Shows]  WITH CHECK ADD  CONSTRAINT [FK_Shows_Ratings_ratingid] FOREIGN KEY([ratingid])
REFERENCES [dbo].[Ratings] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Shows] CHECK CONSTRAINT [FK_Shows_Ratings_ratingid]
GO
ALTER TABLE [dbo].[Shows]  WITH CHECK ADD  CONSTRAINT [FK_Shows_Schedules_scheduleid] FOREIGN KEY([scheduleid])
REFERENCES [dbo].[Schedules] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Shows] CHECK CONSTRAINT [FK_Shows_Schedules_scheduleid]
GO
