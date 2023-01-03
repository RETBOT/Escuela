using System;
using System.Collections.Generic;

namespace Escuela.Models;

public partial class Maestro
{
    public int IdMaestro { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Apellidos { get; set; }

    public string NumTelefono { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string? NombreMateria { get; set; }

    public virtual Materia? NombreMateriaNavigation { get; set; }
}
