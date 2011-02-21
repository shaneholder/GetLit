
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 02/20/2011 21:15:46
-- Generated from EDMX file: c:\Projects\getlit\GetLit.Web\Data\LibraryModel.edmx
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


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
    [Library_LibraryId] int  NOT NULL
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

-- Creating foreign key on [Library_LibraryId] in table 'Titles'
ALTER TABLE [dbo].[Titles]
ADD CONSTRAINT [FK_LibraryTitle]
    FOREIGN KEY ([Library_LibraryId])
    REFERENCES [dbo].[Libraries]
        ([LibraryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LibraryTitle'
CREATE INDEX [IX_FK_LibraryTitle]
ON [dbo].[Titles]
    ([Library_LibraryId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------