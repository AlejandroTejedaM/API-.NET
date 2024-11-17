using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Categoria
{
    public sbyte Id { get; set; }

    public string NombreCategoria { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
