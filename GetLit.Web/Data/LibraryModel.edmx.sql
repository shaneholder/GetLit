
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 02/21/2011 22:10:41
-- Generated from EDMX file: c:\projects\GetLit\GetLit.Web\Data\LibraryModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GetLit];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_LibraryTitle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Titles] DROP CONSTRAINT [FK_LibraryTitle];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Libraries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Libraries];
GO
IF OBJECT_ID(N'[dbo].[Titles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Titles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Libraries'
CREATE TABLE [dbo].[Libraries] (
    [LibraryId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Titles'
CREATE TABLE [dbo].[Titles] (
    [TitleId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [NetflixTitleId] nvarchar(max)  NOT NULL,
    [LibraryId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [LibraryId] in table 'Libraries'
ALTER TABLE [dbo].[Libraries]
ADD CONSTRAINT [PK_Libraries]
    PRIMARY KEY CLUSTERED ([LibraryId] ASC);
GO

-- Creating primary key on [TitleId] in table 'Titles'
ALTER TABLE [dbo].[Titles]
ADD CONSTRAINT [PK_Titles]
    PRIMARY KEY CLUSTERED ([TitleId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [LibraryId] in table 'Titles'
ALTER TABLE [dbo].[Titles]
ADD CONSTRAINT [FK_LibraryTitle]
    FOREIGN KEY ([LibraryId])
    REFERENCES [dbo].[Libraries]
        ([LibraryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LibraryTitle'
CREATE INDEX [IX_FK_LibraryTitle]
ON [dbo].[Titles]
    ([LibraryId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------