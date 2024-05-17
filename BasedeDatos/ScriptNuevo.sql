Create database SistemaTicketsVersionDos

USE SistemaTicketsVersionDos

Drop table formulario_software;

Create Table solicitanteSoft (
	id_solicitanteSoft INT PRIMARY KEY IDENTITY(1,1),
	nombre_solicitante_soft VARCHAR (50) NOT NULL,
	correo_soft VARCHAR (255) NOT NULL,
    tipo_solicitante_soft VARCHAR (255) NOT NULL,
	area_soft VARCHAR (255) NOT NULL,
    tipo_fallo_soft VARCHAR (255) NOT NULL
);

Create Table solicitanteHard (
	id_solicitanteHard INT PRIMARY KEY IDENTITY(1,1),
	nombre_solicitante_hard VARCHAR (255) NOT NULL,
	correo_hard VARCHAR (255) NOT NULL,
    tipo_solicitante_hard VARCHAR (255) NOT NULL,
	area_hard VARCHAR (50) NOT NULL,
    tipo_fallo_hard VARCHAR (255) NOT NULL
);

Create table formulario_software (
	id_formulario_software INT PRIMARY KEY IDENTITY(1,1),
	descripcion VARCHAR (255) NOT NULL,
	nombre_archivo NVARCHAR(255),
    FileData VARBINARY(MAX),
	fecha_pre DATETIME  DEFAULT GETDATE(),
	fecha_post DATE,
	estatus bit,
	id_solicitanteSoft INT ,
	id_operador INT ,
	FOREIGN KEY (id_solicitanteSoft) REFERENCES solicitanteSoft(id_solicitanteSoft),
	FOREIGN KEY (id_operador) REFERENCES Operador(id_operador)
);

Create table formulario_hardware (
	id_formulario_hardware INT PRIMARY KEY IDENTITY(1,1),
	cantidad VARCHAR (255),
	marca VARCHAR (255),
	no_serie VARCHAR (255),
	descripcion_hard VARCHAR (255) NOT NULL,
	condicion VARCHAR (255),
	observacion_pre VARCHAR (255),
	observacion_post VARCHAR (255),
	fecha_pre_hard DATETIME  DEFAULT GETDATE(),
	fecha_post_hard DATE,
	estatus_hard bit,
	id_solicitanteHard INT,
	id_operador INT,
	FOREIGN KEY (id_solicitanteHard) REFERENCES solicitanteHard(id_solicitanteHard),
	FOREIGN KEY (id_operador) REFERENCES Operador(id_operador)
);

Create table Operador (
	id_operador INT PRIMARY KEY IDENTITY(1,1),
	usuario VARCHAR (50) NOT NULL,
	contrasena VARCHAR(255) NOT NULL,
	cargo VARCHAR (255) NOT NULL
);

DBCC CHECKIDENT ('formulario_software', RESEED, 0)

select * from formulario_software
delete from formulario_software where id_formulario_software = 13;
DELETE FROM formulario_software;

DBCC CHECKIDENT ('formulario_hardware', RESEED, 0)

select * from formulario_hardware
delete from formulario_hardware where id_formulario_hardware = 17;
DELETE FROM formulario_hardware;

DBCC CHECKIDENT ('solicitanteSoft', RESEED, 0)

select * from solicitanteSoft
delete from solicitanteSoft where id_solicitanteSoft = 10;
DELETE FROM solicitanteSoft;

DBCC CHECKIDENT ('solicitanteHard', RESEED, 0)

select * from solicitanteHard
delete from solicitanteHard where id_solicitanteHard = 10;
DELETE FROM solicitanteHard;

select * from Operador