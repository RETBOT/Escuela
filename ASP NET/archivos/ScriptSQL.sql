-- RETBOT
Create database Escuela

-- Eliminar DB
Use Master
GO
ALTER DATABASE Escuela SET OFFLINE
drop database Escuela

use Escuela
--DROP TABLE Materias
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'Materias')
BEGIN
	CREATE TABLE Materias 
	(
		IdMateria INT PRIMARY KEY IDENTITY(1,1),
		NombreMateria VARCHAR(50) UNIQUE
	)	
END
GO

select * from Materias

use Escuela
-- DROP TABLE Materias
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'Maestros')
BEGIN
	CREATE TABLE Maestros 
	(
		IdMaestro INT PRIMARY KEY IDENTITY(1,1),	
		Nombre VARCHAR(50) NOT NULL,
		Apellidos VARCHAR(50),
		NumTelefono VARCHAR(20) NOT NULL,
		Correo VARCHAR(40) NOT NULL,
		NombreMateria VARCHAR(50),
		CONSTRAINT FK_Materia_Maestro FOREIGN KEY (NombreMateria) REFERENCES Materias(NombreMateria)
	)	
END
GO
select * from Maestros


use Escuela
DROP TABLE Alumnos
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'Alumnos')
BEGIN
	CREATE TABLE Alumnos 
	(
		IdAlumno INT PRIMARY KEY IDENTITY(1,1),
		NumControl VARCHAR(8) NOT NULL UNIQUE,
		Nombre VARCHAR(50) NOT NULL,
		Apellidos VARCHAR(50),
		PromedioGrals DECIMAL(18,2) NULL,
		NombreMateria1 VARCHAR(50), 
		NombreMateria2 VARCHAR(50),
		NombreMateria3 VARCHAR(50),
		NombreMateria4 VARCHAR(50),
		NombreMateria5 VARCHAR(50),

		CONSTRAINT FK_Materia1_Alumno FOREIGN KEY (NombreMateria1) REFERENCES Materias(NombreMateria),
		CONSTRAINT FK_Materia2_Alumno FOREIGN KEY (NombreMateria2) REFERENCES Materias(NombreMateria),
		CONSTRAINT FK_Materia3_Alumno FOREIGN KEY (NombreMateria3) REFERENCES Materias(NombreMateria),
		CONSTRAINT FK_Materia4_Alumno FOREIGN KEY (NombreMateria4) REFERENCES Materias(NombreMateria),
		CONSTRAINT FK_Materia5_Alumno FOREIGN KEY (NombreMateria5) REFERENCES Materias(NombreMateria),
	)	
END
GO

select * from Alumnos



use Escuela
DROP TABLE Calificaciones
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'calificaciones')
BEGIN
	CREATE TABLE Calificaciones
	(
		IdCalificacion INT PRIMARY KEY IDENTITY(1,1),
		Unidad1 DECIMAL(10,2) NOT NULL,
		Unidad2 DECIMAL(10,2) NOT NULL,
		Unidad3 DECIMAL(10,2) NOT NULL,
		CaliFinal DECIMAL(10,2) NOT NULL,
		NombreMateria VARCHAR(50) NOT NULL, 
		NumControl VARCHAR(8) NOT NULL,
		CONSTRAINT FK_materias_calificaciones FOREIGN KEY (NombreMateria) REFERENCES Materias(NombreMateria),
		CONSTRAINT FK_alumnos_calificaciones FOREIGN KEY (NumControl) REFERENCES Alumnos(NumControl)
	)
END

select * from Calificaciones