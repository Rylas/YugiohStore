using System;
using System.Collections.Generic;

namespace Model.Models;

public partial class BillDetails
{
    public int Id { get; set; }

    public int IdBill { get; set; }

    public int IdProduct { get; set; }

    public int Quantity { get; set; }

    public virtual Bill IdBillNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
