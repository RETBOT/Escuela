# Escuela :school: - proyecto ASP.NET Core MVC C♯ :man_technologist:
[Descargar en pdf](/ASP.NET/archivos/Escuela%20-%20proyecto%20ASP.NET%20Core%20MVC%20C♯.pdf)
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
### Inicio
 Pagina de inicio => [Index.cshtml](/Views/Home/Index.cshtml)
  ![inicio](/ASP.NET/imgs/inicio.png)

```
@{
    ViewData["Title"] = "Home Page";
}

<div class="text-center">
    <h1 class="display-4">Escuela</h1>
    
</div>
```

### Alumnos 
 Pagina de Alumnos => [Index.cshtml](/Views/Alumnos/Index.cshtml)
  ![Alumnos](/ASP.NET/imgs/alumnos.png)

```
@model IEnumerable<Escuela.Models.Alumno>

@{
    ViewData["Title"] = "Index";
}

<h1>Alumnos</h1>

<p>
    <a class="btn btn-primary btn-lg active" asp-action="Create">Agregar nuevo</a>
</p>
<table class="table">
    <thead class="thead-dark">
        <tr>
            <th scope="col">
                @Html.DisplayNameFor(model => model.NumControl)
            </th>
            <th scope="col">
                @Html.DisplayNameFor(model => model.Nombre)
            </th>
            <th scope="col">
                @Html.DisplayNameFor(model => model.Apellidos)
            </th>
            <th scope="col">
                @Html.DisplayNameFor(model => model.PromedioGrals)
            </th>
            <th scope="col">
                @Html.DisplayNameFor(model => model.NombreMateria1Navigation)
            </th>
            <th scope="col">
                @Html.DisplayNameFor(model => model.NombreMateria2Navigation)
            </th>
            <th scope="col">
                @Html.DisplayNameFor(model => model.NombreMateria3Navigation)
            </th>
            <th scope="col">
                @Html.DisplayNameFor(model => model.NombreMateria4Navigation)
            </th>
            <th scope="col">
                @Html.DisplayNameFor(model => model.NombreMateria5Navigation)
            </th>
            <th scope="col"></th>
        </tr>
    </thead>
    <tbody>
@foreach (var item in Model) {
        <tr>
            <td>
                @Html.DisplayFor(modelItem => item.NumControl)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Nombre)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Apellidos)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.PromedioGrals)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.NombreMateria1Navigation.NombreMateria)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.NombreMateria2Navigation.NombreMateria)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.NombreMateria3Navigation.NombreMateria)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.NombreMateria4Navigation.NombreMateria)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.NombreMateria5Navigation.NombreMateria)
            </td>
            <td>
                <a asp-action="Edit" class="btn btn-primary" asp-route-id="@item.IdAlumno">Editar</a> |
                <a asp-action="Details" class="btn btn-secondary" asp-route-id="@item.IdAlumno">Detalles</a> |
                <a asp-action="Delete" class="btn btn-danger" asp-route-id="@item.IdAlumno">Eliminar</a>
            </td>
        </tr>
}
    </tbody>
</table>
```


 Pagina de Alumnos Agregar => [Create.cshtml](/Views/Alumnos/Create.cshtml)
  ![Alumnos](/ASP.NET/imgs/alumnos%20agregar.png)

