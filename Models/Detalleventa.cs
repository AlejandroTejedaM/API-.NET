using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Detalleventa
{
    public int Id { get; set; }

    public decimal Precio { get; set; }

    public int Cantidad { get; set; }

    public int IdVenta { get; set; }

    public int IdProducto { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Venta IdVentaNavigation { get; set; } = null!;
}
