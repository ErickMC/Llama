
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/11/2013 19:37:10
-- Generated from EDMX file: C:\Llama\Udem.LlamaClothingCo\Data Access Layer\Udem.LlamaClothingCo.Entities\TestModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [LlamaClothingCo];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ClientClientType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Clients] DROP CONSTRAINT [FK_ClientClientType];
GO
IF OBJECT_ID(N'[dbo].[FK_ItemItemType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Items] DROP CONSTRAINT [FK_ItemItemType];
GO
IF OBJECT_ID(N'[dbo].[FK_AddressTypeAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Addresses] DROP CONSTRAINT [FK_AddressTypeAddress];
GO
IF OBJECT_ID(N'[dbo].[FK_ItemSaleDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SaleDetails] DROP CONSTRAINT [FK_ItemSaleDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_SaleSaleDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SaleDetails] DROP CONSTRAINT [FK_SaleSaleDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_SaleClient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sales] DROP CONSTRAINT [FK_SaleClient];
GO
IF OBJECT_ID(N'[dbo].[FK_ClientBillingAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Clients] DROP CONSTRAINT [FK_ClientBillingAddress];
GO
IF OBJECT_ID(N'[dbo].[FK_ShippingAddressSale]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sales] DROP CONSTRAINT [FK_ShippingAddressSale];
GO
IF OBJECT_ID(N'[dbo].[FK_ShippingAddressClient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Clients] DROP CONSTRAINT [FK_ShippingAddressClient];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Clients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clients];
GO
IF OBJECT_ID(N'[dbo].[ClientTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClientTypes];
GO
IF OBJECT_ID(N'[dbo].[Items]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Items];
GO
IF OBJECT_ID(N'[dbo].[ItemTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ItemTypes];
GO
IF OBJECT_ID(N'[dbo].[Addresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Addresses];
GO
IF OBJECT_ID(N'[dbo].[AddressTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AddressTypes];
GO
IF OBJECT_ID(N'[dbo].[Sales]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sales];
GO
IF OBJECT_ID(N'[dbo].[SaleDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SaleDetails];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [ClientId] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [RFC] nvarchar(max)  NOT NULL,
    [BillingAddressId] int  NOT NULL,
    [ClientTypeId] int  NOT NULL,
    [IsClientActive] bit  NOT NULL,
    [TelephoneNumber] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [ShippingAddressId] int  NOT NULL
);
GO

-- Creating table 'ClientTypes'
CREATE TABLE [dbo].[ClientTypes] (
    [ClientTypeId] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [IsClientTypeActive] bit  NOT NULL
);
GO

-- Creating table 'Items'
CREATE TABLE [dbo].[Items] (
    [ItemId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Cost] decimal(18,0)  NOT NULL,
    [ItemTypeId] int  NOT NULL,
    [IsItemActive] bit  NOT NULL
);
GO

-- Creating table 'ItemTypes'
CREATE TABLE [dbo].[ItemTypes] (
    [ItemTypeId] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [IsItemTypeActive] bit  NOT NULL
);
GO

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [AddressId] int IDENTITY(1,1) NOT NULL,
    [Street] nvarchar(max)  NOT NULL,
    [Number] int  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [ZipCode] int  NOT NULL,
    [AddressTypeId] int  NOT NULL,
    [IsAddressActive] bit  NOT NULL
);
GO

-- Creating table 'AddressTypes'
CREATE TABLE [dbo].[AddressTypes] (
    [AddressTypeId] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [IsAddressTypeActive] bit  NOT NULL
);
GO

-- Creating table 'Sales'
CREATE TABLE [dbo].[Sales] (
    [SaleId] int IDENTITY(1,1) NOT NULL,
    [ClientId] int  NOT NULL,
    [SaleTotal] decimal(18,0)  NOT NULL,
    [Date] datetime  NOT NULL,
    [ShippingAddressId] int  NOT NULL
);
GO

-- Creating table 'SaleDetails'
CREATE TABLE [dbo].[SaleDetails] (
    [SaleId] int  NOT NULL,
    [ItemId] int  NOT NULL,
    [Quantity] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ClientId] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([ClientId] ASC);
GO

-- Creating primary key on [ClientTypeId] in table 'ClientTypes'
ALTER TABLE [dbo].[ClientTypes]
ADD CONSTRAINT [PK_ClientTypes]
    PRIMARY KEY CLUSTERED ([ClientTypeId] ASC);
GO

-- Creating primary key on [ItemId] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [PK_Items]
    PRIMARY KEY CLUSTERED ([ItemId] ASC);
GO

-- Creating primary key on [ItemTypeId] in table 'ItemTypes'
ALTER TABLE [dbo].[ItemTypes]
ADD CONSTRAINT [PK_ItemTypes]
    PRIMARY KEY CLUSTERED ([ItemTypeId] ASC);
GO

-- Creating primary key on [AddressId] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([AddressId] ASC);
GO

-- Creating primary key on [AddressTypeId] in table 'AddressTypes'
ALTER TABLE [dbo].[AddressTypes]
ADD CONSTRAINT [PK_AddressTypes]
    PRIMARY KEY CLUSTERED ([AddressTypeId] ASC);
GO

-- Creating primary key on [SaleId] in table 'Sales'
ALTER TABLE [dbo].[Sales]
ADD CONSTRAINT [PK_Sales]
    PRIMARY KEY CLUSTERED ([SaleId] ASC);
GO

-- Creating primary key on [SaleId], [ItemId] in table 'SaleDetails'
ALTER TABLE [dbo].[SaleDetails]
ADD CONSTRAINT [PK_SaleDetails]
    PRIMARY KEY CLUSTERED ([SaleId], [ItemId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ClientTypeId] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [FK_ClientClientType]
    FOREIGN KEY ([ClientTypeId])
    REFERENCES [dbo].[ClientTypes]
        ([ClientTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientClientType'
CREATE INDEX [IX_FK_ClientClientType]
ON [dbo].[Clients]
    ([ClientTypeId]);
GO

-- Creating foreign key on [ItemTypeId] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [FK_ItemItemType]
    FOREIGN KEY ([ItemTypeId])
    REFERENCES [dbo].[ItemTypes]
        ([ItemTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ItemItemType'
CREATE INDEX [IX_FK_ItemItemType]
ON [dbo].[Items]
    ([ItemTypeId]);
GO

-- Creating foreign key on [AddressTypeId] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [FK_AddressTypeAddress]
    FOREIGN KEY ([AddressTypeId])
    REFERENCES [dbo].[AddressTypes]
        ([AddressTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AddressTypeAddress'
CREATE INDEX [IX_FK_AddressTypeAddress]
ON [dbo].[Addresses]
    ([AddressTypeId]);
GO

-- Creating foreign key on [ItemId] in table 'SaleDetails'
ALTER TABLE [dbo].[SaleDetails]
ADD CONSTRAINT [FK_ItemSaleDetail]
    FOREIGN KEY ([ItemId])
    REFERENCES [dbo].[Items]
        ([ItemId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ItemSaleDetail'
CREATE INDEX [IX_FK_ItemSaleDetail]
ON [dbo].[SaleDetails]
    ([ItemId]);
GO

-- Creating foreign key on [SaleId] in table 'SaleDetails'
ALTER TABLE [dbo].[SaleDetails]
ADD CONSTRAINT [FK_SaleSaleDetail]
    FOREIGN KEY ([SaleId])
    REFERENCES [dbo].[Sales]
        ([SaleId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ClientId] in table 'Sales'
ALTER TABLE [dbo].[Sales]
ADD CONSTRAINT [FK_SaleClient]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[Clients]
        ([ClientId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SaleClient'
CREATE INDEX [IX_FK_SaleClient]
ON [dbo].[Sales]
    ([ClientId]);
GO

-- Creating foreign key on [BillingAddressId] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [FK_ClientBillingAddress]
    FOREIGN KEY ([BillingAddressId])
    REFERENCES [dbo].[Addresses]
        ([AddressId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientBillingAddress'
CREATE INDEX [IX_FK_ClientBillingAddress]
ON [dbo].[Clients]
    ([BillingAddressId]);
GO

-- Creating foreign key on [ShippingAddressId] in table 'Sales'
ALTER TABLE [dbo].[Sales]
ADD CONSTRAINT [FK_ShippingAddressSale]
    FOREIGN KEY ([ShippingAddressId])
    REFERENCES [dbo].[Addresses]
        ([AddressId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ShippingAddressSale'
CREATE INDEX [IX_FK_ShippingAddressSale]
ON [dbo].[Sales]
    ([ShippingAddressId]);
GO

-- Creating foreign key on [ShippingAddressId] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [FK_ShippingAddressClient]
    FOREIGN KEY ([ShippingAddressId])
    REFERENCES [dbo].[Addresses]
        ([AddressId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ShippingAddressClient'
CREATE INDEX [IX_FK_ShippingAddressClient]
ON [dbo].[Clients]
    ([ShippingAddressId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------