```
@model Escuela.Models.Alumno

@{
    ViewData["Title"] = "Create";
}

<h1>Agregar</h1>

<h4>Alumno</h4>
<hr />
<div class="row">
    <div class="col-md-4">
        <form asp-action="Create">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>
            <div class="form-group">
                <label asp-for="NumControl" class="control-label"></label>
                <input asp-for="NumControl" class="form-control" />
                <span asp-validation-for="NumControl" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Nombre" class="control-label"></label>
                <input asp-for="Nombre" class="form-control" />
                <span asp-validation-for="Nombre" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Apellidos" class="control-label"></label>
                <input asp-for="Apellidos" class="form-control" />
                <span asp-validation-for="Apellidos" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="PromedioGrals" class="control-label"></label>
                <input asp-for="PromedioGrals" class="form-control" />
                <span asp-validation-for="PromedioGrals" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="NombreMateria1" class="control-label"></label>
                <select asp-for="NombreMateria1" class ="form-control" asp-items="ViewBag.NombreMateria1"></select>
            </div>
            <div class="form-group">
                <label asp-for="NombreMateria2" class="control-label"></label>
                <select asp-for="NombreMateria2" class ="form-control" asp-items="ViewBag.NombreMateria2"></select>
            </div>
            <div class="form-group">
                <label asp-for="NombreMateria3" class="control-label"></label>
                <select asp-for="NombreMateria3" class ="form-control" asp-items="ViewBag.NombreMateria3"></select>
            </div>
            <div class="form-group">
                <label asp-for="NombreMateria4" class="control-label"></label>
                <select asp-for="NombreMateria4" class ="form-control" asp-items="ViewBag.NombreMateria4"></select>
            </div>
            <div class="form-group">
                <label asp-for="NombreMateria5" class="control-label"></label>
                <select asp-for="NombreMateria5" class ="form-control" asp-items="ViewBag.NombreMateria5"></select>
            </div>
            <div class="form-group">
                <input type="submit" value="Agregar" class="btn btn-primary" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action="Index">Regresar</a>
</div>

@section Scripts {
    @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
}
```


 Pagina de Alumnos Detalles => [Details.cshtml](/Views/Alumnos/Details.cshtml)
  ![Alumnos](/ASP.NET/imgs/alumnos%20detalle.png)

```
@model Escuela.Models.Alumno

@{
    ViewData["Title"] = "Details";
}

<h1>Detalles</h1>

<div>
    <h4>Alumno</h4>
    <hr />
    <dl class="row">
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.NumControl)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.NumControl)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Nombre)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Nombre)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Apellidos)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Apellidos)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.PromedioGrals)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.PromedioGrals)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.NombreMateria1Navigation)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.NombreMateria1Navigation.NombreMateria)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.NombreMateria2Navigation)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.NombreMateria2Navigation.NombreMateria)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.NombreMateria3Navigation)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.NombreMateria3Navigation.NombreMateria)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.NombreMateria4Navigation)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.NombreMateria4Navigation.NombreMateria)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.NombreMateria5Navigation)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.NombreMateria5Navigation.NombreMateria)
        </dd>
    </dl>
</div>
<div>
    <a asp-action="Edit" asp-route-id="@Model?.IdAlumno">Editar</a> |
    <a asp-action="Index">Regresar</a>
</div>
```


 Pagina de Alumnos Editar => [Edit.cshtml](/Views/Alumnos/Edit.cshtml)
  ![Alumnos](/ASP.NET/imgs/alumnos%20editar.png)

