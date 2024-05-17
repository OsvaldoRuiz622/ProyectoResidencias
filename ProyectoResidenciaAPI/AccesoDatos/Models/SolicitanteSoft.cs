using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class SolicitanteSoft
{
    public int IdSolicitanteSoft { get; set; }

    public string NombreSolicitanteSoft { get; set; } = null!;

    public string CorreoSoft { get; set; } = null!;

    public string TipoSolicitanteSoft { get; set; } = null!;

    public string AreaSoft { get; set; } = null!;

    public string TipoFalloSoft { get; set; } = null!;

    public virtual ICollection<FormularioSoftware> FormularioSoftwares { get; set; } = new List<FormularioSoftware>();
}
