USE [master]
GO
/****** Object:  Database [PayrollDB]    Script Date: 31/01/2019 20:54:43 ******/
CREATE DATABASE [PayrollDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PayrollDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PayrollDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PayrollDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PayrollDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PayrollDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PayrollDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PayrollDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PayrollDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PayrollDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PayrollDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PayrollDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PayrollDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PayrollDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PayrollDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PayrollDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PayrollDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PayrollDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PayrollDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PayrollDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PayrollDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PayrollDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PayrollDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PayrollDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PayrollDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PayrollDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PayrollDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PayrollDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PayrollDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PayrollDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PayrollDB] SET  MULTI_USER 
GO
ALTER DATABASE [PayrollDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PayrollDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PayrollDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PayrollDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PayrollDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [PayrollDB]
GO
/****** Object:  Table [dbo].[tblEmployee]    Script Date: 31/01/2019 20:54:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEmployee](
	[EmployeeID] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Gender] [nvarchar](50) NOT NULL,
	[NINumber] [nvarchar](50) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[MaritalStatus] [nvarchar](50) NOT NULL,
	[IsMember] [bit] NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[PostCode] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblEmployee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblLogIn]    Script Date: 31/01/2019 20:54:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLogIn](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Roles] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblLogIn] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblPayRecord]    Script Date: 31/01/2019 20:54:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPayRecord](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[NINumber] [nvarchar](50) NOT NULL,
	[PayDate] [datetime] NOT NULL,
	[PayPeriod] [nvarchar](50) NOT NULL,
	[PayMonth] [nvarchar](50) NOT NULL,
	[HourlyRate] [decimal](18, 2) NOT NULL,
	[ContractualHours] [decimal](18, 2) NOT NULL,
	[OvertimeHours] [decimal](18, 2) NOT NULL,
	[TotalHours] [decimal](18, 2) NOT NULL,
	[ContractualEarnings] [money] NOT NULL,
	[OvertimeEarnings] [money] NOT NULL,
	[TotalEarnings] [money] NOT NULL,
	[TaxCode] [nvarchar](50) NOT NULL,
	[TaxAmount] [money] NOT NULL,
	[NIContribution] [money] NOT NULL,
	[UnionFee] [money] NULL,
	[SLC] [money] NULL,
	[TotalDeductions] [money] NOT NULL,
	[NetPay] [money] NOT NULL,
 CONSTRAINT [PK_tblPayRecord] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[tblPayRecord]  WITH CHECK ADD  CONSTRAINT [FK_tblPayRecord_tblEmployee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[tblEmployee] ([EmployeeID])
GO
ALTER TABLE [dbo].[tblPayRecord] CHECK CONSTRAINT [FK_tblPayRecord_tblEmployee]
GO
ALTER TABLE [dbo].[tblPayRecord]  WITH CHECK ADD  CONSTRAINT [FK_tblPayRecord_tblPayRecord] FOREIGN KEY([PaymentID])
REFERENCES [dbo].[tblPayRecord] ([PaymentID])
GO
ALTER TABLE [dbo].[tblPayRecord] CHECK CONSTRAINT [FK_tblPayRecord_tblPayRecord]
GO
/****** Object:  StoredProcedure [dbo].[spAllUsers]    Script Date: 31/01/2019 20:54:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAllUsers]
AS
	BEGIN
		SELECT * FROM tblLogIn
	END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteCommand]    Script Date: 31/01/2019 20:54:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDeleteCommand]
(
@UserName AS NVARCHAR(50)
)
AS
	BEGIN
		DELETE FROM tblLogIn WHERE UserName = @UserName
	END
GO
/****** Object:  StoredProcedure [dbo].[spInsertCommand]    Script Date: 31/01/2019 20:54:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertCommand]
(
@UserName AS NVARCHAR(50),
@Password AS NVARCHAR(50),
@Roles AS NVARCHAR(50),
@Description AS NVARCHAR(MAX)
)

AS
BEGIN
	INSERT INTO [dbo].[tblLogIn](UserName, [Password], Roles,[Description])
	VALUES(@UserName, @Password, @Roles, @Description)
END
GO
/****** Object:  StoredProcedure [dbo].[spIsUserDetailsValid]    Script Date: 31/01/2019 20:54:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spIsUserDetailsValid]
(
@UserName NVARCHAR(50),
@Password NVARCHAR(50),
@Roles NVARCHAR(50)
)
AS
	BEGIN

		DECLARE @IsUserValid BIT
		SET @IsUserValid = 0

		IF EXISTS(SELECT * FROM tblLogIn WHERE UserName = @UserName
										AND [Password] = @Password
										AND Roles =@Roles)
		BEGIN
		SET @IsUserValid = 1
		END

		SELECT @IsUserValid
	END

GO
/****** Object:  StoredProcedure [dbo].[spUpdateCommand]    Script Date: 31/01/2019 20:54:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateCommand]
(
@UserName AS NVARCHAR(50),
@Password AS NVARCHAR(50),
@Roles AS NVARCHAR(50),
@Description AS NVARCHAR(MAX)
)
AS
	BEGIN
		UPDATE [dbo].[tblLogIn] SET
		[Password] =@Password, Roles = @Roles, [Description] = @Description
		WHERE UserName = @UserName
	END
GO
USE [master]
GO
ALTER DATABASE [PayrollDB] SET  READ_WRITE 
GO