```
@model Escuela.Models.Alumno

@{
    ViewData["Title"] = "Edit";
}

<h1>Editar</h1>

<h4>Alumno</h4>
<hr />
<div class="row">
    <div class="col-md-4">
        <form asp-action="Edit">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>
            <input type="hidden" asp-for="IdAlumno" />
            <div class="form-group">
                <label asp-for="NumControl" class="control-label"></label>
                <input asp-for="NumControl" class="form-control" />
                <span asp-validation-for="NumControl" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Nombre" class="control-label"></label>
                <input asp-for="Nombre" class="form-control" />
                <span asp-validation-for="Nombre" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Apellidos" class="control-label"></label>
                <input asp-for="Apellidos" class="form-control" />
                <span asp-validation-for="Apellidos" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="PromedioGrals" class="control-label"></label>
                <input asp-for="PromedioGrals" class="form-control" />
                <span asp-validation-for="PromedioGrals" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="NombreMateria1" class="control-label"></label>
                <select asp-for="NombreMateria1" class="form-control" asp-items="ViewBag.NombreMateria1"></select>
                <span asp-validation-for="NombreMateria1" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="NombreMateria2" class="control-label"></label>
                <select asp-for="NombreMateria2" class="form-control" asp-items="ViewBag.NombreMateria2"></select>
                <span asp-validation-for="NombreMateria2" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="NombreMateria3" class="control-label"></label>
                <select asp-for="NombreMateria3" class="form-control" asp-items="ViewBag.NombreMateria3"></select>
                <span asp-validation-for="NombreMateria3" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="NombreMateria4" class="control-label"></label>
                <select asp-for="NombreMateria4" class="form-control" asp-items="ViewBag.NombreMateria4"></select>
                <span asp-validation-for="NombreMateria4" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="NombreMateria5" class="control-label"></label>
                <select asp-for="NombreMateria5" class="form-control" asp-items="ViewBag.NombreMateria5"></select>
                <span asp-validation-for="NombreMateria5" class="text-danger"></span>
            </div>
            <div class="form-group">
                <input type="submit" value="Guardar" class="btn btn-primary" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action="Index">Regresar</a>
</div>

@section Scripts {
    @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
}
```


 Pagina de Alumnos Eliminar => [Delete.cshtml](/Views/Alumnos/Delete.cshtml)
  ![Alumnos](/ASP.NET/imgs/alumnos%20eliminar.png)

```
@model Escuela.Models.Alumno

@{
    ViewData["Title"] = "Delete";
}

<h1>Eliminar</h1>

<h3>¿Estás seguro de que quieres eliminar esto?</h3>
<div>
    <h4>Alumno</h4>
    <hr />
    <dl class="row">
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.NumControl)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.NumControl)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Nombre)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Nombre)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Apellidos)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Apellidos)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.PromedioGrals)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.PromedioGrals)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.NombreMateria1Navigation)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.NombreMateria1Navigation.NombreMateria)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.NombreMateria2Navigation)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.NombreMateria2Navigation.NombreMateria)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.NombreMateria3Navigation)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.NombreMateria3Navigation.NombreMateria)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.NombreMateria4Navigation)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.NombreMateria4Navigation.NombreMateria)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.NombreMateria5Navigation)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.NombreMateria5Navigation.NombreMateria)
        </dd>
    </dl>
    
    <form asp-action="Delete">
        <input type="hidden" asp-for="IdAlumno" />
        <input type="submit" value="Eliminar" class="btn btn-danger" /> |
        <a asp-action="Index">Regresar</a>
    </form>
</div>
```

### Calificaciones 
Pagina de Calificaciones => [Index.cshtml](/Views/Calificaciones/Index.cshtml)
![Calificaciones](/ASP.NET/imgs/calificaciones.png)

```
@model IEnumerable<Escuela.Models.Calificacione>

@{
    ViewData["Title"] = "Index";
}

<h1>Calificaciones</h1>

<p>
    <a class="btn btn-primary btn-lg active" asp-action="Create">Agregar nueva</a>
</p>
<table class="table">
    <thead class="thead-dark">
        <tr>
            <th scope="col">
                @Html.DisplayNameFor(model => model.Unidad1)
            </th>
            <th scope="col">
                @Html.DisplayNameFor(model => model.Unidad2)
            </th>
            <th scope="col">
                @Html.DisplayNameFor(model => model.Unidad3)
            </th>
            <th scope="col">
                @Html.DisplayNameFor(model => model.CaliFinal)
            </th>
            <th scope="col">
                @Html.DisplayNameFor(model => model.NombreMateriaNavigation)
            </th>
            <th scope="col">
                @Html.DisplayNameFor(model => model.NumControlNavigation)
            </th>
            <th scope="col"></th>
        </tr>
    </thead>
    <tbody>
@foreach (var item in Model) {
        <tr>
            <td>
                @Html.DisplayFor(modelItem => item.Unidad1)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Unidad2)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Unidad3)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.CaliFinal)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.NombreMateriaNavigation.NombreMateria)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.NumControlNavigation.NumControl)
            </td>
            <td>
                <a asp-action="Edit" class="btn btn-primary" asp-route-id="@item.IdCalificacion">Editar</a> |
                <a asp-action="Details" class="btn btn-secondary" asp-route-id="@item.IdCalificacion">Detalles</a> |
                <a asp-action="Delete" class="btn btn-danger" asp-route-id="@item.IdCalificacion">Eliminar</a>
            </td>
        </tr>
}
    </tbody>
</table>
```

 Pagina de Calificaciones Agregar => [Create.cshtml](/Views/Calificaciones/Create.cshtml)

