using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class SolicitanteHard
{
    public int IdSolicitanteHard { get; set; }

    public string NombreSolicitanteHard { get; set; } = null!;

    public string CorreoHard { get; set; } = null!;

    public string TipoSolicitanteHard { get; set; } = null!;

    public string AreaHard { get; set; } = null!;

    public string TipoFalloHard { get; set; } = null!;

    public virtual ICollection<FormularioHardware> FormularioHardwares { get; set; } = new List<FormularioHardware>();
}
