using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string NombreProducto { get; set; } = null!;

    public int Stock { get; set; }

    public decimal Precio { get; set; }

    public sbyte IdCategoria { get; set; }

    public virtual ICollection<Detalleventa> Detalleventa { get; set; } = new List<Detalleventa>();

    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;

    public virtual ICollection<Productostiendum> Productostienda { get; set; } = new List<Productostiendum>();
}
