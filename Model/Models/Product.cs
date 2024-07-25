using System;
using System.Collections.Generic;

namespace Model.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ImageLink { get; set; } = null!;

    public int IdCategory { get; set; }

    public int Price { get; set; }

    public int Quantity {  get; set; }

    public bool Status { get; set; }

    public virtual ICollection<BillDetails> BillDetails { get; set; } = new List<BillDetails>();

    public virtual ProductCategory IdProductCategoryNavigation { get; set; } = null!;
}
