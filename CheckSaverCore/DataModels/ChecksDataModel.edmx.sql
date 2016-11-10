
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/05/2016 14:08:40
-- Generated from EDMX file: C:\Users\natas\Source\Repos\CheckSaver\CheckSaverCore\DataModels\ChecksDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [checkSaver];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_n_Checks_n_Neighbours]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[n_Checks] DROP CONSTRAINT [FK_n_Checks_n_Neighbours];
GO
IF OBJECT_ID(N'[dbo].[FK_n_Checks_n_Stores]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[n_Checks] DROP CONSTRAINT [FK_n_Checks_n_Stores];
GO
IF OBJECT_ID(N'[dbo].[FK_n_Price_n_Products]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[n_Price] DROP CONSTRAINT [FK_n_Price_n_Products];
GO
IF OBJECT_ID(N'[dbo].[FK_n_Price_n_Stores]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[n_Price] DROP CONSTRAINT [FK_n_Price_n_Stores];
GO
IF OBJECT_ID(N'[dbo].[FK_n_Purchases_n_Checks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[n_Purchases] DROP CONSTRAINT [FK_n_Purchases_n_Checks];
GO
IF OBJECT_ID(N'[dbo].[FK_n_Purchases_n_Products]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[n_Purchases] DROP CONSTRAINT [FK_n_Purchases_n_Products];
GO
IF OBJECT_ID(N'[dbo].[FK_n_Transactions_n_Checks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[n_Transactions] DROP CONSTRAINT [FK_n_Transactions_n_Checks];
GO
IF OBJECT_ID(N'[dbo].[FK_n_Transactions_n_Neighbours]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[n_Transactions] DROP CONSTRAINT [FK_n_Transactions_n_Neighbours];
GO
IF OBJECT_ID(N'[dbo].[FK_n_Transactions_n_Neighbours1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[n_Transactions] DROP CONSTRAINT [FK_n_Transactions_n_Neighbours1];
GO
IF OBJECT_ID(N'[dbo].[FK_n_WhoWillUse_n_Neighbours]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[n_WhoWillUse] DROP CONSTRAINT [FK_n_WhoWillUse_n_Neighbours];
GO
IF OBJECT_ID(N'[dbo].[FK_n_WhoWillUse_n_Purchases]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[n_WhoWillUse] DROP CONSTRAINT [FK_n_WhoWillUse_n_Purchases];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[n_Checks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[n_Checks];
GO
IF OBJECT_ID(N'[dbo].[n_Neighbours]', 'U') IS NOT NULL
    DROP TABLE [dbo].[n_Neighbours];
GO
IF OBJECT_ID(N'[dbo].[n_Price]', 'U') IS NOT NULL
    DROP TABLE [dbo].[n_Price];
GO
IF OBJECT_ID(N'[dbo].[n_Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[n_Products];
GO
IF OBJECT_ID(N'[dbo].[n_Purchases]', 'U') IS NOT NULL
    DROP TABLE [dbo].[n_Purchases];
GO
IF OBJECT_ID(N'[dbo].[n_Stores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[n_Stores];
GO
IF OBJECT_ID(N'[dbo].[n_Transactions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[n_Transactions];
GO
IF OBJECT_ID(N'[dbo].[n_WhoWillUse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[n_WhoWillUse];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Checks'
CREATE TABLE [dbo].[Checks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NeighbourId] int  NOT NULL,
    [StoreId] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [CreationDate] datetime  NOT NULL
);
GO

-- Creating table 'Neighbours'
CREATE TABLE [dbo].[Neighbours] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Photo] nvarchar(max)  NOT NULL,
    [IsDefault] bit  NOT NULL
);
GO

-- Creating table 'Prices'
CREATE TABLE [dbo].[Prices] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProductId] int  NOT NULL,
    [StoreId] int  NOT NULL,
    [Cost] decimal(19,4)  NOT NULL,
    [Date] datetime  NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'Purchases'
CREATE TABLE [dbo].[Purchases] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CheckId] int  NOT NULL,
    [ProductId] int  NOT NULL,
    [Cost] decimal(19,4)  NOT NULL,
    [CostPerPerson] decimal(19,4)  NOT NULL,
    [Count] decimal(19,4)  NOT NULL,
    [Summ] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'Stores'
CREATE TABLE [dbo].[Stores] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(50)  NOT NULL,
    [Photo] nvarchar(max)  NOT NULL,
    [Address] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Transactions'
CREATE TABLE [dbo].[Transactions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [WhoPay] int  NOT NULL,
    [ForWhom] int  NOT NULL,
    [Summa] decimal(19,4)  NOT NULL,
    [Caption] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [IsDebitOff] bit  NOT NULL,
    [CheckId] int  NULL
);
GO

-- Creating table 'WhoWillUses'
CREATE TABLE [dbo].[WhoWillUses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NeighbourId] int  NOT NULL,
    [PurchaseId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Checks'
ALTER TABLE [dbo].[Checks]
ADD CONSTRAINT [PK_Checks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Neighbours'
ALTER TABLE [dbo].[Neighbours]
ADD CONSTRAINT [PK_Neighbours]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Prices'
ALTER TABLE [dbo].[Prices]
ADD CONSTRAINT [PK_Prices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Purchases'
ALTER TABLE [dbo].[Purchases]
ADD CONSTRAINT [PK_Purchases]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Stores'
ALTER TABLE [dbo].[Stores]
ADD CONSTRAINT [PK_Stores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [PK_Transactions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WhoWillUses'
ALTER TABLE [dbo].[WhoWillUses]
ADD CONSTRAINT [PK_WhoWillUses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [StoreId] in table 'Checks'
ALTER TABLE [dbo].[Checks]
ADD CONSTRAINT [FK_n_Checks_n_Stores]
    FOREIGN KEY ([StoreId])
    REFERENCES [dbo].[Stores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_n_Checks_n_Stores'
CREATE INDEX [IX_FK_n_Checks_n_Stores]
ON [dbo].[Checks]
    ([StoreId]);
GO

-- Creating foreign key on [CheckId] in table 'Purchases'
ALTER TABLE [dbo].[Purchases]
ADD CONSTRAINT [FK_n_Purchases_n_Checks]
    FOREIGN KEY ([CheckId])
    REFERENCES [dbo].[Checks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_n_Purchases_n_Checks'
CREATE INDEX [IX_FK_n_Purchases_n_Checks]
ON [dbo].[Purchases]
    ([CheckId]);
GO

-- Creating foreign key on [CheckId] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [FK_n_Transactions_n_Checks]
    FOREIGN KEY ([CheckId])
    REFERENCES [dbo].[Checks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_n_Transactions_n_Checks'
CREATE INDEX [IX_FK_n_Transactions_n_Checks]
ON [dbo].[Transactions]
    ([CheckId]);
GO

-- Creating foreign key on [WhoPay] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [FK_n_Transactions_n_Neighbours]
    FOREIGN KEY ([WhoPay])
    REFERENCES [dbo].[Neighbours]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_n_Transactions_n_Neighbours'
CREATE INDEX [IX_FK_n_Transactions_n_Neighbours]
ON [dbo].[Transactions]
    ([WhoPay]);
GO

-- Creating foreign key on [ForWhom] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [FK_n_Transactions_n_Neighbours1]
    FOREIGN KEY ([ForWhom])
    REFERENCES [dbo].[Neighbours]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_n_Transactions_n_Neighbours1'
CREATE INDEX [IX_FK_n_Transactions_n_Neighbours1]
ON [dbo].[Transactions]
    ([ForWhom]);
GO

-- Creating foreign key on [NeighbourId] in table 'WhoWillUses'
ALTER TABLE [dbo].[WhoWillUses]
ADD CONSTRAINT [FK_n_WhoWillUse_n_Neighbours]
    FOREIGN KEY ([NeighbourId])
    REFERENCES [dbo].[Neighbours]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_n_WhoWillUse_n_Neighbours'
CREATE INDEX [IX_FK_n_WhoWillUse_n_Neighbours]
ON [dbo].[WhoWillUses]
    ([NeighbourId]);
GO

-- Creating foreign key on [ProductId] in table 'Prices'
ALTER TABLE [dbo].[Prices]
ADD CONSTRAINT [FK_n_Price_n_Products]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_n_Price_n_Products'
CREATE INDEX [IX_FK_n_Price_n_Products]
ON [dbo].[Prices]
    ([ProductId]);
GO

-- Creating foreign key on [StoreId] in table 'Prices'
ALTER TABLE [dbo].[Prices]
ADD CONSTRAINT [FK_n_Price_n_Stores]
    FOREIGN KEY ([StoreId])
    REFERENCES [dbo].[Stores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_n_Price_n_Stores'
CREATE INDEX [IX_FK_n_Price_n_Stores]
ON [dbo].[Prices]
    ([StoreId]);
GO

-- Creating foreign key on [ProductId] in table 'Purchases'
ALTER TABLE [dbo].[Purchases]
ADD CONSTRAINT [FK_n_Purchases_n_Products]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_n_Purchases_n_Products'
CREATE INDEX [IX_FK_n_Purchases_n_Products]
ON [dbo].[Purchases]
    ([ProductId]);
GO

-- Creating foreign key on [PurchaseId] in table 'WhoWillUses'
ALTER TABLE [dbo].[WhoWillUses]
ADD CONSTRAINT [FK_n_WhoWillUse_n_Purchases]
    FOREIGN KEY ([PurchaseId])
    REFERENCES [dbo].[Purchases]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_n_WhoWillUse_n_Purchases'
CREATE INDEX [IX_FK_n_WhoWillUse_n_Purchases]
ON [dbo].[WhoWillUses]
    ([PurchaseId]);
GO

-- Creating foreign key on [NeighbourId] in table 'Checks'
ALTER TABLE [dbo].[Checks]
ADD CONSTRAINT [FK_n_Checks_n_Neighbours]
    FOREIGN KEY ([NeighbourId])
    REFERENCES [dbo].[Neighbours]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_n_Checks_n_Neighbours'
CREATE INDEX [IX_FK_n_Checks_n_Neighbours]
ON [dbo].[Checks]
    ([NeighbourId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------