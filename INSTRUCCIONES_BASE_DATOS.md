# Instrucciones para preparar la base de datos Oracle

Este documento explica cómo preparar Oracle en otra computadora para ejecutar el proyecto Biblioteca Escolar.

## Datos de conexión utilizados por el proyecto

- Servidor: `localhost`
- Puerto: `1521`
- Service Name: `XEPDB1`
- Usuario/esquema: `BIBLIOTECA`

La aplicación utiliza Oracle Database, Entity Framework Core, el proveedor `Oracle.EntityFrameworkCore` y migraciones de EF Core.

## 1. Comprobar Oracle

Antes de continuar, Oracle Database debe estar instalado, iniciado y escuchando en `localhost:1521`. La base de datos debe ofrecer el servicio `XEPDB1`.

## 2. Crear el usuario y esquema BIBLIOTECA

Abra Oracle SQL Developer y conéctese a `XEPDB1` con una cuenta administrativa que tenga permisos para crear usuarios. Ejecute:

```sql
CREATE USER BIBLIOTECA IDENTIFIED BY Biblioteca123;

GRANT CREATE SESSION TO BIBLIOTECA;
GRANT CREATE TABLE TO BIBLIOTECA;
GRANT CREATE SEQUENCE TO BIBLIOTECA;
GRANT CREATE TRIGGER TO BIBLIOTECA;
GRANT CREATE VIEW TO BIBLIOTECA;

ALTER USER BIBLIOTECA QUOTA UNLIMITED ON USERS;
```

Estos comandos deben ejecutarse una sola vez. Si el usuario ya existe, no vuelva a crearlo.

## 3. Crear la conexión en Oracle SQL Developer

Cree una conexión con los siguientes valores:

| Campo | Valor |
|---|---|
| Connection Name | `BibliotecaEscolar` |
| Username | `BIBLIOTECA` |
| Password | `Biblioteca123` |
| Hostname | `localhost` |
| Port | `1521` |
| Connection type | `Basic` |
| Service Name | `XEPDB1` |

Use **Test** para verificar la conexión y luego pulse **Connect**.

## 4. Crear las tablas con la migración existente

Las tablas **no deben crearse manualmente**. El proyecto ya contiene la migración inicial de Entity Framework Core, que crea las tablas, claves, índices y relaciones necesarias.

Abra PowerShell o una terminal en la carpeta raíz de la solución, donde se encuentra `BibliotecaEscolar.slnx`, y ejecute en este orden:

```powershell
dotnet tool restore
dotnet build BibliotecaEscolar.slnx
dotnet tool run dotnet-ef database update --project BibliotecaEscolar/BibliotecaEscolar.csproj
```

El último comando aplica únicamente las migraciones pendientes al esquema `BIBLIOTECA`. En una instalación nueva aplicará la migración inicial incluida con el proyecto.

## 5. Comprobar las tablas

Después de aplicar la migración deben existir estas tablas:

- `USUARIOS`
- `BIBLIOTECARIOS`
- `CATEGORIAS`
- `LIBROS`
- `PRESTAMOS`
- `__EFMigrationsHistory`

Conéctese como `BIBLIOTECA` en Oracle SQL Developer y ejecute:

```sql
SELECT table_name
FROM user_tables
ORDER BY table_name;
```

La tabla `__EFMigrationsHistory` es utilizada por Entity Framework Core para registrar qué migraciones ya fueron aplicadas. No debe modificarse manualmente.

## 6. Datos opcionales de demostración

Una vez aplicada la migración, puede abrir y ejecutar `DATOS_INICIALES.sql` desde la conexión `BibliotecaEscolar`. Este paso es opcional y solo agrega información básica para demostrar el sistema; no crea tablas ni préstamos.

## 7. Ejecutar la aplicación

Desde la carpeta raíz de la solución ejecute:

```powershell
dotnet run --project BibliotecaEscolar/BibliotecaEscolar.csproj
```

## Advertencia sobre la contraseña

`Biblioteca123` es únicamente una contraseña de desarrollo académico y local. No debe utilizarse como contraseña de producción ni en un servidor accesible públicamente.

