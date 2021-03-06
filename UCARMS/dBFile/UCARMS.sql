USE [master]
GO
/****** Object:  Database [UCARMS]    Script Date: 3/25/2019 1:53:18 PM ******/
CREATE DATABASE [UCARMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UCARMS', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\UCARMS.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UCARMS_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\UCARMS_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UCARMS] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UCARMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UCARMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UCARMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UCARMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UCARMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UCARMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [UCARMS] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [UCARMS] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [UCARMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UCARMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UCARMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UCARMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UCARMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UCARMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UCARMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UCARMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UCARMS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [UCARMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UCARMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UCARMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UCARMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UCARMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UCARMS] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [UCARMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UCARMS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UCARMS] SET  MULTI_USER 
GO
ALTER DATABASE [UCARMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UCARMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UCARMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UCARMS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [UCARMS]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 3/25/2019 1:53:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClassAllocations]    Script Date: 3/25/2019 1:53:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassAllocations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[ClassRoomId] [int] NOT NULL,
	[DayId] [int] NOT NULL,
	[FromDate] [date] NOT NULL,
	[ToDate] [date] NOT NULL,
 CONSTRAINT [PK_dbo.ClassAllocations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClassRooms]    Script Date: 3/25/2019 1:53:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClassRooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomNumber] [varchar](8000) NOT NULL,
 CONSTRAINT [PK_dbo.ClassRooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CourseAssigns]    Script Date: 3/25/2019 1:53:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CourseAssigns](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[TeacherId] [int] NOT NULL,
	[CreditTaken] [decimal](18, 2) NOT NULL,
	[CreditRemain] [decimal](18, 2) NOT NULL,
	[CourseId] [int] NOT NULL,
	[CourseName] [varchar](100) NOT NULL,
	[CourseCredit] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.CourseAssigns] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 3/25/2019 1:53:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](11) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Credit] [decimal](18, 2) NOT NULL,
	[Description] [varchar](30) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[SemesterId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Courses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Days]    Script Date: 3/25/2019 1:53:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Days](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DayName] [varchar](8000) NOT NULL,
 CONSTRAINT [PK_dbo.Days] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department]    Script Date: 3/25/2019 1:53:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](11) NOT NULL,
	[Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_dbo.Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Designations]    Script Date: 3/25/2019 1:53:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Designations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](8000) NOT NULL,
 CONSTRAINT [PK_dbo.Designations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GradeLetters]    Script Date: 3/25/2019 1:53:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GradeLetters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GradeLetterName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.GradeLetters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Semesters]    Script Date: 3/25/2019 1:53:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Semesters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](8000) NOT NULL,
 CONSTRAINT [PK_dbo.Semesters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentEnrolls]    Script Date: 3/25/2019 1:53:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentEnrolls](
	[Id] [tinyint] NOT NULL,
	[StudentRegistrationNo] [varchar](8000) NOT NULL,
	[StudentName] [varchar](8000) NOT NULL,
	[Email] [varchar](8000) NOT NULL,
	[Department] [varchar](8000) NOT NULL,
	[CourseId] [int] NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_dbo.StudentEnrolls] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentRegistrations]    Script Date: 3/25/2019 1:53:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentRegistrations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StuRegNo] [varchar](8000) NOT NULL,
	[StuName] [varchar](50) NOT NULL,
	[Email] [varchar](8000) NOT NULL,
	[ContactNo] [varchar](11) NOT NULL,
	[Date] [date] NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.StudentRegistrations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentResults]    Script Date: 3/25/2019 1:53:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentResults](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentRegistrationNum] [varchar](8000) NOT NULL,
	[StudentName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Department] [nvarchar](max) NULL,
	[CourseId] [int] NOT NULL,
	[GradeLetterId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.StudentResults] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 3/25/2019 1:53:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teachers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[ContactNo] [varchar](100) NOT NULL,
	[DesignationId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[Credit] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.Teachers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Index [IX_ClassRoomId]    Script Date: 3/25/2019 1:53:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_ClassRoomId] ON [dbo].[ClassAllocations]
(
	[ClassRoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CourseId]    Script Date: 3/25/2019 1:53:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_CourseId] ON [dbo].[ClassAllocations]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DayId]    Script Date: 3/25/2019 1:53:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_DayId] ON [dbo].[ClassAllocations]
