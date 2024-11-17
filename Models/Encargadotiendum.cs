using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Encargadotiendum
{
    public short Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apepat { get; set; } = null!;

    public string Apemat { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Usuario { get; set; } = null!;

    public string Pwd { get; set; } = null!;

    public sbyte IdRol { get; set; }

    public virtual Role IdRolNavigation { get; set; } = null!;

    public virtual ICollection<Tienda> Tienda { get; set; } = new List<Tienda>();
}
