-- DATOS INICIALES OPCIONALES PARA BIBLIOTECA ESCOLAR
-- Ejecutar solamente después de aplicar la migración de Entity Framework Core.
-- Este archivo no crea tablas ni registra préstamos. Solo carga datos de demostración.
-- Debe ejecutarse en Oracle SQL Developer conectado con el usuario BIBLIOTECA.

-- Categorías de ejemplo.
INSERT INTO CATEGORIAS ("Nombre", "Descripcion")
SELECT 'Literatura', 'Novelas, cuentos y obras literarias'
FROM DUAL
WHERE NOT EXISTS (
    SELECT 1 FROM CATEGORIAS WHERE "Nombre" = 'Literatura'
);

INSERT INTO CATEGORIAS ("Nombre", "Descripcion")
SELECT 'Ciencia', 'Libros de ciencias naturales y exactas'
FROM DUAL
WHERE NOT EXISTS (
    SELECT 1 FROM CATEGORIAS WHERE "Nombre" = 'Ciencia'
);

INSERT INTO CATEGORIAS ("Nombre", "Descripcion")
SELECT 'Historia', 'Libros sobre acontecimientos y procesos históricos'
FROM DUAL
WHERE NOT EXISTS (
    SELECT 1 FROM CATEGORIAS WHERE "Nombre" = 'Historia'
);

-- Usuario de ejemplo. ID_USUARIO es Identity y Oracle lo genera automáticamente.
INSERT INTO USUARIOS ("Matricula", "Nombre", "Apellidos", "Telefono")
SELECT 'EST-DEM-001', 'Ana', 'Pérez', '0412-0000001'
FROM DUAL
WHERE NOT EXISTS (
    SELECT 1 FROM USUARIOS WHERE "Matricula" = 'EST-DEM-001'
);

-- Bibliotecario de ejemplo. ID_BIBLIOTECARIO es Identity.
INSERT INTO BIBLIOTECARIOS ("CodigoEmpleado", "Nombre", "Apellidos", "Telefono")
SELECT 'BIB-DEM-001', 'Carlos', 'Ramírez', '0412-0000002'
FROM DUAL
WHERE NOT EXISTS (
    SELECT 1 FROM BIBLIOTECARIOS WHERE "CodigoEmpleado" = 'BIB-DEM-001'
);

-- Libros de ejemplo. ID_LIBRO es Identity y Disponible usa 1 para indicar verdadero.
INSERT INTO LIBROS ("Titulo", "Autor", "ISBN", "AnioPublicacion", "Disponible", ID_CATEGORIA)
SELECT
    'Don Quijote de la Mancha',
    'Miguel de Cervantes',
    '9788420412146',
    1605,
    1,
    (SELECT MIN(ID_CATEGORIA) FROM CATEGORIAS WHERE "Nombre" = 'Literatura')
FROM DUAL
WHERE NOT EXISTS (
    SELECT 1 FROM LIBROS WHERE "ISBN" = '9788420412146'
);

INSERT INTO LIBROS ("Titulo", "Autor", "ISBN", "AnioPublicacion", "Disponible", ID_CATEGORIA)
SELECT
    'Breve historia del tiempo',
    'Stephen Hawking',
    '9788498920572',
    1988,
    1,
    (SELECT MIN(ID_CATEGORIA) FROM CATEGORIAS WHERE "Nombre" = 'Ciencia')
FROM DUAL
WHERE NOT EXISTS (
    SELECT 1 FROM LIBROS WHERE "ISBN" = '9788498920572'
);

COMMIT;
