IF DB_ID(N'ElectronicaVentas') IS NULL
	CREATE DATABASE ElectronicaVentas;
GO

USE ElectronicaVentas;
GO

IF OBJECT_ID(N'dbo.Employees', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.Employees
	(
		EmployeeId INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Employees PRIMARY KEY,
		Username NVARCHAR(50) NOT NULL CONSTRAINT UQ_Employees_Username UNIQUE,
		PasswordHash BINARY(32) NOT NULL,
		FullName NVARCHAR(120) NOT NULL,
		IsActive BIT NOT NULL CONSTRAINT DF_Employees_IsActive DEFAULT (1),
		Role NVARCHAR(20) NOT NULL CONSTRAINT DF_Employees_Role DEFAULT (N'Empleado'),
		CONSTRAINT CK_Employees_Role CHECK (Role IN (N'Administrador', N'Empleado'))
	);
END;
GO

IF COL_LENGTH(N'dbo.Employees', N'Role') IS NULL
BEGIN
    ALTER TABLE dbo.Employees
        ADD Role NVARCHAR(20) NOT NULL
            CONSTRAINT DF_Employees_Role DEFAULT (N'Empleado') WITH VALUES;
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM sys.check_constraints
    WHERE name = N'CK_Employees_Role'
      AND parent_object_id = OBJECT_ID(N'dbo.Employees')
)
BEGIN
    ALTER TABLE dbo.Employees
        ADD CONSTRAINT CK_Employees_Role CHECK (Role IN (N'Administrador', N'Empleado'));
END;
GO

UPDATE dbo.Employees
SET Role = N'Administrador'
WHERE Username = N'admin' AND Role <> N'Administrador';
GO

IF OBJECT_ID(N'dbo.Products', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.Products
	(
		ProductId INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Products PRIMARY KEY,
		Name NVARCHAR(120) NOT NULL,
		Description NVARCHAR(500) NOT NULL CONSTRAINT DF_Products_Description DEFAULT (N''),
		Price DECIMAL(12,2) NOT NULL,
		Stock INT NOT NULL CONSTRAINT DF_Products_Stock DEFAULT (0),
		CONSTRAINT CK_Products_Price CHECK (Price > 0),
		CONSTRAINT CK_Products_Stock CHECK (Stock >= 0)
	);
END;
GO

IF OBJECT_ID(N'dbo.Sales', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.Sales
	(
		SaleId INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Sales PRIMARY KEY,
		EmployeeId INT NOT NULL,
		SoldAt DATETIME2(0) NOT NULL CONSTRAINT DF_Sales_SoldAt DEFAULT (SYSDATETIME()),
		CONSTRAINT FK_Sales_Employees FOREIGN KEY (EmployeeId) REFERENCES dbo.Employees(EmployeeId)
	);
END;
GO

IF OBJECT_ID(N'dbo.SaleDetails', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.SaleDetails
	(
		SaleDetailId INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_SaleDetails PRIMARY KEY,
		SaleId INT NOT NULL,
		ProductId INT NOT NULL,
		Quantity INT NOT NULL,
		UnitPrice DECIMAL(12,2) NOT NULL,
		CONSTRAINT FK_SaleDetails_Sales FOREIGN KEY (SaleId) REFERENCES dbo.Sales(SaleId),
		CONSTRAINT FK_SaleDetails_Products FOREIGN KEY (ProductId) REFERENCES dbo.Products(ProductId),
		CONSTRAINT CK_SaleDetails_Quantity CHECK (Quantity > 0),
		CONSTRAINT CK_SaleDetails_UnitPrice CHECK (UnitPrice > 0)
	);
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Employees WHERE Username = N'admin')
BEGIN
	INSERT dbo.Employees (Username, PasswordHash, FullName, IsActive, Role)
	VALUES (N'admin', HASHBYTES('SHA2_256', CONVERT(VARCHAR(100), 'Admin123!')), N'Administrador', 1, N'Administrador');
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Products)
BEGIN
	INSERT dbo.Products (Name, Description, Price, Stock)
	VALUES
		(N'Mouse inalámbrico', N'Mouse óptico USB', 14.99, 18),
		(N'Teclado mecánico', N'Teclado USB retroiluminado', 59.90, 5),
		(N'Audífonos', N'Audífonos estéreo con micrófono', 34.50, 2);
END;
GO
