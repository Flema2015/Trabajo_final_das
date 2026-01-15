using System;
using System.Collections.Generic;

namespace Trabajo_Final_das.Models;

public partial class Venta
{
    public int IdVenta { get; set; }

    public DateTime? FechaVenta { get; set; }

    public int? MetodosDePago { get; set; }

    public string codigo_producto { get; set; }

    public int? IdCliente { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public string Sucursal { get; set; }

    public decimal Total_final { get; set; }
}
