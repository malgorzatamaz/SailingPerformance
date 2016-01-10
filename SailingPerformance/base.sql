USE [SailingManagerDB]
GO
/****** Object:  User [LGBSPL\hpereverzieva]    Script Date: 2016-01-10 12:51:55 ******/
CREATE USER [LGBSPL\hpereverzieva] FOR LOGIN [LGBSPL\hpereverzieva] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Boats]    Script Date: 2016-01-10 12:51:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Boats](
	[IdBoat] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Model] [nvarchar](50) NULL,
 CONSTRAINT [PK_Boats] PRIMARY KEY CLUSTERED 
(
	[IdBoat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GPSData]    Script Date: 2016-01-10 12:51:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GPSData](
	[IdGPSData] [uniqueidentifier] NOT NULL,
	[IdSession] [uniqueidentifier] NULL,
	[SecondsFromStart] [datetime] NULL,
	[BoatSpeed] [float] NULL,
	[BoatDirection] [float] NULL,
	[WindSpeed] [float] NULL,
	[WindDirection] [float] NULL,
	[GeoHeight] [nvarchar](10) NULL,
	[GeoWidth] [nvarchar](10) NULL,
 CONSTRAINT [PK_GPSData] PRIMARY KEY CLUSTERED 
(
	[IdGPSData] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sessions]    Script Date: 2016-01-10 12:51:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sessions](
	[IdSession] [uniqueidentifier] NOT NULL,
	[IdBoat] [uniqueidentifier] NULL,
	[StartDate] [datetime] NULL,
	[StopDate] [datetime] NULL,
 CONSTRAINT [PK_Sessions] PRIMARY KEY CLUSTERED 
(
	[IdSession] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[GPSData]  WITH CHECK ADD  CONSTRAINT [FK_GPSData_Sessions] FOREIGN KEY([IdSession])
REFERENCES [dbo].[Sessions] ([IdSession])
GO
ALTER TABLE [dbo].[GPSData] CHECK CONSTRAINT [FK_GPSData_Sessions]
GO
ALTER TABLE [dbo].[Sessions]  WITH CHECK ADD  CONSTRAINT [FK_Sessions_Boats] FOREIGN KEY([IdBoat])
REFERENCES [dbo].[Boats] ([IdBoat])
GO
ALTER TABLE [dbo].[Sessions] CHECK CONSTRAINT [FK_Sessions_Boats]
GO
/****** Object:  StoredProcedure [dbo].[AddBoat]    Script Date: 2016-01-10 12:51:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddBoat](@Name nvarchar(50), @Model nvarchar(50))
as
begin
insert into Boats(IdBoat, Name, Model) values(NEWID(), @Name, @Model)
end
GO
