
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/30/2020 11:11:33
-- Generated from EDMX file: C:\Own\Angular7WebApi\CRUDAPI\CRUDAPI\Models\MyDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CipDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Companies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Companies];
GO
IF OBJECT_ID(N'[dbo].[Departments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departments];
GO
IF OBJECT_ID(N'[dbo].[EmployeeDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeDetails];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(max)  NOT NULL,
    [Description] varchar(max)  NOT NULL
);
GO

-- Creating table 'EmployeeDetails'
CREATE TABLE [dbo].[EmployeeDetails] (
    [EmpId] int IDENTITY(1,1) NOT NULL,
    [EmpName] varchar(50)  NULL,
    [DateOfBirth] datetime  NULL,
    [EmailId] varchar(50)  NULL,
    [Gender] nchar(10)  NULL,
    [Address] varchar(100)  NULL,
    [PinCode] varchar(50)  NULL
);
GO

-- Creating table 'Companies'
CREATE TABLE [dbo].[Companies] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [EmpId] in table 'EmployeeDetails'
ALTER TABLE [dbo].[EmployeeDetails]
ADD CONSTRAINT [PK_EmployeeDetails]
    PRIMARY KEY CLUSTERED ([EmpId] ASC);
GO

-- Creating primary key on [Id] in table 'Companies'
ALTER TABLE [dbo].[Companies]
ADD CONSTRAINT [PK_Companies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------