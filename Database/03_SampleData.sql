-- POSPOINT Sample Data Script
USE POSPOINT;
GO

-- Insert Sample Stores
INSERT INTO Stores (StoreName, StoreType, Address, City, State, PostalCode, PhoneNumber, Email, IsActive)
VALUES 
    ('POSPOINT Supermarket - Mumbai', 'Supermarket', '123 Main St', 'Mumbai', 'Maharashtra', '400001', '9123456789', 'mumbai@pospoint.com', 1),
    ('POSPOINT Chemist - Delhi', 'Chemist', '456 Medical Ave', 'Delhi', 'Delhi', '110001', '9198765432', 'delhi@pospoint.com', 1),
    ('POSPOINT Garments - Bangalore', 'Garments', '789 Fashion Blvd', 'Bangalore', 'Karnataka', '560001', '9187654321', 'bangalore@pospoint.com', 1),
    ('POSPOINT Restaurant - Chennai', 'Restaurant', '321 Food Court', 'Chennai', 'Tamil Nadu', '600001', '9176543210', 'chennai@pospoint.com', 1);

PRINT 'Sample stores inserted';
GO

-- Insert Sample Users
INSERT INTO Users (Username, PasswordHash, FullName, Email, StoreId, [Role], IsActive)
VALUES 
    ('admin', 'admin_hash_123', 'Admin User', 'admin@pospoint.com', NULL, 'Admin', 1),
    ('manager1', 'manager_hash_123', 'Store Manager', 'manager@pospoint.com', 1, 'Manager', 1),
    ('cashier1', 'cashier_hash_123', 'Cashier', 'cashier@pospoint.com', 1, 'Cashier', 1);

PRINT 'Sample users inserted';
GO

-- Insert Sample Products
INSERT INTO Products (ProductCode, ProductName, Category, UnitPrice, Quantity, Unit, IsActive)
VALUES 
    ('SKU001', 'Rice - 5kg', 'Groceries', 300.00, 100, 'Piece', 1),
    ('SKU002', 'Paracetamol 500mg', 'Medicine', 50.00, 200, 'Strip', 1),
    ('SKU003', 'Cotton T-Shirt', 'Clothing', 499.00, 50, 'Piece', 1),
    ('SKU004', 'Burger Combo', 'Food', 250.00, 75, 'Piece', 1);

PRINT 'Sample products inserted';
GO

-- Insert Sample Barcodes
INSERT INTO Barcodes (ProductId, BarcodeValue, BarcodeType, IsActive)
VALUES 
    (1, '8901234567890', 'EAN13', 1),
    (2, '8901234567891', 'EAN13', 1),
    (3, '8901234567892', 'EAN13', 1),
    (4, '8901234567893', 'EAN13', 1);

PRINT 'Sample barcodes inserted';
GO

PRINT 'All sample data inserted successfully';
