using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Operador
{
    public int IdOperador { get; set; }

    public string Usuario { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string Cargo { get; set; } = null!;

    public virtual ICollection<FormularioHardware> FormularioHardwares { get; set; } = new List<FormularioHardware>();

    public virtual ICollection<FormularioSoftware> FormularioSoftwares { get; set; } = new List<FormularioSoftware>();
}