```
@model Escuela.Models.Calificacione

@{
    ViewData["Title"] = "Create";
}

<h1>Agregar</h1>

<h4>Calificacione</h4>
<hr />
<div class="row">
    <div class="col-md-4">
        <form asp-action="Create">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>
            <div class="form-group">
                <label asp-for="Unidad1" class="control-label"></label>
                <input asp-for="Unidad1" class="form-control" />
                <span asp-validation-for="Unidad1" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Unidad2" class="control-label"></label>
                <input asp-for="Unidad2" class="form-control" />
                <span asp-validation-for="Unidad2" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Unidad3" class="control-label"></label>
                <input asp-for="Unidad3" class="form-control" />
                <span asp-validation-for="Unidad3" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="CaliFinal" class="control-label"></label>
                <input asp-for="CaliFinal" class="form-control" />
                <span asp-validation-for="CaliFinal" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="NombreMateria" class="control-label"></label>
                <select asp-for="NombreMateria" class ="form-control" asp-items="ViewBag.NombreMateria"></select>
            </div>
            <div class="form-group">
                <label asp-for="NumControl" class="control-label"></label>
                <select asp-for="NumControl" class ="form-control" asp-items="ViewBag.NumControl"></select>
            </div>
            <div class="form-group">
                <input type="submit" value="Agregar" class="btn btn-primary" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action="Index">Regresar</a>
</div>

@section Scripts {
    @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
}
```

 Pagina de Calificaciones Detalles => [Details.cshtml](/Views/Calificaciones/Details.cshtml)

```
@model Escuela.Models.Calificacione

@{
    ViewData["Title"] = "Details";
}

<h1>Detalles</h1>

<div>
    <h4>Calificacione</h4>
    <hr />
    <dl class="row">
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Unidad1)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Unidad1)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Unidad2)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Unidad2)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Unidad3)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Unidad3)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.CaliFinal)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.CaliFinal)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.NombreMateriaNavigation)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.NombreMateriaNavigation.NombreMateria)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.NumControlNavigation)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.NumControlNavigation.NumControl)
        </dd>
    </dl>
</div>
<div>
    <a asp-action="Edit" asp-route-id="@Model?.IdCalificacion">Editar</a> |
    <a asp-action="Index">Regresar</a>
</div>
```

 Pagina de Calificaciones Editar => [Edit.cshtml](/Views/Calificaciones/Edit.cshtml)

```
@model Escuela.Models.Calificacione

@{
    ViewData["Title"] = "Edit";
}

<h1>Editar</h1>

<h4>Calificacione</h4>
<hr />
<div class="row">
    <div class="col-md-4">
        <form asp-action="Edit">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>
            <input type="hidden" asp-for="IdCalificacion" />
            <div class="form-group">
                <label asp-for="Unidad1" class="control-label"></label>
                <input asp-for="Unidad1" class="form-control" />
                <span asp-validation-for="Unidad1" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Unidad2" class="control-label"></label>
                <input asp-for="Unidad2" class="form-control" />
                <span asp-validation-for="Unidad2" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Unidad3" class="control-label"></label>
                <input asp-for="Unidad3" class="form-control" />
                <span asp-validation-for="Unidad3" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="CaliFinal" class="control-label"></label>
                <input asp-for="CaliFinal" class="form-control" />
                <span asp-validation-for="CaliFinal" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="NombreMateria" class="control-label"></label>
                <select asp-for="NombreMateria" class="form-control" asp-items="ViewBag.NombreMateria"></select>
                <span asp-validation-for="NombreMateria" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="NumControl" class="control-label"></label>
                <select asp-for="NumControl" class="form-control" asp-items="ViewBag.NumControl"></select>
                <span asp-validation-for="NumControl" class="text-danger"></span>
            </div>
            <div class="form-group">
                <input type="submit" value="Guardar" class="btn btn-primary" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action="Index">Regresar</a>
</div>

@section Scripts {
    @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
}
```

 Pagina de Calificaciones Eliminar => [Delete.cshtml](/Views/Calificaciones/Delete.cshtml)

