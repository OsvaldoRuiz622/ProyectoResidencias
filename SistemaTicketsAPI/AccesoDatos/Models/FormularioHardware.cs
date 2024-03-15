using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class FormularioHardware
{
    public int IdFormularioHardware { get; set; }

    public string? Cantidad { get; set; }

    public string? Marca { get; set; }

    public string? NoSerie { get; set; }

    public string? Descripcion { get; set; }

    public string? Condicion { get; set; }

    public string? ObservacionPre { get; set; }

    public string? ObservacionPost { get; set; }

    public DateTime FechaPre { get; set; }

    public DateTime FechaPost { get; set; }

    public int IdSolicitante { get; set; }

    public int IdOperador { get; set; }

    public virtual Operador? IdOperadorNavigation { get; set; }

    public virtual Solicitante? IdSolicitanteNavigation { get; set; }
}
