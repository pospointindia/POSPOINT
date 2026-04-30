-- POSPOINT Premium Features Indexes
USE POSPOINT;
GO

-- PricingSlabs Indexes
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_PricingSlabs_VariantId')
    CREATE INDEX IX_PricingSlabs_VariantId ON PricingSlabs(VariantId);

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_PricingSlabs_DateRange')
    CREATE INDEX IX_PricingSlabs_DateRange ON PricingSlabs(StartDate, EndDate);
GO

-- SalesMen Indexes
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_SalesMen_Code')
    CREATE INDEX IX_SalesMen_Code ON SalesMen(SalesManCode);
GO

-- PurchaseOrders Indexes
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_PurchaseOrders_PONumber')
    CREATE INDEX IX_PurchaseOrders_PONumber ON PurchaseOrders(PONumber);

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_PurchaseOrders_Status')
    CREATE INDEX IX_PurchaseOrders_Status ON PurchaseOrders(Status);
GO

-- GSTReports Indexes
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_GSTReports_StorePeriod')
    CREATE INDEX IX_GSTReports_StorePeriod ON GSTReports(StoreId, GSTPeriod);
GO

-- Sales table indexes for new fields
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Sales_SalesManId')
    CREATE INDEX IX_Sales_SalesManId ON Sales(SalesManId);

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Sales_TransporterId')
    CREATE INDEX IX_Sales_TransporterId ON Sales(TransporterId);
GO

PRINT 'All premium feature indexes created successfully';
