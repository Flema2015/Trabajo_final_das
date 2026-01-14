using System;
using System.Collections.Generic;

namespace Trabajo_Final_das.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? NombreCliente { get; set; }

    public string? ApellidoCliente { get; set; }

    public int? TipoCliente { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();


}