```
@model Escuela.Models.Calificacione

@{
    ViewData["Title"] = "Delete";
}

<h1>Eliminar</h1>

<h3>¿Estás seguro de que quieres eliminar esto?</h3>
<div>
    <h4>Calificacione</h4>
    <hr />
    <dl class="row">
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Unidad1)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Unidad1)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Unidad2)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Unidad2)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Unidad3)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Unidad3)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.CaliFinal)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.CaliFinal)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.NombreMateriaNavigation)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.NombreMateriaNavigation.NombreMateria)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.NumControlNavigation)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.NumControlNavigation.NumControl)
        </dd>
    </dl>
    
    <form asp-action="Delete">
        <input type="hidden" asp-for="IdCalificacion" />
        <input type="submit" value="Eliminar" class="btn btn-danger" /> |
        <a asp-action="Index">Regresar</a>
    </form>
</div>
```

### Maestros
Pagina de Maestros => [Index.cshtml](/Views/Maestros/Index.cshtml)
![Maestros](/ASP.NET/imgs/maestros.png)

```
@model IEnumerable<Escuela.Models.Maestro>

@{
    ViewData["Title"] = "Index";
}

<h1>Maestros</h1>

<p>
    <a class="btn btn-primary btn-lg active" asp-action="Create">Agregar nuevo</a>
</p>
<table class="table">
    <thead class="thead-dark">
        <tr>
            <th scope="col">
                @Html.DisplayNameFor(model => model.Nombre)
            </th>
            <th scope="col">
                @Html.DisplayNameFor(model => model.Apellidos)
            </th>
            <th scope="col">
                @Html.DisplayNameFor(model => model.NumTelefono)
            </th>
            <th scope="col">
                @Html.DisplayNameFor(model => model.Correo)
            </th>
            <th scope="col">
                @Html.DisplayNameFor(model => model.NombreMateriaNavigation)
            </th>
            <th scope="col"></th>
        </tr>
    </thead>
    <tbody>
@foreach (var item in Model) {
        <tr>
            <td>
                @Html.DisplayFor(modelItem => item.Nombre)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Apellidos)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.NumTelefono)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Correo)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.NombreMateriaNavigation.NombreMateria)
            </td>
            <td>
                <a asp-action="Edit" class="btn btn-primary" asp-route-id="@item.IdMaestro">Editar</a> |
                <a asp-action="Details" class="btn btn-secondary" asp-route-id="@item.IdMaestro">Detalles</a> |
                <a asp-action="Delete" class="btn btn-danger" asp-route-id="@item.IdMaestro">Eliminar</a>
            </td>
        </tr>
}
    </tbody>
</table>
```

 Pagina de Maestros Agregar => [Create.cshtml](/Views/Maestros/Create.cshtml)

