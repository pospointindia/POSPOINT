-- POSPOINT Premium Features Tables
USE POSPOINT;
GO

-- Create BarcodeTemplates Table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'BarcodeTemplates')
BEGIN
    CREATE TABLE BarcodeTemplates (
        BarcodeTemplateId INT PRIMARY KEY IDENTITY(1,1),
        TemplateName NVARCHAR(100) NOT NULL,
        Width INT, -- e.g., 38
        Height INT, -- e.g., 25
        Unit NVARCHAR(10) DEFAULT 'mm',
        BarcodesPerRow INT, -- e.g., 2
        BarcodesPerColumn INT,
        IsActive BIT DEFAULT 1,
        CreatedDate DATETIME DEFAULT GETDATE()
    );
    PRINT 'BarcodeTemplates table created';
END
GO

-- Create PricingSlabs Table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PricingSlabs')
BEGIN
    CREATE TABLE PricingSlabs (
        PricingSlabId INT PRIMARY KEY IDENTITY(1,1),
        VariantId INT NOT NULL,
        SlabSize INT, -- e.g., 10 units
        NormalPrice DECIMAL(10, 2), -- ₹10
        DiscountPrice DECIMAL(10, 2), -- ₹9
        DiscountPercentage DECIMAL(5, 2),
        StartDate DATETIME,
        EndDate DATETIME,
        IsActive BIT DEFAULT 1,
        CreatedDate DATETIME DEFAULT GETDATE(),
        UpdatedDate DATETIME,
        FOREIGN KEY (VariantId) REFERENCES Variants(VariantId)
    );
    PRINT 'PricingSlabs table created';
END
GO

-- Create SalesMan Table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SalesMen')
BEGIN
    CREATE TABLE SalesMen (
        SalesManId INT PRIMARY KEY IDENTITY(1,1),
        SalesManName NVARCHAR(100) NOT NULL,
        SalesManCode NVARCHAR(50) NOT NULL UNIQUE,
        Email NVARCHAR(100),
        PhoneNumber NVARCHAR(15),
        StoreId INT,
        CommissionPercentage DECIMAL(5, 2),
        IsActive BIT DEFAULT 1,
        CreatedDate DATETIME DEFAULT GETDATE(),
        FOREIGN KEY (StoreId) REFERENCES Stores(StoreId)
    );
    PRINT 'SalesMen table created';
END
GO

-- Create Transporter Table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Transporters')
BEGIN
    CREATE TABLE Transporters (
        TransporterId INT PRIMARY KEY IDENTITY(1,1),
        TransporterName NVARCHAR(100) NOT NULL,
        ContactPerson NVARCHAR(100),
        PhoneNumber NVARCHAR(15),
        Email NVARCHAR(100),
        Address NVARCHAR(255),
        RatePerKm DECIMAL(10, 2),
        IsActive BIT DEFAULT 1,
        CreatedDate DATETIME DEFAULT GETDATE()
    );
    PRINT 'Transporters table created';
END
GO

-- Update Sales Table to add SalesMan, Transporter, and ShipTo info
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Sales' AND COLUMN_NAME = 'SalesManId')
BEGIN
    ALTER TABLE Sales ADD SalesManId INT, 
                        ShipToName NVARCHAR(100),
                        ShipToAddress NVARCHAR(255),
                        ShipToCity NVARCHAR(50),
                        TransporterId INT,
                        LorryNumber NVARCHAR(50);
    PRINT 'Sales table updated with SalesMan and Transporter fields';
END
GO

-- Create PurchaseOrder Table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PurchaseOrders')
BEGIN
    CREATE TABLE PurchaseOrders (
        PurchaseOrderId INT PRIMARY KEY IDENTITY(1,1),
        PONumber NVARCHAR(50) NOT NULL UNIQUE,
        SupplierId INT,
        PODate DATETIME DEFAULT GETDATE(),
        DeliveryDate DATETIME,
        Status NVARCHAR(50) DEFAULT 'Pending', -- Pending, Confirmed, Partial, Received, Cancelled
        TotalAmount DECIMAL(10, 2),
        TaxAmount DECIMAL(10, 2),
        NetAmount DECIMAL(10, 2),
        Notes NVARCHAR(MAX),
        CreatedDate DATETIME DEFAULT GETDATE(),
        FOREIGN KEY (SupplierId) REFERENCES Parties(PartyId)
    );
    PRINT 'PurchaseOrders table created';
END
GO

-- Create PurchaseOrderItems Table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PurchaseOrderItems')
BEGIN
    CREATE TABLE PurchaseOrderItems (
        PurchaseOrderItemId INT PRIMARY KEY IDENTITY(1,1),
        PurchaseOrderId INT NOT NULL,
        VariantId INT NOT NULL,
        Quantity INT,
        UnitPrice DECIMAL(10, 2),
        LineAmount DECIMAL(10, 2),
        ReceivedQuantity INT DEFAULT 0,
        ReceivedDate DATETIME,
        FOREIGN KEY (PurchaseOrderId) REFERENCES PurchaseOrders(PurchaseOrderId),
        FOREIGN KEY (VariantId) REFERENCES Variants(VariantId)
    );
    PRINT 'PurchaseOrderItems table created';
END
GO

-- Create GSTReport Table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'GSTReports')
BEGIN
    CREATE TABLE GSTReports (
        GSTReportId INT PRIMARY KEY IDENTITY(1,1),
        StoreId INT NOT NULL,
        GSTPeriod NVARCHAR(50), -- e.g., "April-2026"
        StartDate DATETIME,
        EndDate DATETIME,
        TotalSales DECIMAL(12, 2),
        TotalPurchase DECIMAL(12, 2),
        OutputGST DECIMAL(12, 2), -- GST on Sales (usually 18%)
        InputGST DECIMAL(12, 2), -- GST on Purchases
        GSTPayable DECIMAL(12, 2), -- OutputGST - InputGST
        Status NVARCHAR(50) DEFAULT 'Draft', -- Draft, Submitted, Approved
        CreatedDate DATETIME DEFAULT GETDATE(),
        FOREIGN KEY (StoreId) REFERENCES Stores(StoreId)
    );
    PRINT 'GSTReports table created';
END
GO

-- Create Backup Table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Backups')
BEGIN
    CREATE TABLE Backups (
        BackupId INT PRIMARY KEY IDENTITY(1,1),
        BackupName NVARCHAR(255) NOT NULL,
        BackupPath NVARCHAR(MAX) NOT NULL,
        BackupSize BIGINT, -- in bytes
        BackupDate DATETIME DEFAULT GETDATE(),
        BackupType NVARCHAR(50) DEFAULT 'Full', -- Full, Incremental, Differential
        Status NVARCHAR(50) DEFAULT 'Completed', -- In Progress, Completed, Failed
        ErrorMessage NVARCHAR(MAX),
        CreatedDate DATETIME DEFAULT GETDATE()
    );
    PRINT 'Backups table created';
END
GO

PRINT 'All premium feature tables created successfully';
