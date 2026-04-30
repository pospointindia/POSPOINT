-- POSPOINT Tables Creation Script
USE POSPOINT;
GO

-- Create Stores Table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Stores')
BEGIN
    CREATE TABLE Stores (
        StoreId INT PRIMARY KEY IDENTITY(1,1),
        StoreName NVARCHAR(100) NOT NULL,
        StoreType NVARCHAR(50) NOT NULL, -- Supermarket, Chemist, Garments, Restaurant
        Address NVARCHAR(255),
        City NVARCHAR(50),
        State NVARCHAR(50),
        PostalCode NVARCHAR(10),
        PhoneNumber NVARCHAR(15),
        Email NVARCHAR(100),
        IsActive BIT DEFAULT 1,
        CreatedDate DATETIME DEFAULT GETDATE(),
        UpdatedDate DATETIME,
        CreatedBy NVARCHAR(100),
        UpdatedBy NVARCHAR(100)
    );
    PRINT 'Stores table created';
END
GO

-- Create Users Table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Users')
BEGIN
    CREATE TABLE Users (
        UserId INT PRIMARY KEY IDENTITY(1,1),
        Username NVARCHAR(50) NOT NULL UNIQUE,
        PasswordHash NVARCHAR(MAX) NOT NULL,
        FullName NVARCHAR(100),
        Email NVARCHAR(100),
        StoreId INT,
        [Role] NVARCHAR(50), -- Admin, Manager, Cashier, Staff
        IsActive BIT DEFAULT 1,
        CreatedDate DATETIME DEFAULT GETDATE(),
        LastLoginDate DATETIME,
        FOREIGN KEY (StoreId) REFERENCES Stores(StoreId)
    );
    PRINT 'Users table created';
END
GO

-- Create Products Table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Products')
BEGIN
    CREATE TABLE Products (
        ProductId INT PRIMARY KEY IDENTITY(1,1),
        ProductCode NVARCHAR(50) NOT NULL UNIQUE,
        ProductName NVARCHAR(255) NOT NULL,
        Category NVARCHAR(100),
        UnitPrice DECIMAL(10, 2),
        Quantity INT DEFAULT 0,
        Unit NVARCHAR(20), -- Piece, KG, Liter, etc.
        [Description] NVARCHAR(MAX),
        IsActive BIT DEFAULT 1,
        CreatedDate DATETIME DEFAULT GETDATE(),
        UpdatedDate DATETIME
    );
    PRINT 'Products table created';
END
GO

-- Create Barcodes Table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Barcodes')
BEGIN
    CREATE TABLE Barcodes (
        BarcodeId INT PRIMARY KEY IDENTITY(1,1),
        ProductId INT NOT NULL,
        BarcodeValue NVARCHAR(100) NOT NULL UNIQUE,
        BarcodeType NVARCHAR(50), -- EAN13, Code128, QR, etc.
        IsActive BIT DEFAULT 1,
        CreatedDate DATETIME DEFAULT GETDATE(),
        FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
    );
    PRINT 'Barcodes table created';
END
GO

-- Create Batches Table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Batches')
BEGIN
    CREATE TABLE Batches (
        BatchId INT PRIMARY KEY IDENTITY(1,1),
        ProductId INT NOT NULL,
        BatchNumber NVARCHAR(50) NOT NULL,
        ManufactureDate DATE NOT NULL,
        ExpiryDate DATE NOT NULL,
        Quantity INT,
        CostPrice DECIMAL(10, 2),
        IsExpired BIT DEFAULT 0,
        CreatedDate DATETIME DEFAULT GETDATE(),
        FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
    );
    PRINT 'Batches table created';
END
GO

-- Create Inventory Table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Inventory')
BEGIN
    CREATE TABLE Inventory (
        InventoryId INT PRIMARY KEY IDENTITY(1,1),
        StoreId INT NOT NULL,
        ProductId INT NOT NULL,
        Quantity INT,
        ReorderLevel INT,
        LastRestockDate DATETIME,
        LastUpdatedDate DATETIME DEFAULT GETDATE(),
        FOREIGN KEY (StoreId) REFERENCES Stores(StoreId),
        FOREIGN KEY (ProductId) REFERENCES Products(ProductId),
        UNIQUE (StoreId, ProductId)
    );
    PRINT 'Inventory table created';
END
GO

-- Create Sales Table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Sales')
BEGIN
    CREATE TABLE Sales (
        SaleId INT PRIMARY KEY IDENTITY(1,1),
        StoreId INT NOT NULL,
        UserId INT NOT NULL,
        SaleDate DATETIME DEFAULT GETDATE(),
        TotalAmount DECIMAL(10, 2),
        DiscountAmount DECIMAL(10, 2) DEFAULT 0,
        TaxAmount DECIMAL(10, 2) DEFAULT 0,
        NetAmount DECIMAL(10, 2),
        PaymentMethod NVARCHAR(50), -- Cash, Card, UPI
        ReferenceNumber NVARCHAR(100),
        FOREIGN KEY (StoreId) REFERENCES Stores(StoreId),
        FOREIGN KEY (UserId) REFERENCES Users(UserId)
    );
    PRINT 'Sales table created';
END
GO

-- Create SaleItems Table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SaleItems')
BEGIN
    CREATE TABLE SaleItems (
        SaleItemId INT PRIMARY KEY IDENTITY(1,1),
        SaleId INT NOT NULL,
        ProductId INT NOT NULL,
        Quantity INT,
        UnitPrice DECIMAL(10, 2),
        LineAmount DECIMAL(10, 2),
        FOREIGN KEY (SaleId) REFERENCES Sales(SaleId),
        FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
    );
    PRINT 'SaleItems table created';
END
GO

PRINT 'All tables created successfully';
