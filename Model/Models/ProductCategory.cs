using System;
using System.Collections.Generic;

namespace Model.Models;

public partial class ProductCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> ListProducts { get; set; } = new List<Product>();
}
