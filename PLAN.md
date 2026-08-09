# Plan de desarrollo: Biblioteca Escolar

## 1. Arquitectura propuesta

Se propone una aplicación Windows Forms organizada en capas simples dentro de una sola solución y, preferiblemente, un solo proyecto. Esta estructura es suficiente para una asignatura de Programación II y evita agregar complejidad innecesaria.

- **Presentación:** formularios Windows Forms. Muestran información, reciben datos y llaman a los servicios; no contienen reglas importantes del negocio.
- **Dominio:** entidades orientadas a objetos (`Persona`, `Usuario`, `Bibliotecario`, `Categoria`, `Libro` y `Prestamo`). Aquí se ubican los datos y comportamientos propios de cada objeto.
- **Servicios:** operaciones de negocio y CRUD. Coordinan las validaciones, los préstamos, las devoluciones y el acceso al contexto de datos.
- **Datos:** `BibliotecaContext` y configuración de Entity Framework Core para SQL Server LocalDB.

El flujo general será: **Formulario → Servicio → DbContext → LocalDB**. Los formularios no accederán directamente a la base de datos.

## 2. Estructura de carpetas

```text
BibliotecaEscolar/
├── Data/
│   ├── BibliotecaContext.cs
│   └── DbInitializer.cs
├── Models/
│   ├── Persona.cs
│   ├── Usuario.cs
│   ├── Bibliotecario.cs
│   ├── Categoria.cs
│   ├── Libro.cs
│   ├── Prestamo.cs
│   └── EstadoPrestamo.cs
├── Services/
│   ├── UsuarioService.cs
│   ├── BibliotecarioService.cs
│   ├── CategoriaService.cs
│   ├── LibroService.cs
│   └── PrestamoService.cs
├── Forms/
│   ├── FrmPrincipal.cs
│   ├── FrmUsuarios.cs
│   ├── FrmBibliotecarios.cs
│   ├── FrmCategorias.cs
│   ├── FrmLibros.cs
│   ├── FrmPrestamos.cs
│   └── FrmDevolucion.cs
├── Program.cs
└── appsettings.json
```

`EstadoPrestamo` será un `enum`, no una tecnología o capa adicional. `DbInitializer` será opcional y servirá únicamente para insertar datos iniciales sencillos, como categorías de ejemplo.

## 3. Clases y responsabilidades

Todas las clases tendrán constructor. Las entidades podrán incluir un constructor sin parámetros para Entity Framework Core y otro constructor público con los datos obligatorios para impedir que se creen objetos incompletos.

### Persona (abstracta)

Representa los datos y comportamientos comunes de una persona. No se podrá crear una `Persona` directamente. Validará y mantendrá sus datos básicos, y declarará un comportamiento abstracto para identificar el rol o producir una descripción.

### Usuario

Hereda de `Persona` y representa a quien solicita libros. Mantiene su código o carnet universitario y su estado. Puede determinar si está habilitado para pedir préstamos.

### Bibliotecario

Hereda de `Persona` y representa al empleado que registra préstamos y devoluciones. Mantiene su código de empleado y cargo.

### Categoria

Clasifica los libros. Mantiene su nombre, descripción y la colección de libros pertenecientes a ella.

### Libro

Representa un título disponible en la biblioteca. Conserva sus datos bibliográficos, categoría y cantidad de ejemplares. Expone operaciones controladas para prestar o devolver un ejemplar.

### Prestamo

Representa la entrega de un libro a un usuario, registrada por un bibliotecario. Controla fechas, estado y devolución. No permitirá devolver dos veces el mismo préstamo.

### BibliotecaContext

Hereda de `DbContext`. Expone los conjuntos de entidades, configura relaciones, restricciones e herencia, y establece la conexión con SQL Server LocalDB.

### Servicios

Cada servicio ofrece las operaciones de consulta, creación, edición y eliminación de su entidad. `PrestamoService` concentra además las reglas para prestar y devolver libros.

## 4. Propiedades de cada entidad

### Persona

- `Id`: identificador entero.
- `Cedula`: documento de identidad, obligatorio y único.
- `Nombres`: nombres de la persona, obligatorio.
- `Apellidos`: apellidos de la persona, obligatorio.
- `Correo`: correo electrónico, opcional o validado si se suministra.
- `Telefono`: teléfono, opcional.
- `NombreCompleto`: propiedad calculada a partir de nombres y apellidos.
- `Rol`: propiedad abstracta o virtual de solo lectura que cada clase derivada implementará.

### Usuario

- Hereda todas las propiedades de `Persona`.
- `Carnet`: código universitario, obligatorio y único.
- `Activo`: indica si puede solicitar préstamos.
- `Prestamos`: colección de préstamos realizados por el usuario.

### Bibliotecario

