Create database SistemaTickets

USE SistemaTickets

Drop table solicitante;

Create Table solicitante (
	id_solicitante INT PRIMARY KEY IDENTITY(1,1),
	nombre_solicitante VARCHAR (50) NOT NULL,
	correo VARCHAR (255) NOT NULL,
    tipo_solicitante VARCHAR (50) NOT NULL,
	area VARCHAR (50) NOT NULL,
    tipo_fallo VARCHAR (50) NOT NULL
);

Create table formulario_software (
	id_formulario_software INT PRIMARY KEY IDENTITY(1,1),
	descripcion VARCHAR (255) NOT NULL,
	imagen VARCHAR (255) NOT NULL,
	fecha_pre DATETIME  DEFAULT GETDATE(),
	fecha_post DATE,
	id_solicitante INT ,
	id_operador INT ,
	FOREIGN KEY (id_solicitante) REFERENCES solicitante(id_solicitante),
	FOREIGN KEY (id_operador) REFERENCES Operador(id_operador)
);

Create table formulario_hardware (
	id_formulario_hardware INT PRIMARY KEY IDENTITY(1,1),
	cantidad VARCHAR (255),
	marca VARCHAR (255),
	no_serie VARCHAR (255),
	descripcion VARCHAR (255),
	condicion VARCHAR (255),
	observacion_pre VARCHAR (255),
	observacion_post VARCHAR (255),
	fecha_pre DATETIME  DEFAULT GETDATE(),
	fecha_post DATE,
	id_solicitante INT,
	id_operador INT,
	FOREIGN KEY (id_solicitante) REFERENCES solicitante(id_solicitante),
	FOREIGN KEY (id_operador) REFERENCES Operador(id_operador)
);

Create table Operador (
	id_operador INT PRIMARY KEY IDENTITY(1,1),
	usuario VARCHAR (50) NOT NULL,
	contraseña VARCHAR (50) NOT NULL,
	cargo VARCHAR (50) NOT NULL
);


TRUNCATE TABLE solicitante;
DBCC CHECKIDENT ('solicitante', RESEED, 0)

select * from solicitante
insert into solicitante values ('ola', 'ola', 'ola', 'a', 'a' );
delete from solicitante where id_solicitante = 1;
DELETE FROM solicitante;
