using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class FormularioSoftware
{
    public int IdFormularioSoftware { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Imagen { get; set; } = null!;

    public DateTime FechaPre { get; set; }

    public DateTime FechaPost { get; set; }

    public int IdSolicitante { get; set; }

    public int IdOperador { get; set; }

    public virtual Operador? IdOperadorNavigation { get; set; }

    public virtual Solicitante? IdSolicitanteNavigation { get; set; }
}
