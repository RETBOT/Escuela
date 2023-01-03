using System;
using System.Collections.Generic;

namespace Escuela.Models;

public partial class Calificacione
{
    public int IdCalificacion { get; set; }

    public decimal Unidad1 { get; set; }

    public decimal Unidad2 { get; set; }

    public decimal Unidad3 { get; set; }

    public decimal CaliFinal { get; set; }

    public string NombreMateria { get; set; } = null!;

    public string NumControl { get; set; } = null!;

    public virtual Materia NombreMateriaNavigation { get; set; } = null!;

    public virtual Alumno NumControlNavigation { get; set; } = null!;
}
