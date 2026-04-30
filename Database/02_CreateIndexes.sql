-- POSPOINT Indexes Creation Script
USE POSPOINT;
GO

-- Indexes on Stores
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Stores_StoreName')
    CREATE INDEX IX_Stores_StoreName ON Stores(StoreName);
GO

-- Indexes on Users
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Users_Username')
    CREATE INDEX IX_Users_Username ON Users(Username);

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Users_StoreId')
    CREATE INDEX IX_Users_StoreId ON Users(StoreId);
GO

-- Indexes on Products
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Products_ProductCode')
    CREATE INDEX IX_Products_ProductCode ON Products(ProductCode);

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Products_Category')
    CREATE INDEX IX_Products_Category ON Products(Category);
GO

-- Indexes on Barcodes
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Barcodes_BarcodeValue')
    CREATE INDEX IX_Barcodes_BarcodeValue ON Barcodes(BarcodeValue);

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Barcodes_ProductId')
    CREATE INDEX IX_Barcodes_ProductId ON Barcodes(ProductId);
GO

-- Indexes on Batches
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Batches_ProductId')
    CREATE INDEX IX_Batches_ProductId ON Batches(ProductId);

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Batches_ExpiryDate')
    CREATE INDEX IX_Batches_ExpiryDate ON Batches(ExpiryDate);
GO

-- Indexes on Inventory
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Inventory_StoreId')
    CREATE INDEX IX_Inventory_StoreId ON Inventory(StoreId);

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Inventory_ProductId')
    CREATE INDEX IX_Inventory_ProductId ON Inventory(ProductId);
GO

-- Indexes on Sales
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Sales_StoreId')
    CREATE INDEX IX_Sales_StoreId ON Sales(StoreId);

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Sales_SaleDate')
    CREATE INDEX IX_Sales_SaleDate ON Sales(SaleDate);
GO

-- Indexes on SaleItems
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_SaleItems_SaleId')
    CREATE INDEX IX_SaleItems_SaleId ON SaleItems(SaleId);

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_SaleItems_ProductId')
    CREATE INDEX IX_SaleItems_ProductId ON SaleItems(ProductId);
GO

PRINT 'All indexes created successfully';
