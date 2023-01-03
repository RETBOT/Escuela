using System;
using System.Collections.Generic;

namespace Escuela.Models;

public partial class Materia
{
    public int IdMateria { get; set; }

    public string NombreMateria { get; set; } = null!;

    public virtual ICollection<Alumno> AlumnoNombreMateria1Navigations { get; } = new List<Alumno>();

    public virtual ICollection<Alumno> AlumnoNombreMateria2Navigations { get; } = new List<Alumno>();

    public virtual ICollection<Alumno> AlumnoNombreMateria3Navigations { get; } = new List<Alumno>();

    public virtual ICollection<Alumno> AlumnoNombreMateria4Navigations { get; } = new List<Alumno>();

    public virtual ICollection<Alumno> AlumnoNombreMateria5Navigations { get; } = new List<Alumno>();

    public virtual ICollection<Calificacione> Calificaciones { get; } = new List<Calificacione>();

    public virtual ICollection<Maestro> Maestros { get; } = new List<Maestro>();
}
