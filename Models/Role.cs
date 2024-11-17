using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Role
{
    public sbyte Id { get; set; }

    public string Rol { get; set; } = null!;

    public virtual ICollection<Encargadotiendum> Encargadotienda { get; set; } = new List<Encargadotiendum>();
}
