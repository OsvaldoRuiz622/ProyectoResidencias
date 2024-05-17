using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class FormularioHardware
{
    public int IdFormularioHardware { get; set; }

    public string? Cantidad { get; set; }

    public string? Marca { get; set; }

    public string? NoSerie { get; set; }

    public string DescripcionHard { get; set; }

    public string? Condicion { get; set; }

    public string? ObservacionPre { get; set; }

    public string? ObservacionPost { get; set; }

    public DateTime? FechaPreHard { get; set; }

    public DateTime? FechaPostHard { get; set; }

    public bool? EstatusHard { get; set; }

    public int IdSolicitanteHard { get; set; }

    public int IdOperador { get; set; }

    public virtual Operador? IdOperadorNavigation { get; set; }

    public virtual SolicitanteHard? IdSolicitanteHardNavigation { get; set; }
}