```
@model Escuela.Models.Maestro

@{
    ViewData["Title"] = "Create";
}

<h1>Agregar</h1>

<h4>Maestro</h4>
<hr />
<div class="row">
    <div class="col-md-4">
        <form asp-action="Create">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>
            <div class="form-group">
                <label asp-for="Nombre" class="control-label"></label>
                <input asp-for="Nombre" class="form-control" />
                <span asp-validation-for="Nombre" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Apellidos" class="control-label"></label>
                <input asp-for="Apellidos" class="form-control" />
                <span asp-validation-for="Apellidos" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="NumTelefono" class="control-label"></label>
                <input asp-for="NumTelefono" class="form-control" />
                <span asp-validation-for="NumTelefono" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Correo" class="control-label"></label>
                <input asp-for="Correo" class="form-control" />
                <span asp-validation-for="Correo" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="NombreMateria" class="control-label"></label>
                <select asp-for="NombreMateria" class ="form-control" asp-items="ViewBag.NombreMateria"></select>
            </div>
            <div class="form-group">
                <input type="submit" value="Agregar" class="btn btn-primary" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action="Index">Regresar</a>
</div>

@section Scripts {
    @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
}
```

 Pagina de Maestros Detalles => [Details.cshtml](/Views/Maestros/Details.cshtml)

```
@model Escuela.Models.Maestro

@{
    ViewData["Title"] = "Details";
}

<h1>Detalles</h1>

<div>
    <h4>Maestro</h4>
    <hr />
    <dl class="row">
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Nombre)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Nombre)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Apellidos)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Apellidos)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.NumTelefono)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.NumTelefono)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Correo)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Correo)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.NombreMateriaNavigation)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.NombreMateriaNavigation.NombreMateria)
        </dd>
    </dl>
</div>
<div>
    <a asp-action="Edit" asp-route-id="@Model?.IdMaestro">Editar</a> |
    <a asp-action="Index">Regresar</a>
</div>
```

 Pagina de Maestros Editar => [Edit.cshtml](/Views/Maestros/Edit.cshtml)

```
@model Escuela.Models.Maestro

@{
    ViewData["Title"] = "Edit";
}

<h1>Editar</h1>

<h4>Maestro</h4>
<hr />
<div class="row">
    <div class="col-md-4">
        <form asp-action="Edit">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>
            <input type="hidden" asp-for="IdMaestro" />
            <div class="form-group">
                <label asp-for="Nombre" class="control-label"></label>
                <input asp-for="Nombre" class="form-control" />
                <span asp-validation-for="Nombre" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Apellidos" class="control-label"></label>
                <input asp-for="Apellidos" class="form-control" />
                <span asp-validation-for="Apellidos" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="NumTelefono" class="control-label"></label>
                <input asp-for="NumTelefono" class="form-control" />
                <span asp-validation-for="NumTelefono" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Correo" class="control-label"></label>
                <input asp-for="Correo" class="form-control" />
                <span asp-validation-for="Correo" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="NombreMateria" class="control-label"></label>
                <select asp-for="NombreMateria" class="form-control" asp-items="ViewBag.NombreMateria"></select>
                <span asp-validation-for="NombreMateria" class="text-danger"></span>
            </div>
            <div class="form-group">
                <input type="submit" value="Guardar" class="btn btn-primary" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action="Index">Regresar</a>
</div>

@section Scripts {
    @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
}
```

 Pagina de Maestros Eliminar => [Delete.cshtml](/Views/Maestros/Delete.cshtml)

```
@model Escuela.Models.Maestro

@{
    ViewData["Title"] = "Delete";
}

<h1>Eliminar</h1>

<h3>¿Estás seguro de que quieres eliminar esto?</h3>
<div>
    <h4>Maestro</h4>
    <hr />
    <dl class="row">
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Nombre)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Nombre)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Apellidos)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Apellidos)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.NumTelefono)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.NumTelefono)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Correo)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Correo)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.NombreMateriaNavigation)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.NombreMateriaNavigation.NombreMateria)
        </dd>
    </dl>
    
    <form asp-action="Delete">
        <input type="hidden" asp-for="IdMaestro" />
        <input type="submit" value="Eliminar" class="btn btn-danger" /> |
        <a asp-action="Index">Regresar</a>
    </form>
</div>
```

