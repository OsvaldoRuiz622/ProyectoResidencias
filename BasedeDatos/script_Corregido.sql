Create database DATA

USE DATA

Create Table solicitante (
	id_solicitante INT PRIMARY KEY IDENTITY(1,1),
	nombre_solicitante VARCHAR NOT NULL,
	correo VARCHAR NOT NULL,
    	tipo_solicitante VARCHAR NOT NULL,
    	tipo_fallo VARCHAR NOT NULL
);

Create table formulario_software (
	id_formulario_software INT PRIMARY KEY IDENTITY(1,1),
	descripcion VARCHAR NOT NULL,
	imagen VARCHAR NOT NULL,
	id_solicitante INT NOT NULL,
	id_operador INT NOT NULL,
	FOREIGN KEY (id_datos) REFERENCES datos(id_solicitante),
	FOREIGN KEY (id_operador) REFERENCES datos(id_operador)
);

Create table formulario_hardware (
	id_formulario_hardware INT PRIMARY KEY IDENTITY(1,1),
	tipo VARCHAR NOT NULL,
	cantidad VARCHAR NOT NULL,
	marca VARCHAR,
	no_serie VARCHAR,
	descripcion VARCHAR NOT NULL,
	observacion_pre VARCHAR NOT NULL,
	observacion_post VARCHAR NOT NULL,
	fecha_pre DATETIME  DEFAULT GETDATE(),
	fecha_post DATE,
	id_solicitante INT NOT NULL,
	id_operador INT NOT NULL,
	FOREIGN KEY (id_datos) REFERENCES datos(id_solicitante),
	FOREIGN KEY (id_operador) REFERENCES datos(id_operador)
);

Create table Operador (
	id_operador INT PRIMARY KEY IDENTITY(1,1),
	nombre_operador VARCHAR	NOT NULL,
	cargo VARCHAR NOT NULL
);
