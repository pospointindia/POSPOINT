# POSPOINT - Modules Documentation

## Core Modules

### 1. Store Management
**Purpose**: Manage multiple store locations

**Features**:
- Create, read, update, delete stores
- Support for multiple store types:
  - Supermarket
  - Chemist/Pharmacy
  - Garment Shop
  - Restaurant
- Store details: Name, Address, Contact, Opening Hours
- Store status tracking

**Related Entities**:
- Store
- User (assigned to store)
- Inventory

**Key Operations**:
- GetAllStores()
- GetStoreById(storeId)
- AddStore(store)
- UpdateStore(store)
- DeleteStore(storeId)

---

### 2. Product Management
**Purpose**: Manage product catalog across all stores

**Features**:
- Add, edit, delete products
- Product categorization
- Product pricing
- Unit tracking (Piece, KG, Liter, etc.)
- Product descriptions
- Active/Inactive status

**Related Entities**:
- Product
- Barcode
- Batch
- Inventory

**Key Operations**:
- GetAllProducts()
- GetProductById(productId)
- GetProductByCode(productCode)
- AddProduct(product)
- UpdateProduct(product)
- DeleteProduct(productId)

---

### 3. Barcode Management
**Purpose**: Generate and manage product barcodes

**Features**:
- Support multiple barcode types:
  - EAN-13
  - Code 128
  - QR Code
- Barcode scanning integration
- Barcode validation
- Barcode linking to products

**Related Entities**:
- Barcode
- Product

**Key Operations**:
- GetBarcodesByProductId(productId)
- GetBarcodeByValue(barcodeValue)
- AddBarcode(barcode)
- GenerateBarcode(productId)
- ValidateBarcode(barcodeValue)

---

### 4. Batch & Expiry Management
**Purpose**: Track product batches and expiry dates (especially for pharmacy/supermarket)

**Features**:
- Batch number tracking
- Manufacture date tracking
- Expiry date management
- Automatic expiry alerts
- Batch-wise inventory tracking
- Batch cost price

**Related Entities**:
- Batch
- Product

**Key Operations**:
- AddBatch(batch)
- GetBatchByNumber(batchNumber)
- GetExpiringBatches(days)
- UpdateBatchStatus(batchId)
- GetBatchInventory(productId)

---

### 5. Inventory Management
**Purpose**: Track inventory across multiple locations

**Features**:
- Real-time inventory tracking
- Store-wise inventory
- Reorder level management
- Stock alerts
- Inventory history
- Stock adjustment
- Multi-store synchronization

**Related Entities**:
- Inventory
- Store
- Product
- Batch

**Key Operations**:
- GetInventory(storeId, productId)
- GetStoreInventory(storeId)
- UpdateStock(storeId, productId, quantity)
- GetLowStockItems(storeId)
- GenerateInventoryReport(storeId, date)

---

### 6. POS (Point of Sale)
**Purpose**: Handle sales transactions

**Features**:
- Create sales bills
- Multiple payment methods (Cash, Card, UPI)
- Discount management
- Tax calculation
- Receipt generation
- Sales summary
- Return management

**Related Entities**:
- Sale
- SaleItem
- Product
- User
- Store

**Key Operations**:
- CreateSale(sale, items)
- GetSaleById(saleId)
- GetSalesByStore(storeId, dateRange)
- PrintReceipt(saleId)
- ProcessReturn(saleId)

---

### 7. User Management
**Purpose**: Manage users and access control

**Features**:
- User registration
- Role-based access control (RBAC)
- Roles: Admin, Manager, Cashier, Staff
- Password management
- User status tracking
- Login history
- Store assignment

**Related Entities**:
- User
- Store
- Sale

**Key Operations**:
- GetAllUsers()
- GetUserById(userId)
- AddUser(user)
- AuthenticateUser(username, password)
- UpdateUserRole(userId, role)
- DisableUser(userId)

---

### 8. Reports & Analytics
**Purpose**: Generate business insights and reports

**Features**:
- Sales reports (daily, weekly, monthly)
- Inventory reports
- Stock movement analysis
- Top selling products
- Store performance comparison
- Revenue analysis
- Export to Excel/PDF

**Report Types**:
- Daily Sales Report
- Inventory Stock Report
- Product Movement Report
- Store Comparison Report
- Revenue Analysis
- Top Products
- Expiry Alert Report

---

## Module Dependencies

```
Store Management
    └── User Management
    └── Inventory Management
            └── Product Management
                    └── Barcode Management
                    └── Batch Management

POS System
    └── Store Management
    └── Product Management
    └── Inventory Management
    └── User Management

Reports
    └── Sales Data
    └── Inventory Data
    └── Store Data
```

## Future Modules (Planned)
- Customer Management
- Supplier Management
- Purchase Orders
- Employee Management
- Loyalty Program
- Multi-language Support
- Mobile App Integration
- Cloud Synchronization
