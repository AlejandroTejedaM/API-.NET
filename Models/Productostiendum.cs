using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Productostiendum
{
    public int Id { get; set; }

    public short IdTienda { get; set; }

    public int IdProducto { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Tienda IdTiendaNavigation { get; set; } = null!;
}
