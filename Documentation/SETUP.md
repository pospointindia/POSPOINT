# POSPOINT - Setup Guide

## Prerequisites

### System Requirements
- **OS**: Windows 10 or later
- **RAM**: Minimum 4 GB (8 GB recommended)
- **Storage**: 500 MB free space
- **SQL Server**: 2019 or later

### Software Requirements
- **.NET 8 SDK**: Download from [dotnet.microsoft.com](https://dotnet.microsoft.com/download/dotnet/8.0)
- **Visual Studio 2022**: Download from [visualstudio.microsoft.com](https://visualstudio.microsoft.com/)
- **SQL Server**: Download from [microsoft.com/sql-server](https://www.microsoft.com/sql-server/)
- **SQL Server Management Studio (SSMS)**: Optional but recommended

## Installation Steps

### 1. Clone the Repository
```bash
git clone https://github.com/pospointindia/POSPOINT.git
cd POSPOINT
```

### 2. Install .NET 8 SDK
- Download .NET 8 SDK from the official website
- Follow installation instructions
- Verify installation:
  ```bash
  dotnet --version
  ```

### 3. Install SQL Server
- Download SQL Server 2019 or later
- Run the installer
- Choose "Developer Edition" for development
- Note down your SA password

### 4. Create Database
- Open SQL Server Management Studio (SSMS)
- Connect to your SQL Server instance
- Create a new database or use existing instance

### 5. Execute SQL Scripts
- In SSMS, open `Database/00_CreateDatabase.sql`
- Execute the script
- Open `Database/01_CreateTables.sql`
- Execute the script
- Open `Database/02_CreateIndexes.sql`
- Execute the script
- Open `Database/03_SampleData.sql`
- Execute the script

### 6. Configure Connection String
- Open `src/POSPOINT.UI/App.config`
- Update the connection string:
  ```xml
  <connectionStrings>
    <add name="POSPOINT" 
         connectionString="Server=YOUR_SERVER;Database=POSPOINT;User Id=sa;Password=YOUR_PASSWORD;" 
         providerName="System.Data.SqlClient" />
  </connectionStrings>
  ```

### 7. Open Solution in Visual Studio
- Open `POSPOINT.sln` in Visual Studio 2022
- Wait for NuGet packages to restore
- Build the solution: `Ctrl+Shift+B`

### 8. Run the Application
- Set `POSPOINT.UI` as startup project
- Press `F5` or click Run
- Application will launch

## Troubleshooting

### Connection String Issues
- Verify SQL Server is running
- Check firewall settings
- Ensure credentials are correct

### Build Errors
- Clean solution: `Ctrl+Alt+Delete` (Clean Solution)
- Rebuild: `Ctrl+Shift+B`
- Check NuGet packages are restored

### Database Errors
- Verify SQL Server instance name
- Ensure database exists
- Check SSMS connection

## Default Login Credentials

**For Development/Testing Only**
- **Username**: admin
- **Password**: admin_hash_123 (Change in production)

## Next Steps

1. Explore the application
2. Review the code structure
3. Customize for your requirements
4. Implement additional modules as needed
5. Deploy to production
