use Escuela
insert into Materias (NombreMateria) values 
('DESARROLLO EN IOS'),
('INTELIGENCIA ARTIFICIAL'),
('ADMINISTRACI�N DE BASES DE DATOS'),
('DESARROLLO WEB PILA COMPLETA II'),
('ADMINISTRACI�N DE REDES'),
('SISTEMAS PROGRAMABLES'),
('DESARROLLO EN ANDROID'),
('CONMUTACI�N Y ENRUTAMIENTO DE REDES DE DATOS'),
('DESARROLLO WEB PILA COMPLETA I'),
('PROGRAMACI�N L�GICA Y FUNCIONAL'),
('GESTI�N DE PROYECTOS DE SOFTWARE'),
('LENGUAJES Y AUT�MATAS II');

select * from Materias

use Escuela
insert into Maestros 
(Nombre,Apellidos,NumTelefono,Correo,NombreMateria) values 
('Jacinto','Tapia','8787878787','JacintoTapia@correo.com','DESARROLLO EN IOS'),
('Serafin','Mejia','4545454545','SerafinMejia@correo.com','INTELIGENCIA ARTIFICIAL'),
('Leandro','Echevarria','1212121212','LeandroEchevarria@correo.com','ADMINISTRACI�N DE BASES DE DATOS'),
('Jenifer','Moron','2323232344','JeniferMoron@correo.com','DESARROLLO WEB PILA COMPLETA II'),
('Jose','Aroca','8787878787','JoseAroca@correo.com','ADMINISTRACI�N DE REDES'),
('Dylan','Flores','8787878787','DylanFlores@correo.com','SISTEMAS PROGRAMABLES'),
('Jesus','Gallego','8787878787','JesusGallego@correo.com','DESARROLLO EN ANDROID'),
('Luca','Soto','8787878787','LucaSoto@correo.com','CONMUTACI�N Y ENRUTAMIENTO DE REDES DE DATOS')
select * from Maestros

use Escuela
insert into Alumnos 
(NumControl, Nombre, Apellidos, PromedioGrals, NombreMateria1, NombreMateria2, NombreMateria3, NombreMateria4, NombreMateria5) 
values 
('19130501', 'Marco', 'Pinilla', 8.394, 
'DESARROLLO EN IOS', 'INTELIGENCIA ARTIFICIAL','ADMINISTRACI�N DE BASES DE DATOS', 
'DESARROLLO WEB PILA COMPLETA II', 'ADMINISTRACI�N DE REDES'),

('19130502', 'Saul', 'Duque', 0.0, 
'INTELIGENCIA ARTIFICIAL','DESARROLLO WEB PILA COMPLETA II','DESARROLLO EN IOS',
'ADMINISTRACI�N DE BASES DE DATOS','SISTEMAS PROGRAMABLES'),

('19130503', 'Rut', 'Fuster',  0.0, 
'INTELIGENCIA ARTIFICIAL','ADMINISTRACI�N DE REDES','DESARROLLO EN IOS',
'ADMINISTRACI�N DE BASES DE DATOS','SISTEMAS PROGRAMABLES'),

('19130504', 'Mario', 'Bravo',  0.0, 
'INTELIGENCIA ARTIFICIAL','DESARROLLO WEB PILA COMPLETA II','DESARROLLO EN ANDROID',
'ADMINISTRACI�N DE BASES DE DATOS','SISTEMAS PROGRAMABLES'),

('19130505', 'Nahia','Cardenas', 0.0, 
'DESARROLLO EN ANDROID','DESARROLLO WEB PILA COMPLETA II','CONMUTACI�N Y ENRUTAMIENTO DE REDES DE DATOS',
'ADMINISTRACI�N DE BASES DE DATOS','SISTEMAS PROGRAMABLES')

select * from Alumnos

use Escuela
insert into Calificaciones 
(Unidad1, Unidad2, Unidad3, CaliFinal, NombreMateria, NumControl)
values
(7, 8, 8, 7.66, 'DESARROLLO EN IOS', '19130501'),
(9, 8, 9, 8.66, 'INTELIGENCIA ARTIFICIAL', '19130501'),
(10, 9, 9, 9.33, 'ADMINISTRACI�N DE BASES DE DATOS', '19130501'),
(7, 8, 8, 7.66, 'DESARROLLO WEB PILA COMPLETA II', '19130501'),
(9, 8, 9, 8.66, 'ADMINISTRACI�N DE REDES', '19130501')

select * from Calificaciones


--select (Unidad1+Unidad2+Unidad3)/3 from Calificaciones where 
-- select AVG(CaliFinal) from Calificaciones

UPDATE Calificaciones
SET CaliFinal = (Unidad1+Unidad2+Unidad3)/3
WHERE NumControl = '19130501' and NombreMateria = 'DESARROLLO EN IOS'
select * from Calificaciones

UPDATE Alumnos
SET PromedioGrals = (select AVG(CaliFinal) from Calificaciones)
WHERE NumControl = '19130501'
select * from Alumnos
