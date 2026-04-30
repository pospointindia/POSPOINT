# POSPOINT - Multi-Location Retail ERP System

## Overview
POSPOINT is a comprehensive enterprise retail management system designed for multi-location businesses including supermarkets, chemist/pharmacy shops, garment stores, and restaurants.

## Features
- 🏪 **Multi-Location Management**: Manage multiple stores and branches
- 📦 **Inventory Management**: Real-time inventory tracking across locations
- 🏷️ **Barcode System**: Complete barcode scanning and management
- 💊 **Batch & Expiry Tracking**: Especially for pharmacy and supermarket items
- 🛒 **POS System**: Modern point of sale system
- 👥 **User Management**: Role-based access control
- 📊 **Reports & Analytics**: Comprehensive reporting dashboard
- 💻 **Desktop Application**: WPF-based modern UI

## Technology Stack
- **Framework**: .NET 8
- **UI**: WPF (Windows Presentation Foundation)
- **Database**: SQL Server
- **Architecture**: MVVM (Model-View-ViewModel)
- **Language**: C#

## Project Structure
```
POSPOINT/
├── POSPOINT.sln
├── src/
│   ├── POSPOINT.UI/              # WPF Application (.NET 8)
│   ├── POSPOINT.Core/            # Core business logic
│   ├── POSPOINT.Data/            # Data access layer
│   └── POSPOINT.Models/          # Data models and entities
├── Database/                      # SQL Server scripts
└── Documentation/                 # Project documentation
```

## Prerequisites
- Windows 10 or later
- .NET 8 SDK
- SQL Server 2019 or later
- Visual Studio 2022

## Getting Started
1. Clone the repository
2. Open `POSPOINT.sln` in Visual Studio 2022
3. Update the connection string in `App.config`
4. Run the database migration scripts from `Database/` folder
5. Build and run the application

## Documentation
Detailed documentation is available in the `Documentation/` folder:
- **SETUP.md**: Installation and setup guide
- **ARCHITECTURE.md**: Technical architecture and design patterns
- **MODULES.md**: Complete module documentation

## License
This is a proprietary commercial software.

## Author
POSPOINT India
