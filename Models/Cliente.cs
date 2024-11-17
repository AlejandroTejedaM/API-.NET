using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apepat { get; set; } = null!;

    public string Apemat { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Usuario { get; set; } = null!;

    public string Pwd { get; set; } = null!;

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
