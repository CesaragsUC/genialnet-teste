USE [master]
GO
/****** Object:  Database [GenialDb]    Script Date: 27/08/2024 18:20:05 ******/
CREATE DATABASE [GenialDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GenialDb', FILENAME = N'C:\Users\cesar\GenialDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GenialDb_log', FILENAME = N'C:\Users\cesar\GenialDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [GenialDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GenialDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GenialDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GenialDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GenialDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GenialDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GenialDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [GenialDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [GenialDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GenialDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GenialDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GenialDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GenialDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GenialDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GenialDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GenialDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GenialDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GenialDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GenialDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GenialDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GenialDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GenialDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GenialDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [GenialDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GenialDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GenialDb] SET  MULTI_USER 
GO
ALTER DATABASE [GenialDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GenialDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GenialDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GenialDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GenialDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GenialDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [GenialDb] SET QUERY_STORE = OFF
GO
USE [GenialDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 27/08/2024 18:20:05 ******/
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
/****** Object:  Table [dbo].[Addresses]    Script Date: 27/08/2024 18:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[Id] [uniqueidentifier] NOT NULL,
	[SupplierId] [uniqueidentifier] NOT NULL,
	[Street] [varchar](200) NOT NULL,
	[Number] [int] NOT NULL,
	[Complement] [varchar](250) NULL,
	[PostalCode] [varchar](8) NOT NULL,
	[Neighborhood] [varchar](100) NOT NULL,
	[City] [varchar](100) NOT NULL,
	[State] [varchar](50) NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 27/08/2024 18:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Brand] [varchar](100) NOT NULL,
	[Description] [varchar](1000) NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupplierProducts]    Script Date: 27/08/2024 18:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierProducts](
	[ProductId] [uniqueidentifier] NOT NULL,
	[SupplierId] [uniqueidentifier] NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_SupplierProducts] PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 27/08/2024 18:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[CNPJ] [varchar](20) NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240827194257_initial', N'8.0.8')
GO
INSERT [dbo].[Addresses] ([Id], [SupplierId], [Street], [Number], [Complement], [PostalCode], [Neighborhood], [City], [State], [CreatedDate], [UpdatedDate]) VALUES (N'c173ac45-a418-4957-864e-1780ced6b721', N'5d6d766f-50b8-424d-afd6-fae00d5b8dd5', N'Rua Jornalista Renato Ribas', 200, NULL, N'82400395', N'Butiatuvinha', N'Curitiba', N'PR', CAST(N'2024-08-27T16:44:45.1253506' AS DateTime2), NULL)
INSERT [dbo].[Addresses] ([Id], [SupplierId], [Street], [Number], [Complement], [PostalCode], [Neighborhood], [City], [State], [CreatedDate], [UpdatedDate]) VALUES (N'55432869-d8ba-4ad4-8511-5dffe155d8f4', N'56870c81-0116-4c56-b379-77694f01f748', N'Rua Domingos Agabito Budel', 588, NULL, N'82400390', N'Butiatuvinha', N'Curitiba', N'PR', CAST(N'2024-08-27T16:45:08.9002592' AS DateTime2), NULL)
GO
INSERT [dbo].[Products] ([Id], [Name], [Brand], [Description], [CreatedDate], [UpdatedDate]) VALUES (N'c17a6568-c4d8-499d-a9ae-66cc37743021', N'S24 ultra', N'Sansung', N'celular 5g', CAST(N'2024-08-27T16:46:05.4095760' AS DateTime2), NULL)
INSERT [dbo].[Products] ([Id], [Name], [Brand], [Description], [CreatedDate], [UpdatedDate]) VALUES (N'018d6879-889f-46ac-aa43-82c09c1a96c7', N'Feijão preto', N'Tio urbano', N'fsdfsdfdsfdsfds', CAST(N'2024-08-27T16:45:48.5341114' AS DateTime2), NULL)
INSERT [dbo].[Products] ([Id], [Name], [Brand], [Description], [CreatedDate], [UpdatedDate]) VALUES (N'3e422d26-2518-4ef1-beeb-b7ec93c64796', N'Chocolate Garoto', N'Garoto', N'Chocolate Garoto', CAST(N'2024-08-27T16:45:31.1385852' AS DateTime2), NULL)
GO
INSERT [dbo].[SupplierProducts] ([ProductId], [SupplierId], [Price]) VALUES (N'018d6879-889f-46ac-aa43-82c09c1a96c7', N'56870c81-0116-4c56-b379-77694f01f748', CAST(58.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Suppliers] ([Id], [Name], [CNPJ], [Phone], [CreatedDate], [UpdatedDate]) VALUES (N'56870c81-0116-4c56-b379-77694f01f748', N'Empresa 02', N'96673171000150', N'235345435', CAST(N'2024-08-27T16:45:08.9002551' AS DateTime2), NULL)
INSERT [dbo].[Suppliers] ([Id], [Name], [CNPJ], [Phone], [CreatedDate], [UpdatedDate]) VALUES (N'5d6d766f-50b8-424d-afd6-fae00d5b8dd5', N'Empresa 01', N'72246680000139', N'345435345', CAST(N'2024-08-27T16:44:45.1250716' AS DateTime2), NULL)
GO
/****** Object:  Index [IX_Addresses_SupplierId]    Script Date: 27/08/2024 18:20:05 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Addresses_SupplierId] ON [dbo].[Addresses]
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SupplierProducts_ProductId]    Script Date: 27/08/2024 18:20:05 ******/
CREATE NONCLUSTERED INDEX [IX_SupplierProducts_ProductId] ON [dbo].[SupplierProducts]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Suppliers_SupplierId] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Suppliers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Suppliers_SupplierId]
GO
ALTER TABLE [dbo].[SupplierProducts]  WITH CHECK ADD  CONSTRAINT [FK_SupplierProducts_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[SupplierProducts] CHECK CONSTRAINT [FK_SupplierProducts_Products_ProductId]
GO
ALTER TABLE [dbo].[SupplierProducts]  WITH CHECK ADD  CONSTRAINT [FK_SupplierProducts_Suppliers_SupplierId] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Suppliers] ([Id])
GO
ALTER TABLE [dbo].[SupplierProducts] CHECK CONSTRAINT [FK_SupplierProducts_Suppliers_SupplierId]
GO
USE [master]
GO
ALTER DATABASE [GenialDb] SET  READ_WRITE 
GO
