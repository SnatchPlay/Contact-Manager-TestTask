USE [master]
GO
/****** Object:  Database [ContactManagerDatabase]    Script Date: 09.04.2024 19:50:27 ******/
CREATE DATABASE [ContactManagerDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ContactManagerDatabase', FILENAME = N'D:\SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ContactManagerDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ContactManagerDatabase_log', FILENAME = N'D:\SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ContactManagerDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ContactManagerDatabase] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ContactManagerDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ContactManagerDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ContactManagerDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ContactManagerDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ContactManagerDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ContactManagerDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [ContactManagerDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ContactManagerDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ContactManagerDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ContactManagerDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ContactManagerDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ContactManagerDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ContactManagerDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ContactManagerDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ContactManagerDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ContactManagerDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ContactManagerDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ContactManagerDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ContactManagerDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ContactManagerDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ContactManagerDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ContactManagerDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ContactManagerDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ContactManagerDatabase] SET RECOVERY FULL 
GO
ALTER DATABASE [ContactManagerDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [ContactManagerDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ContactManagerDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ContactManagerDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ContactManagerDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ContactManagerDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ContactManagerDatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ContactManagerDatabase', N'ON'
GO
ALTER DATABASE [ContactManagerDatabase] SET QUERY_STORE = ON
GO
ALTER DATABASE [ContactManagerDatabase] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ContactManagerDatabase]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 09.04.2024 19:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[dateofbirth] [date] NOT NULL,
	[ismarried] [bit] NOT NULL,
	[phone_number] [nvarchar](50) NOT NULL,
	[salary] [decimal](18, 0) NOT NULL,
	[row_insert_time] [datetime] NOT NULL,
	[row_update_time] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF_Person_row_insert_time]  DEFAULT (getutcdate()) FOR [row_insert_time]
GO
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF_Person_row_update_time]  DEFAULT (getutcdate()) FOR [row_update_time]
GO
USE [master]
GO
ALTER DATABASE [ContactManagerDatabase] SET  READ_WRITE 
GO
