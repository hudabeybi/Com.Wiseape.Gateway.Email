USE [master]
GO
/****** Object:  Database [Com.Wiseape.Gateway.Email2]    Script Date: 4/10/2017 2:50:38 PM ******/
CREATE DATABASE [Com.Wiseape.Gateway.Email2]
 CONTAINMENT = NONE
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Com.Wiseape.Gateway.Email].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET ARITHABORT OFF 
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET RECOVERY FULL 
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET  MULTI_USER 
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Com.Wiseape.Gateway.Email', N'ON'
GO
USE [Com.Wiseape.Gateway.Email]
GO
/****** Object:  Table [dbo].[EmailReceiver]    Script Date: 4/10/2017 2:50:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmailReceiver](
	[IdReceiver] [bigint] IDENTITY(1,1) NOT NULL,
	[ReceiverName] [varchar](250) NULL,
	[ReceiverEmail] [varchar](250) NULL,
	[ReceiverInfo] [text] NULL,
	[UserId] [bigint] NULL,
	[Tag] [varchar](50) NULL,
 CONSTRAINT [PK_EmailReceiver] PRIMARY KEY CLUSTERED 
(
	[IdReceiver] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmailSent]    Script Date: 4/10/2017 2:50:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmailSent](
	[IdEmailSent] [bigint] IDENTITY(1,1) NOT NULL,
	[SenderName] [varchar](250) NULL,
	[EmailFrom] [varchar](250) NULL,
	[EmailFromAlias] [varchar](250) NULL,
	[EmailTos] [text] NULL,
	[EmailSubject] [varchar](250) NULL,
	[EmailContent] [text] NULL,
	[SentDate] [datetime] NULL,
	[IsSent] [int] NULL,
	[UserId] [bigint] NULL,
	[EmailAccountId] [bigint] NULL,
 CONSTRAINT [PK_EmailSent] PRIMARY KEY CLUSTERED 
(
	[IdEmailSent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmailTemplate]    Script Date: 4/10/2017 2:50:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmailTemplate](
	[IdEmailTemplate] [bigint] IDENTITY(1,1) NOT NULL,
	[EmailSubject] [varchar](250) NULL,
	[EmailContent] [text] NULL,
	[Tag] [varchar](50) NULL,
	[UserId] [bigint] NOT NULL,
	[IsActive] [int] NULL,
 CONSTRAINT [PK_EmailTemplate] PRIMARY KEY CLUSTERED 
(
	[IdEmailTemplate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SenderEmailAccount]    Script Date: 4/10/2017 2:50:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SenderEmailAccount](
	[IdSender] [bigint] IDENTITY(1,1) NOT NULL,
	[SenderName] [varchar](250) NULL,
	[SenderEmail] [varchar](250) NULL,
	[SmtpServer] [varchar](250) NULL,
	[SmtpPort] [int] NULL,
	[EnableSsl] [int] NULL,
	[EmailAccount] [varchar](250) NULL,
	[EmailAccountPassword] [text] NULL,
	[IsDefault] [int] NULL,
	[UserId] [bigint] NOT NULL,
	[Tag] [varchar](50) NULL,
	[IsActive] [int] NULL,
 CONSTRAINT [PK_SenderEmailAccount] PRIMARY KEY CLUSTERED 
(
	[IdSender] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [Com.Wiseape.Gateway.Email] SET  READ_WRITE 
GO
