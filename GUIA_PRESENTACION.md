# Guía de presentación — Biblioteca Escolar

Esta guía propone una exposición breve, clara y centrada en los contenidos de Programación II.

## 1. Introducción

> Biblioteca Escolar es una aplicación de escritorio creada con C# y Windows Forms. Su propósito es administrar categorías, usuarios, bibliotecarios y libros, además de controlar el préstamo y la devolución de ejemplares. Los datos se guardan en Oracle mediante Entity Framework Core.

Duración sugerida: 30 a 45 segundos.

## 2. Explicación de la estructura

Mostrar en Visual Studio las carpetas principales:

- `Models`: representa las entidades y contiene las reglas de dominio.
- `Data`: contiene `BibliotecaDbContext`, la configuración de relaciones y la migración.
- `Services`: concentra las operaciones de consulta, creación, modificación y eliminación.
- `Forms`: contiene la interfaz gráfica y llama a los servicios.

Idea clave para explicar:

> El formulario recoge los datos, el servicio realiza la operación y Entity Framework Core se comunica con Oracle.

Duración sugerida: 1 minuto.

## 3. Demostración de POO

### Encapsulamiento

Mostrar una entidad, por ejemplo `Libro` o `Prestamo`:

- Las propiedades tienen setters privados.
- `ActualizarDatos()` controla los cambios de información.
- `CambiarDisponibilidad()` modifica el estado del libro.
- `RegistrarDevolucion()` valida y actualiza el préstamo.

Explicación sugerida:

> El estado de los objetos no se modifica libremente desde cualquier parte. Los cambios se hacen mediante métodos que pueden validar las reglas del sistema.

### Abstracción

Mostrar `Persona` y señalar que es `abstract`.

> Persona contiene los datos comunes de una persona, pero no se instancia directamente porque el sistema trabaja con usuarios o bibliotecarios.

### Herencia

Mostrar las declaraciones de `Usuario` y `Bibliotecario`.

> Ambas clases heredan nombre, apellidos y teléfono de Persona, evitando repetir esos elementos.

### Polimorfismo

Mostrar `ObtenerDescripcion()` en las dos clases derivadas.

> El mismo método produce una descripción diferente según el objeto sea un usuario o un bibliotecario.

Duración sugerida: 2 minutos.

## 4. Entity Framework Core y Oracle

Mostrar `BibliotecaDbContext` y explicar:

- Los `DbSet` representan las tablas manejadas por la aplicación.
- `UseOracle` configura el proveedor de Oracle.
- La Fluent API define tablas, claves, restricciones y relaciones.
- Los servicios utilizan LINQ y `SaveChangesAsync()`; no hay SQL manual.

Relaciones que conviene mencionar:

- `Categoria` uno a muchos con `Libro`.
- `Usuario` uno a muchos con `Prestamo`.
- `Bibliotecario` uno a muchos con `Prestamo`.
- `Libro` uno a muchos con `Prestamo`.

Duración sugerida: 1 a 2 minutos.

## 5. Demostración de la aplicación

Orden recomendado:

1. Abrir `FrmPrincipal` y presentar sus cinco módulos.
2. Entrar en Categorías y mostrar el listado.
3. Entrar en Usuarios y Bibliotecarios.
4. Entrar en Libros y señalar categoría y disponibilidad.
5. Registrar un préstamo con un libro disponible.
6. Verificar que el libro deja de aparecer como disponible.
7. Registrar la devolución.
8. Verificar que el estado cambia a devuelto y el libro vuelve a estar disponible.

Usar datos preparados y conocidos para que la demostración sea corta. No eliminar información importante durante la exposición.

Duración sugerida: 3 minutos.

## 6. Cierre

> El proyecto cumple el objetivo de gestionar una biblioteca escolar de forma sencilla. Aplica los cuatro pilares de POO, separa interfaz, servicios, modelos y acceso a datos, y persiste la información en Oracle mediante Entity Framework Core. La solución fue compilada para la entrega con cero errores y cero advertencias.

## Preguntas probables

### ¿Por qué `Persona` es abstracta?

Porque representa características comunes, pero una persona dentro de este sistema debe ser específicamente un usuario o un bibliotecario.

### ¿Por qué se usan setters privados?

Para proteger el estado de las entidades y obligar a realizar cambios mediante métodos controlados.

### ¿Dónde se demuestra el polimorfismo?

En `ObtenerDescripcion()`: está declarado en `Persona` y sobrescrito por `Usuario` y `Bibliotecario`.

### ¿Cómo se evita prestar un libro no disponible?

`PrestamoService` comprueba la disponibilidad antes de crear el préstamo. Después utiliza `CambiarDisponibilidad(false)`.

### ¿Qué sucede durante una devolución?

El préstamo ejecuta `RegistrarDevolucion()`, guarda la fecha, cambia su estado y el libro recupera su disponibilidad.

### ¿Cómo se accede a la base de datos?

Mediante `BibliotecaDbContext`, LINQ y Entity Framework Core con el proveedor de Oracle. No se escriben consultas SQL manuales.

### ¿Por qué existen servicios?

Para evitar que los formularios contengan directamente toda la lógica de acceso a datos y mantener el proyecto fácil de entender.

## Lista de verificación antes de exponer

- Confirmar que Oracle está iniciado y accesible.
- Abrir la aplicación antes de comenzar la demostración.
- Verificar que haya al menos un usuario, un bibliotecario, una categoría y un libro disponible.
- Elegir de antemano el libro que se prestará y devolverá.
- Compilar con `dotnet build BibliotecaEscolar.slnx`.
- Evitar modificar la conexión, ejecutar migraciones o borrar datos durante la presentación.
