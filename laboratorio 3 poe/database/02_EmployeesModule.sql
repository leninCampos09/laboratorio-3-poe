USE ElectronicaVentas;
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
