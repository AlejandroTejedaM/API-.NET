using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Venta
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public TimeSpan Hora { get; set; }

    public int IdCliente { get; set; }

    public virtual ICollection<Detalleventa> Detalleventa { get; set; } = new List<Detalleventa>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