- Hereda todas las propiedades de `Persona`.
- `CodigoEmpleado`: código laboral, obligatorio y único.
- `Cargo`: cargo del bibliotecario.
- `Activo`: indica si puede registrar operaciones.
- `PrestamosRegistrados`: colección de préstamos que registró.

### Categoria

- `Id`: identificador entero.
- `Nombre`: nombre obligatorio y único.
- `Descripcion`: explicación opcional.
- `Libros`: colección de libros de la categoría.

### Libro

- `Id`: identificador entero.
- `ISBN`: código ISBN, obligatorio y único.
- `Titulo`: título obligatorio.
- `Autor`: autor obligatorio.
- `Editorial`: editorial opcional.
- `AnioPublicacion`: año de publicación.
- `CantidadTotal`: número total de ejemplares.
- `CantidadDisponible`: número de ejemplares que pueden prestarse.
- `CategoriaId`: clave foránea de la categoría.
- `Categoria`: navegación hacia la categoría.
- `Prestamos`: historial de préstamos del libro.
- `EstaDisponible`: propiedad calculada (`CantidadDisponible > 0`).

Para mantener el alcance sencillo, cada registro de `Libro` representa un título y sus cantidades; no se administrará una entidad independiente por cada ejemplar físico.

### Prestamo

- `Id`: identificador entero.
- `UsuarioId`: clave foránea del usuario que recibe el libro.
- `Usuario`: navegación hacia el usuario.
- `LibroId`: clave foránea del libro prestado.
- `Libro`: navegación hacia el libro.
- `BibliotecarioId`: clave foránea del bibliotecario que registra la operación.
- `Bibliotecario`: navegación hacia el bibliotecario.
- `FechaPrestamo`: fecha en que se entrega el libro.
- `FechaLimite`: fecha acordada para devolverlo.
- `FechaDevolucion`: fecha real de devolución; será nula mientras esté activo.
- `Estado`: valor de `EstadoPrestamo` (`Activo` o `Devuelto`).
- `EstaVencido`: propiedad calculada usando la fecha límite, el estado y la fecha actual.

Cada préstamo corresponde a un solo libro y descuenta un ejemplar disponible.

## 5. Relaciones de la base de datos

- Una `Categoria` tiene muchos `Libro`; cada `Libro` pertenece a una `Categoria`.
- Un `Usuario` tiene muchos `Prestamo`; cada `Prestamo` pertenece a un `Usuario`.
- Un `Libro` tiene muchos `Prestamo` a lo largo del tiempo; cada `Prestamo` corresponde a un `Libro`.
- Un `Bibliotecario` registra muchos `Prestamo`; cada `Prestamo` queda asociado al bibliotecario responsable.
- `Persona` es abstracta y `Usuario` y `Bibliotecario` heredan de ella. En la base de datos se usará la estrategia sencilla **TPH (Table Per Hierarchy)** de Entity Framework Core: una tabla para personas con una columna discriminadora que indique el tipo y columnas anulables para los datos específicos de usuario o bibliotecario.

Restricciones principales:

- `Cedula`, `Carnet`, `CodigoEmpleado`, `ISBN` y nombre de categoría tendrán índices únicos según corresponda.
- No se eliminará una categoría mientras tenga libros relacionados.
- No se eliminarán usuarios, bibliotecarios ni libros con historial de préstamos; se preferirá marcarlos como inactivos cuando aplique.
- `CantidadTotal` será mayor que cero y `CantidadDisponible` estará entre cero y `CantidadTotal`.
- `FechaLimite` no podrá ser anterior a `FechaPrestamo`.

## 6. Formularios necesarios

- **FrmPrincipal:** ventana inicial con menú para abrir los módulos.
- **FrmUsuarios:** listado y CRUD de usuarios.
- **FrmBibliotecarios:** listado y CRUD de bibliotecarios.
- **FrmCategorias:** listado y CRUD de categorías.
- **FrmLibros:** listado, búsqueda y CRUD de libros; mostrará existencias disponibles.
- **FrmPrestamos:** listado e historial de préstamos, filtros por estado y registro de un préstamo nuevo.
- **FrmDevolucion:** búsqueda de préstamos activos y confirmación de la devolución.

Para conservar la sencillez, cada formulario CRUD puede combinar un `DataGridView`, campos de edición y botones Nuevo, Guardar, Editar y Eliminar en la misma ventana. No se requiere un formulario separado por cada acción.

## 7. Servicios necesarios

- **UsuarioService:** listar, buscar, crear, actualizar, eliminar o desactivar usuarios; verificar carnet y cédula únicos.
- **BibliotecarioService:** CRUD de bibliotecarios; verificar código de empleado y cédula únicos.
- **CategoriaService:** CRUD de categorías y validación de nombres duplicados.
- **LibroService:** CRUD y búsqueda por título, autor o ISBN; validar categoría y cantidades.
- **PrestamoService:** listar e incluir datos relacionados, registrar préstamos y devoluciones, consultar préstamos activos o vencidos.

