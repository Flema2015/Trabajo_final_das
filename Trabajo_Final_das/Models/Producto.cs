using System;
using System.Collections.Generic;

namespace Trabajo_Final_das.Models;

public partial class Producto
{
    public string Codigo_producto { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Categoria { get; set; }

    public decimal? Precio { get; set; }

    public int? CantidadStock { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
