using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Solicitante
{
    public int IdSolicitante { get; set; }

    public string NombreSolicitante { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string TipoSolicitante { get; set; } = null!;

    public string Area { get; set; } = null!;

    public string TipoFallo { get; set; } = null!;

    public virtual ICollection<FormularioHardware> FormularioHardwares { get; set; } = new List<FormularioHardware>();

    public virtual ICollection<FormularioSoftware> FormularioSoftwares { get; set; } = new List<FormularioSoftware>();
}