### Materias 
Pagina de Materias => [Index.cshtml](/Views/--/Index.cshtml)
![Materias](/ASP.NET/imgs/materias.png)
```
@model IEnumerable<Escuela.Models.Materia>

@{
    ViewData["Title"] = "Index";
}

<h1>Materias</h1>

<p>
    <a class="btn btn-primary btn-lg active" asp-action="Create">Agregar nueva</a>
</p>
<table class="table">
    <thead class="thead-dark">
        <tr>
            <th scope="col">
                @Html.DisplayNameFor(model => model.NombreMateria)
            </th>
            <th scope="col"></th>
        </tr>
    </thead>
    <tbody>
@foreach (var item in Model) {
        <tr>
            <td>
                @Html.DisplayFor(modelItem => item.NombreMateria)
            </td>
            <td>
                <a asp-action="Edit" class="btn btn-primary" asp-route-id="@item.IdMateria">Editar</a> |
                <a asp-action="Details" class="btn btn-secondary" asp-route-id="@item.IdMateria">Detalles</a> |
                <a asp-action="Delete" class="btn btn-danger" asp-route-id="@item.IdMateria">Eliminar</a>
            </td>
        </tr>
}
    </tbody>
</table>
```

 Pagina de Materias Agregar => [Create.cshtml](/Views/Materias/Create.cshtml)

```
@model Escuela.Models.Materia

@{
    ViewData["Title"] = "Create";
}

<h1>Agregar</h1>

<h4>Materia</h4>
<hr />
<div class="row">
    <div class="col-md-4">
        <form asp-action="Create">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>
            <div class="form-group">
                <label asp-for="NombreMateria" class="control-label"></label>
                <input asp-for="NombreMateria" class="form-control" />
                <span asp-validation-for="NombreMateria" class="text-danger"></span>
            </div>
            <div class="form-group">
                <input type="submit" value="Agregar" class="btn btn-primary" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action="Index">Regresar</a>
</div>

@section Scripts {
    @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
}
```

 Pagina de Materias Detalles => [Details.cshtml](/Views/Materias/Details.cshtml)
```
@model Escuela.Models.Materia

@{
    ViewData["Title"] = "Details";
}

<h1>Detalles</h1>

<div>
    <h4>Materia</h4>
    <hr />
    <dl class="row">
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.NombreMateria)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.NombreMateria)
        </dd>
    </dl>
</div>
<div>
    <a asp-action="Edit" asp-route-id="@Model?.IdMateria">Editar</a> |
    <a asp-action="Index">Regresar</a>
</div>
```

 Pagina de Materias Editar => [Edit.cshtml](/Views/Materias/Edit.cshtml)
```
@model Escuela.Models.Materia

@{
    ViewData["Title"] = "Edit";
}

<h1>Editar</h1>

<h4>Materia</h4>
<hr />
<div class="row">
    <div class="col-md-4">
        <form asp-action="Edit">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>
            <input type="hidden" asp-for="IdMateria" />
            <div class="form-group">
                <label asp-for="NombreMateria" class="control-label"></label>
                <input asp-for="NombreMateria" class="form-control" />
                <span asp-validation-for="NombreMateria" class="text-danger"></span>
            </div>
            <div class="form-group">
                <input type="submit" value="Guardar" class="btn btn-primary" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action="Index">Regresar</a>
</div>

@section Scripts {
    @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
}
```

 Pagina de Materias Eliminar => [Delete.cshtml](/Views/Materias/Delete.cshtml)
```
@model Escuela.Models.Materia

@{
    ViewData["Title"] = "Delete";
}

<h1>Eliminar</h1>

<h3>¿Estás seguro de que quieres eliminar esto?</h3>
<div>
    <h4>Materia</h4>
    <hr />
    <dl class="row">
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.NombreMateria)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.NombreMateria)
        </dd>
    </dl>
    
    <form asp-action="Delete">
        <input type="hidden" asp-for="IdMateria" />
        <input type="submit" value="Eliminar" class="btn btn-danger" /> |
        <a asp-action="Index">Regresar</a>
    </form>
</div>
```