(
	[DayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DepartmentId]    Script Date: 3/25/2019 1:53:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_DepartmentId] ON [dbo].[ClassAllocations]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CourseId]    Script Date: 3/25/2019 1:53:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_CourseId] ON [dbo].[CourseAssigns]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DepartmentId]    Script Date: 3/25/2019 1:53:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_DepartmentId] ON [dbo].[CourseAssigns]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TeacherId]    Script Date: 3/25/2019 1:53:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_TeacherId] ON [dbo].[CourseAssigns]
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DepartmentId]    Script Date: 3/25/2019 1:53:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_DepartmentId] ON [dbo].[Courses]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SemesterId]    Script Date: 3/25/2019 1:53:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_SemesterId] ON [dbo].[Courses]
(
	[SemesterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CourseId]    Script Date: 3/25/2019 1:53:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_CourseId] ON [dbo].[StudentEnrolls]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DepartmentId]    Script Date: 3/25/2019 1:53:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_DepartmentId] ON [dbo].[StudentRegistrations]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CourseId]    Script Date: 3/25/2019 1:53:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_CourseId] ON [dbo].[StudentResults]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GradeLetterId]    Script Date: 3/25/2019 1:53:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_GradeLetterId] ON [dbo].[StudentResults]
(
	[GradeLetterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DepartmentId]    Script Date: 3/25/2019 1:53:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_DepartmentId] ON [dbo].[Teachers]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DesignationId]    Script Date: 3/25/2019 1:53:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_DesignationId] ON [dbo].[Teachers]
(
	[DesignationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ClassAllocations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClassAllocations_dbo.ClassRooms_ClassRoomId] FOREIGN KEY([ClassRoomId])
REFERENCES [dbo].[ClassRooms] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClassAllocations] CHECK CONSTRAINT [FK_dbo.ClassAllocations_dbo.ClassRooms_ClassRoomId]
GO
ALTER TABLE [dbo].[ClassAllocations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClassAllocations_dbo.Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClassAllocations] CHECK CONSTRAINT [FK_dbo.ClassAllocations_dbo.Courses_CourseId]
GO
ALTER TABLE [dbo].[ClassAllocations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClassAllocations_dbo.Days_DayId] FOREIGN KEY([DayId])
REFERENCES [dbo].[Days] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClassAllocations] CHECK CONSTRAINT [FK_dbo.ClassAllocations_dbo.Days_DayId]
GO
ALTER TABLE [dbo].[ClassAllocations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClassAllocations_dbo.Department_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClassAllocations] CHECK CONSTRAINT [FK_dbo.ClassAllocations_dbo.Department_DepartmentId]
GO
ALTER TABLE [dbo].[CourseAssigns]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CourseAssigns_dbo.Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[CourseAssigns] CHECK CONSTRAINT [FK_dbo.CourseAssigns_dbo.Courses_CourseId]
GO
ALTER TABLE [dbo].[CourseAssigns]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CourseAssigns_dbo.Department_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[CourseAssigns] CHECK CONSTRAINT [FK_dbo.CourseAssigns_dbo.Department_DepartmentId]
GO
ALTER TABLE [dbo].[CourseAssigns]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CourseAssigns_dbo.Teachers_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([Id])
GO
ALTER TABLE [dbo].[CourseAssigns] CHECK CONSTRAINT [FK_dbo.CourseAssigns_dbo.Teachers_TeacherId]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Courses_dbo.Department_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_dbo.Courses_dbo.Department_DepartmentId]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Courses_dbo.Semesters_SemesterId] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semesters] ([Id])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_dbo.Courses_dbo.Semesters_SemesterId]
GO
ALTER TABLE [dbo].[StudentEnrolls]  WITH CHECK ADD  CONSTRAINT [FK_dbo.StudentEnrolls_dbo.Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[StudentEnrolls] CHECK CONSTRAINT [FK_dbo.StudentEnrolls_dbo.Courses_CourseId]
GO
ALTER TABLE [dbo].[StudentRegistrations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.StudentRegistrations_dbo.Department_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[StudentRegistrations] CHECK CONSTRAINT [FK_dbo.StudentRegistrations_dbo.Department_DepartmentId]
GO
ALTER TABLE [dbo].[StudentResults]  WITH CHECK ADD  CONSTRAINT [FK_dbo.StudentResults_dbo.Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[StudentResults] CHECK CONSTRAINT [FK_dbo.StudentResults_dbo.Courses_CourseId]
GO
ALTER TABLE [dbo].[StudentResults]  WITH CHECK ADD  CONSTRAINT [FK_dbo.StudentResults_dbo.GradeLetters_GradeLetterId] FOREIGN KEY([GradeLetterId])
REFERENCES [dbo].[GradeLetters] ([Id])
GO
ALTER TABLE [dbo].[StudentResults] CHECK CONSTRAINT [FK_dbo.StudentResults_dbo.GradeLetters_GradeLetterId]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Teachers_dbo.Department_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_dbo.Teachers_dbo.Department_DepartmentId]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Teachers_dbo.Designations_DesignationId] FOREIGN KEY([DesignationId])
REFERENCES [dbo].[Designations] ([Id])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_dbo.Teachers_dbo.Designations_DesignationId]
GO
USE [master]
GO
ALTER DATABASE [UCARMS] SET  READ_WRITE 
GO
