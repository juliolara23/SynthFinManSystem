USE [master]
GO

/****** Object:  Database [SynthFinlMantSystemDb]   Main database ******/
CREATE DATABASE [SynthFinlMantSystemDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SynthFinlMantSystem', FILENAME = N'C:\MSSQL\DATA\SynthFinlMantSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SynthFinlMantSystem_log', FILENAME = N'C:\MSSQL\DATA\SynthFinlMantSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SynthFinlMantSystemDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET ARITHABORT OFF 
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET  DISABLE_BROKER 
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET READ_COMMITTED_SNAPSHOT ON 
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET RECOVERY FULL 
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET  MULTI_USER 
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET DB_CHAINING OFF 
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET QUERY_STORE = OFF
GO

ALTER DATABASE [SynthFinlMantSystemDb] SET  READ_WRITE 
GO

USE [SynthFinlMantSystemDb]
GO

/****** Object:  Table [dbo].[Role]    Table for user roles ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Role](
	[Id] [nvarchar](1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [SynthFinlMantSystemDb]
GO

/****** Object:  Table [dbo].[User]   Table for users ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[Username] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[IdRole] [nvarchar](1) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [SynthFinlMantSystemDb]
GO

/****** Object:  Table [dbo].[Transaction]   table for transactions ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Transaction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](20) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[NameOrig] [nvarchar](100) NOT NULL,
	[NameDest] [nvarchar](100) NOT NULL,
	[TransactionDate] [datetimeoffset](7) NOT NULL,
	[IsFraud] [bit] NOT NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [SynthFinlMantSystemDb]
GO

INSERT INTO [dbo].[Role]
           ([Id]
           ,[Name])
     VALUES
           ('A',
           'Assistant')
GO

INSERT INTO [dbo].[Role]
           ([Id]
           ,[Name])
     VALUES
           ('D',
           'Administrator')
GO

INSERT INTO [dbo].[Role]
           ([Id]
           ,[Name])
     VALUES
           ('M',
           'Manager')
GO

USE [SynthFinlMantSystemDb]
GO

INSERT INTO [dbo].[User]
           ([Username]
           ,[Password]
           ,[Name]
           ,[IdRole])
     VALUES
           ('natasha.romanoff'
           ,'bwidow'
           ,'Natasha Romanoff'
           ,'M')
GO

INSERT INTO [dbo].[User]
           ([Username]
           ,[Password]
           ,[Name]
           ,[IdRole])
     VALUES
           ('steve.rogers'
           ,'camerica'
           ,'Steve Rogers'
           ,'A')
GO

INSERT INTO [dbo].[User]
           ([Username]
           ,[Password]
           ,[Name]
           ,[IdRole])
     VALUES
           ('tony.stark'
           ,'ironman'
           ,'Tony Stark'
           ,'D')
GO

USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [web] app user ******/
CREATE LOGIN [web] WITH PASSWORD=N'4WjDGKd7Yb+SLtAR3kyNmv5XrO6xRSj9Rtx46PlWzyo=', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO

ALTER LOGIN [web] DISABLE
GO

ALTER SERVER ROLE [sysadmin] ADD MEMBER [web]
GO

ALTER SERVER ROLE [serveradmin] ADD MEMBER [web]
GO

