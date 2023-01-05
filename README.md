# Escuela :school: - proyecto ASP.NET Core MVC C♯ :man_technologist:
## Configuración inicial
Iniciaremos creando un nuevo proyecto en [Visual Studio 2022](https://visualstudio.microsoft.com/es/vs/).  
![img1](/ASP.NET/imgs/1.png)

Después en el filtro, pondremos web y buscaremos <<Aplicación web de ASP.NET Core (MVC)>> y daremos siguiente
![img2](/ASP.NET/imgs/2.png)

Le pondremos un nombre al proyecto, en este caso lo llamaremos <<Escuela>> y siguiente 
![img3](/ASP.NET/imgs/3.png)

En la información adicional, seleccionaremos .NET 6.0 y crear
![img4](/ASP.NET/imgs/4.png)

## Configuración del entorno de trabajo
![img5](/ASP.NET/imgs/5.png)

Iniciaremos configurando el administrador [NuGet](https://learn.microsoft.com/es-es/nuget/what-is-nuget) 
Seleccionaremos Herramientas->Administrador de paquetes NuGet->Administrar paquees NuGet para la solución…
![img6](/ASP.NET/imgs/6.png)

Dentro del administrador, en el buscador pondremos [EntityFramework](https://learn.microsoft.com/es-es/dotnet/framework/data/adonet/ef/overview)
Y buscaremos Microsoft.EntityFrameworkCore.SqlServer y Microsoft.EntityFrameworkCore.Tools
![img7](/ASP.NET/imgs/7.png)

Seleccionaremos Microsoft.EntityFrameworkCore.SqlServer y le daremos instalar.
![img8](/ASP.NET/imgs/8.png)

Aceptamos los términos y condiciones

![img9](/ASP.NET/imgs/9.png)

Y después instalaremos Microsoft.EntityFrameworkCore.Tools
![img10](/ASP.NET/imgs/10.png)

Aceptamos los términos y condiciones

![img11](/ASP.NET/imgs/11.png)

y aparecerá aprobado :white_check_mark:
![img12](/ASP.NET/imgs/12.png)

Una vez teniendo la configuración del entorno de trabajo, nos enfocaremos en crear la base de datos y sus tablas

## Configuración de la base de datos 
Los scripts de la configuración se encuentran dentro de la siguiente [carpeta :file_folder:](https://github.com/RETBOT/Escuela/tree/master/ASP.NET/archivos)
Para crear la base de datos utilizaremos el siguiente fragmento de código.
```
Create database Escuela
```

Teniendo la base de datos, crearemos las siguientes tablas: Materias, Maestros, Alumnos y Calificaciones 
Código para crear la tabla Materias: 
```
CREATE TABLE Materias 
(
 IdMateria INT PRIMARY KEY IDENTITY(1,1),
 NombreMateria VARCHAR(50) UNIQUE
)	
```

Código para crear la tabla Maestros: 
```
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
```

Código para crear la tabla Maestros:
``` 
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
```

Código para crear la tabla Maestros: 
```
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
```

Ahora agregaremos datos a las tablas
Código para agregar valores a la tabla Materias: 
```
insert into Materias (NombreMateria) values 
('DESARROLLO EN IOS'),
('INTELIGENCIA ARTIFICIAL'),
('ADMINISTRACIÓN DE BASES DE DATOS'),
('DESARROLLO WEB PILA COMPLETA II'),
('ADMINISTRACIÓN DE REDES'),
('SISTEMAS PROGRAMABLES'),
('DESARROLLO EN ANDROID'),
('CONMUTACIÓN Y ENRUTAMIENTO DE REDES DE DATOS'),
('DESARROLLO WEB PILA COMPLETA I'),
('PROGRAMACIÓN LÓGICA Y FUNCIONAL'),
('GESTIÓN DE PROYECTOS DE SOFTWARE'),
('LENGUAJES Y AUTÓMATAS II');
```

Código para agregar valores a la tabla Maestros: 
```
insert into Maestros 
(Nombre,Apellidos,NumTelefono,Correo,NombreMateria) values 
('Jacinto','Tapia','8787878787','JacintoTapia@correo.com','DESARROLLO EN IOS'),
('Serafin','Mejia','4545454545','SerafinMejia@correo.com','INTELIGENCIA ARTIFICIAL'),
('Leandro','Echevarria','1212121212','LeandroEchevarria@correo.com','ADMINISTRACIÓN DE BASES DE DATOS'),
('Jenifer','Moron','2323232344','JeniferMoron@correo.com','DESARROLLO WEB PILA COMPLETA II'),
('Jose','Aroca','8787878787','JoseAroca@correo.com','ADMINISTRACIÓN DE REDES'),
('Dylan','Flores','8787878787','DylanFlores@correo.com','SISTEMAS PROGRAMABLES'),
('Jesus','Gallego','8787878787','JesusGallego@correo.com','DESARROLLO EN ANDROID'),
('Luca','Soto','8787878787','LucaSoto@correo.com','CONMUTACIÓN Y ENRUTAMIENTO DE REDES DE DATOS')
```

Código para agregar valores a la tabla Alumnos: 
```
insert into Alumnos 
(NumControl, Nombre, Apellidos, PromedioGrals, NombreMateria1, NombreMateria2, NombreMateria3, NombreMateria4, NombreMateria5) 
values 
('19130501', 'Marco', 'Pinilla', 8.394, 
'DESARROLLO EN IOS', 'INTELIGENCIA ARTIFICIAL','ADMINISTRACIÓN DE BASES DE DATOS', 
'DESARROLLO WEB PILA COMPLETA II', 'ADMINISTRACIÓN DE REDES'),

('19130502', 'Saul', 'Duque', 0.0, 
'INTELIGENCIA ARTIFICIAL','DESARROLLO WEB PILA COMPLETA II','DESARROLLO EN IOS',
'ADMINISTRACIÓN DE BASES DE DATOS','SISTEMAS PROGRAMABLES'),

('19130503', 'Rut', 'Fuster',  0.0, 
'INTELIGENCIA ARTIFICIAL','ADMINISTRACIÓN DE REDES','DESARROLLO EN IOS',
'ADMINISTRACIÓN DE BASES DE DATOS','SISTEMAS PROGRAMABLES'),

('19130504', 'Mario', 'Bravo',  0.0, 
'INTELIGENCIA ARTIFICIAL','DESARROLLO WEB PILA COMPLETA II','DESARROLLO EN ANDROID',
'ADMINISTRACIÓN DE BASES DE DATOS','SISTEMAS PROGRAMABLES'),

('19130505', 'Nahia','Cardenas', 0.0, 
'DESARROLLO EN ANDROID','DESARROLLO WEB PILA COMPLETA II','CONMUTACIÓN Y ENRUTAMIENTO DE REDES DE DATOS',
'ADMINISTRACIÓN DE BASES DE DATOS','SISTEMAS PROGRAMABLES')
```

Código para agregar valores a la tabla Calificaciones: 
```
insert into Calificaciones 
(Unidad1, Unidad2, Unidad3, CaliFinal, NombreMateria, NumControl)
values
(7, 8, 8, 7.66, 'DESARROLLO EN IOS', '19130501'),
(9, 8, 9, 8.66, 'INTELIGENCIA ARTIFICIAL', '19130501'),
(10, 9, 9, 9.33, 'ADMINISTRACIÓN DE BASES DE DATOS', '19130501'),
(7, 8, 8, 7.66, 'DESARROLLO WEB PILA COMPLETA II', '19130501'),
(9, 8, 9, 8.66, 'ADMINISTRACIÓN DE REDES', '19130501')
```

## Conectar SQL con ASP.NET
Dentro del proyecto buscamos Herramientas->Administrador de paquetes NuGet->Consola del Administrador de paquetes.
![img13](/ASP.NET/imgs/13.png)

Desplegara la terminal en el proyecto y escribiremos lo siguiente: 
```
Scaffold-DbContext "server=localhost; database=Preparatoria; integrated security=true; Encrypt=False" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Models 
```
![img14](/ASP.NET/imgs/14.png)

La alerta indica que debemos de tener una cadena de conexión mas segura en el proyecto, por ende, entraremos a la siguiente [pagina](https://learn.microsoft.com/es-mx/ef/core/miscellaneous/connection-strings) en la cual buscaremos un ejemplo de cadenas de conexión.


Copiamos el siguiente fragmento de código: 
```
{
  "ConnectionStrings": {
    "BloggingDatabase": "Server=(localdb)\\mssqllocaldb;Database=EFGetStarted.ConsoleApp.NewDb;Trusted_Connection=True;"
  },
}
```
![img15](/ASP.NET/imgs/15.png)

Y lo vamos a pegar en el archivo appsettings.json
![img16](/ASP.NET/imgs/16.png)

Dentro de los modelos, en el archivo EscuelaContext.cs buscamos el método llamado OnConfiguring el cual contiene la cadena de conexión:
```
server=localhost; database=Escuela; integrated security=true; Encrypt=False 
```
![img17](/ASP.NET/imgs/17.png)

Y lo pegaremos en el archivo appsettings.json
```
"ConnectionStrings": {
    "conexion": "server=localhost; database=Escuela; integrated security=true; Encrypt=False"
  }
```
![img18](/ASP.NET/imgs/18.png)

Y comentamos lo siguiente dentro de Models->EscuelaContext.cs:
![img19](/ASP.NET/imgs/19.png)

Después entramos nuevamente a la [pagina](https://learn.microsoft.com/es-mx/ef/core/miscellaneous/connection-strings) Y copiamos lo siguiente: 
```
    services.AddDbContext<BloggingContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("BloggingDatabase")));
```
![img20](/ASP.NET/imgs/20.png)

Después entramos en el archivo Program.cs y pegamos lo copiado 
![img21](/ASP.NET/imgs/21.png)

Y cambiamos lo siguiente: 
```
builder.Services.AddDbContext<EscuelaContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));
```
![img22](/ASP.NET/imgs/22.png)

## Controladores para el CRUD 
Una vez ya configurado el proyecto, procedemos con el CRUD

Iniciaremos agregando los controladores 
Daremos clic derecho sobre la carpeta Controllers, después seleccionaremos agregar y controlador…
![img23](/ASP.NET/imgs/23.png)

Después seleccionaremos Controlador de MVC
![img24](/ASP.NET/imgs/24.png)

Se desplegará la siguiente ventana 
![img25](/ASP.NET/imgs/25.png)

 Y seleccionamos el modelo (tabla), el contexto (base de datos) y el nombre que tendrá el controlador. 
 ![img26](/ASP.NET/imgs/26.png)

Esto se aplicará para cada tabla.
 ![img27](/ASP.NET/imgs/27.png)

## Vistas
 Ahora solo queda modificar las vistas de la pagina a nuestro gusto 