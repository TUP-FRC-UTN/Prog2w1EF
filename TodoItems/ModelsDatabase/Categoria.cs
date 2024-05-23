using System;
using System.Collections.Generic;

namespace TodoItems.ModelsDatabase;

public partial class Categoria
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
