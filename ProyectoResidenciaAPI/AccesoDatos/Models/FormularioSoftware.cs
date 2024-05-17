using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class FormularioSoftware
{
    public int IdFormularioSoftware { get; set; }

    public string Descripcion { get; set; } = null!;

    public string? NombreArchivo { get; set; }

    public byte[]? FileData { get; set; }

    public DateTime? FechaPre { get; set; }

    public DateTime? FechaPost { get; set; }

    public bool? Estatus { get; set; }

    public int IdSolicitanteSoft { get; set; }

    public int IdOperador { get; set; }

    public virtual Operador? IdOperadorNavigation { get; set; }

    public virtual SolicitanteSoft? IdSolicitanteSoftNavigation { get; set; }
}