La operación de préstamo deberá ejecutarse como una unidad: validar usuario y bibliotecario activos, comprobar disponibilidad, crear el préstamo y disminuir `CantidadDisponible`. La devolución validará que el préstamo siga activo, guardará la fecha, cambiará el estado y aumentará `CantidadDisponible`. `SaveChanges` persistirá cada operación completa; si una parte falla, no deberá quedar una actualización parcial.

## 8. Aplicación del encapsulamiento

- Las entidades ocultarán cambios sensibles mediante setters privados o protegidos cuando Entity Framework lo permita.
- Los constructores exigirán los datos mínimos válidos.
- Métodos como `Libro.PrestarEjemplar()`, `Libro.DevolverEjemplar()` y `Prestamo.RegistrarDevolucion(fecha)` serán la única forma de modificar disponibilidad o estado.
- Las colecciones se inicializarán en el constructor y no se reemplazarán libremente desde formularios.
- Las validaciones del dominio impedirán cantidades negativas, fechas incoherentes y devoluciones repetidas.

Así, un formulario no podrá asignar directamente valores inválidos como una disponibilidad negativa o un préstamo devuelto sin fecha.

## 9. Aplicación de la abstracción

`Persona` será una clase abstracta que reúne lo esencial de cualquier persona del sistema sin representar un objeto que pueda existir por sí solo. Declarará, por ejemplo, la propiedad abstracta `Rol` o un método abstracto `ObtenerDescripcion()`. Los formularios y servicios podrán trabajar con el concepto general de persona sin conocer todos los detalles de cada tipo.

Los servicios también abstraerán el acceso a Entity Framework: la interfaz visual solicitará operaciones como guardar, prestar o devolver, sin manejar consultas SQL ni detalles de LocalDB.

## 10. Aplicación de la herencia

`Usuario` y `Bibliotecario` heredarán de `Persona`. Reutilizarán `Id`, cédula, nombres, apellidos, correo, teléfono, nombre completo y sus validaciones comunes. Cada clase agregará solamente sus propiedades particulares, evitando duplicar código.

```text
Persona (abstracta)
├── Usuario
└── Bibliotecario
```

`BibliotecaContext` también heredará de `DbContext`, como requiere Entity Framework Core, aunque la demostración principal de herencia del dominio será la jerarquía de personas.

## 11. Aplicación del polimorfismo

`Usuario` y `Bibliotecario` sobrescribirán el miembro abstracto o virtual de `Persona`. Por ejemplo, `Usuario.ObtenerDescripcion()` podrá incluir el carnet y `Bibliotecario.ObtenerDescripcion()` el código de empleado. Al recorrer una colección de `Persona`, la misma llamada ejecutará la versión correcta según el objeto real.

Esto permitirá demostrar polimorfismo de forma visible y sencilla, por ejemplo al mostrar descripciones de personas o su `Rol` en la interfaz, sin crear patrones adicionales que no necesita la asignatura.

También habrá polimorfismo por sobrescritura en el constructor y comportamiento heredado de las entidades, pero la demostración documentada se centrará en el método o propiedad sobrescrita para que sea fácil de explicar y evaluar.

## 12. Orden recomendado de implementación

1. Crear la solución y el proyecto Windows Forms en la versión de .NET elegida.
2. Agregar las carpetas base y la enumeración `EstadoPrestamo`.
3. Implementar `Persona`, `Usuario` y `Bibliotecario`, incluidos constructores y demostración de los cuatro pilares de POO.
4. Implementar `Categoria`, `Libro` y `Prestamo` con constructores, validaciones y métodos de dominio.
5. Configurar Entity Framework Core, `BibliotecaContext`, la conexión LocalDB, relaciones, restricciones e índices.
6. Crear la migración inicial y comprobar la creación de la base de datos.
7. Implementar y probar los servicios CRUD en este orden: categorías, usuarios, bibliotecarios y libros.
8. Implementar `PrestamoService` y probar primero las reglas de préstamo y devolución.
9. Crear `FrmPrincipal` y los formularios CRUD, conectándolos a los servicios.
10. Crear los formularios de préstamo y devolución y mostrar mensajes claros de validación.
11. Probar casos normales y casos inválidos: duplicados, libro sin disponibilidad, usuario inactivo, devolución repetida y fechas incorrectas.
12. Revisar nombres, interfaz, comentarios necesarios y preparar una demostración breve de encapsulamiento, abstracción, herencia y polimorfismo.

Este plan deja fuera autenticación, API web, repositorio genérico, inyección de dependencias avanzada y otros patrones que no son necesarios para cumplir el objetivo académico.
