USE [master]
GO
/****** Object:  Database [CustomerRegDB]    Script Date: 5/17/2025 5:51:32 PM ******/
CREATE DATABASE [CustomerRegDB]
GO
USE [CustomerRegDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/17/2025 5:51:32 PM ******/
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
/****** Object:  Table [dbo].[Customers]    Script Date: 5/17/2025 5:51:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[ICNumber] [nvarchar](12) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[MobileNo] [nvarchar](20) NOT NULL,
	[EmailVerificationCode] [nvarchar](6) NOT NULL,
	[IsEmailVerified] [bit] NOT NULL,
	[MobileVerificationCode] [nvarchar](6) NOT NULL,
	[IsMobileVerified] [bit] NOT NULL,
	[AcceptedPrivacyPolicy] [bit] NOT NULL,
	[PolicyAcceptanceDate] [datetime2](7) NOT NULL,
	[Pin] [nvarchar](6) NOT NULL,
	[IsBiometricLoginEnable] [bit] NOT NULL,
	[RegistrationDate] [datetime2](7) NOT NULL,
	[VerificationDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [CustomerRegDB] SET  READ_WRITE 
GO
