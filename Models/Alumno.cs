using System;
using System.Collections.Generic;

namespace Escuela.Models;

public partial class Alumno
{
    public int IdAlumno { get; set; }

    public string NumControl { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? Apellidos { get; set; }

    public decimal? PromedioGrals { get; set; }

    public string? NombreMateria1 { get; set; }

    public string? NombreMateria2 { get; set; }

    public string? NombreMateria3 { get; set; }

    public string? NombreMateria4 { get; set; }

    public string? NombreMateria5 { get; set; }

    public virtual ICollection<Calificacione> Calificaciones { get; } = new List<Calificacione>();

    public virtual Materia? NombreMateria1Navigation { get; set; }

    public virtual Materia? NombreMateria2Navigation { get; set; }

    public virtual Materia? NombreMateria3Navigation { get; set; }

    public virtual Materia? NombreMateria4Navigation { get; set; }

    public virtual Materia? NombreMateria5Navigation { get; set; }
}
