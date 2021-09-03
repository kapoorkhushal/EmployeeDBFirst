
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/01/2020 17:26:36
-- Generated from EDMX file: C:\Users\khushalkapoor\source\repos\EmployeeDBFirst\EmpDb\EmpModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EmployeeDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Employee_Department]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [FK_Employee_Department];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeeProjectMapping_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmployeeProjectMapping] DROP CONSTRAINT [FK_EmployeeProjectMapping_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeeProjectMapping_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmployeeProjectMapping] DROP CONSTRAINT [FK_EmployeeProjectMapping_Project];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Department]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Department];
GO
IF OBJECT_ID(N'[dbo].[Employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employee];
GO
IF OBJECT_ID(N'[dbo].[EmployeeProjectMapping]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeProjectMapping];
GO
IF OBJECT_ID(N'[dbo].[Project]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Project];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Department'
CREATE TABLE [dbo].[Department] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Description] varchar(100)  NULL
);
GO

-- Creating table 'Employee'
CREATE TABLE [dbo].[Employee] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] varchar(50)  NOT NULL,
    [LastName] varchar(50)  NOT NULL,
    [DOB] datetime  NOT NULL,
    [DOJ] datetime  NOT NULL,
    [Address] varchar(100)  NOT NULL,
    [DepartmentID] int  NULL,
    [IsActive] varchar(10)  NULL
);
GO

-- Creating table 'EmployeeProjectMapping'
CREATE TABLE [dbo].[EmployeeProjectMapping] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EmployeeId] int  NULL,
    [ProjectId] int  NULL,
    [IsActive] varchar(10)  NULL
);
GO

-- Creating table 'Project'
CREATE TABLE [dbo].[Project] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [AccountName] varchar(100)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Department'
ALTER TABLE [dbo].[Department]
ADD CONSTRAINT [PK_Department]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Employee'
ALTER TABLE [dbo].[Employee]
ADD CONSTRAINT [PK_Employee]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmployeeProjectMapping'
ALTER TABLE [dbo].[EmployeeProjectMapping]
ADD CONSTRAINT [PK_EmployeeProjectMapping]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Project'
ALTER TABLE [dbo].[Project]
ADD CONSTRAINT [PK_Project]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [DepartmentID] in table 'Employee'
ALTER TABLE [dbo].[Employee]
ADD CONSTRAINT [FK_Employee_Department]
    FOREIGN KEY ([DepartmentID])
    REFERENCES [dbo].[Department]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Employee_Department'
CREATE INDEX [IX_FK_Employee_Department]
ON [dbo].[Employee]
    ([DepartmentID]);
GO

-- Creating foreign key on [EmployeeId] in table 'EmployeeProjectMapping'
ALTER TABLE [dbo].[EmployeeProjectMapping]
ADD CONSTRAINT [FK_EmployeeProjectMapping_Employee]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[Employee]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeProjectMapping_Employee'
CREATE INDEX [IX_FK_EmployeeProjectMapping_Employee]
ON [dbo].[EmployeeProjectMapping]
    ([EmployeeId]);
GO

-- Creating foreign key on [ProjectId] in table 'EmployeeProjectMapping'
ALTER TABLE [dbo].[EmployeeProjectMapping]
ADD CONSTRAINT [FK_EmployeeProjectMapping_Project]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[Project]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeProjectMapping_Project'
CREATE INDEX [IX_FK_EmployeeProjectMapping_Project]
ON [dbo].[EmployeeProjectMapping]
    ([ProjectId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------