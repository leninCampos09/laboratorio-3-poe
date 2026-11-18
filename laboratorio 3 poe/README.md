# Sistema de ventas - Laboratorio 3

Aplicación de escritorio Windows Forms para una tienda de productos electrónicos. Incluye inicio de sesión con contraseñas SHA-256, persistencia con RepoDb y SQL Server, catálogo, registro de ventas en transacción, reportes y alerta visual de existencias críticas.

## Requisitos

- Windows con .NET 10 SDK/runtime y Windows Forms.
- SQL Server instalado y accesible en la instancia `LENINCAMPOS09`.

## Preparar la base de datos

1. Abra SQL Server Management Studio o Azure Data Studio.
2. Ejecute `database/01_CreateDatabase.sql` con una cuenta que pueda crear la base de datos.
3. Para una base de datos existente, ejecute también `database/02_EmployeesModule.sql` para agregar los roles de administrador y empleado.
4. La aplicación usa por defecto `Data Source=LENINCAMPOS09;Initial Catalog=ElectronicaVentas;Integrated Security=True;Trust Server Certificate=True`.
5. Para otra instancia, defina `VENTAS_CONNECTION_STRING` antes de iniciar la aplicación.

La cadena usa autenticación integrada de Windows; también puede sobrescribirse mediante la variable de entorno `VENTAS_CONNECTION_STRING`.

## Ejecutar

Desde Visual Studio abra `laboratorio 3 poe.slnx`, restaure NuGet y ejecute el proyecto. También puede ejecutar `dotnet run --project "laboratorio 3 poe/laboratorio 3 poe.csproj"`.

Usuario inicial: `admin`  
Contraseña inicial: `Admin123!`

Cambie la contraseña inicial y proteja la instancia antes de usar este ejemplo fuera del entorno académico. La contraseña se compara con su hash SHA-256 y nunca se persiste en texto plano. SHA-256 sin salt se usa para ajustarse al requisito académico; para un sistema real se recomienda Argon2id, bcrypt o PBKDF2 con salt individual y factor de trabajo.

## Funcionalidad

- **Productos / stock:** catálogo editable con formularios modales (`ShowDialog`), consulta por nombre y resaltado rojo de existencias iguales o menores a 5.
- **Registrar venta:** formulario modal para producto y cantidad. Guarda venta/detalle y descuenta existencias dentro de una transacción.
- **Reporte de ventas:** filtro por rango de fechas y exportación de los resultados a CSV, Excel (`.xlsx`) o PDF.
- **Empleados:** módulo exclusivo para administradores con alta, edición, cambio de contraseña, rol y estado activo/inactivo. Las contraseñas nuevas se guardan como SHA-256; al editar, dejar la contraseña vacía conserva el hash existente.
- **Repositorios:** `IRepository<T>` y `RepoDbRepository<T>` con consultas, inserción y actualización mediante RepoDb.

## Capas principales

- `Models`: modelos mapeados a las tablas.
- `Data`: inicialización/conexión, repositorio genérico y operaciones de ventas/reportes.
- `Services`: autenticación y hash SHA-256.
- `Forms`: login, menú principal y formularios modales.
- `database`: creación de la base de datos y datos iniciales.
