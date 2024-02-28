Create Database DATA

USE DATA

-- Crear la tabla 'datos'
CREATE TABLE datos (
    id_datos INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(50) NOT NULL,
    correo VARCHAR(50) NOT NULL,
    tipo VARCHAR(50) NOT NULL
);

-- Crear la tabla 'alumno' con llave foránea de 'datos'
CREATE TABLE alumno (
    numero_control INT PRIMARY KEY,
    carrera VARCHAR(50) NOT NULL,
    id_datos INT NOT NULL,
    FOREIGN KEY (id_datos) REFERENCES datos(id_datos)
);

-- Crear la tabla 'subdireccion' con llave foránea de 'datos'
CREATE TABLE subdireccion (
    id_subdireccion INT PRIMARY KEY IDENTITY(1,1),
    subdireccion VARCHAR(50) NOT NULL,
    area VARCHAR(50),
    id_datos INT NOT NULL,
    FOREIGN KEY (id_datos) REFERENCES datos(id_datos)
);
