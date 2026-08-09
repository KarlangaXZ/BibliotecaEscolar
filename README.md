# Biblioteca Escolar

Aplicación de escritorio desarrollada para la asignatura **Programación II**. Permite administrar una biblioteca escolar mediante Windows Forms, Entity Framework Core y Oracle.

## Funciones principales

- Gestión de categorías.
- Gestión de usuarios.
- Gestión de bibliotecarios.
- Gestión de libros y su disponibilidad.
- Registro de préstamos.
- Registro de devoluciones.

## Tecnologías

- C# y .NET 10 para Windows.
- Windows Forms.
- Entity Framework Core 10.
- Oracle Database mediante `Oracle.EntityFrameworkCore`.

## Requisitos

- Windows.
- SDK de .NET 10.
- Oracle Database accesible con el esquema configurado en `BibliotecaDbContext`.
- La migración existente aplicada a la base de datos.

## Compilación y ejecución

Desde la carpeta raíz de la solución:

```powershell
dotnet build BibliotecaEscolar.slnx
dotnet run --project BibliotecaEscolar/BibliotecaEscolar.csproj
```

La auditoría final del proyecto terminó con **0 errores y 0 advertencias**.

## Organización del proyecto

```text
BibliotecaEscolar/
├── Data/          Contexto de EF Core y migración existente
├── Forms/         Formularios de Windows Forms
├── Models/        Entidades y comportamiento de dominio
├── Services/      Operaciones de consulta y persistencia
└── Program.cs     Punto de entrada de la aplicación
```

`FrmPrincipal` permite abrir los módulos de usuarios, categorías, bibliotecarios, libros y préstamos. Cada servicio recibe un `BibliotecaDbContext` y utiliza EF Core para trabajar con Oracle; no se utiliza SQL manual.

## Programación orientada a objetos

- **Encapsulamiento:** las entidades protegen su estado con setters privados y lo modifican mediante métodos como `ActualizarDatos`, `CambiarDisponibilidad` y `RegistrarDevolucion`.
- **Abstracción:** `Persona` es una clase abstracta que reúne los datos y el comportamiento comunes.
- **Herencia:** `Usuario` y `Bibliotecario` heredan de `Persona`.
- **Polimorfismo:** ambas clases sobrescriben `ObtenerDescripcion()` con una descripción propia.

## Relaciones de datos

- Una categoría puede tener muchos libros.
- Un usuario puede tener muchos préstamos.
- Un bibliotecario puede registrar muchos préstamos.
- Un libro puede aparecer en muchos préstamos a lo largo del tiempo.

Las relaciones están configuradas mediante Fluent API en `BibliotecaDbContext` y usan claves foráneas explícitas.

## Consideraciones

- La aplicación conserva la base de datos Oracle y la migración inicial existente.
- Al registrar un préstamo, el libro pasa a no disponible.
- Al registrar una devolución, el préstamo queda devuelto y el libro vuelve a estar disponible.
- No se deben eliminar registros que tengan relaciones activas; los servicios validan estos casos.

