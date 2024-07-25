using System;
using System.Collections.Generic;

namespace Model.Models;

public partial class Bill
{
    public int Id { get; set; }

    public DateTime DateBook { get; set; }

    public DateTime? DateCheckOut { get; set; }
    public int? userID { get; set; }

    public bool Status { get; set; }

    public int TotalAmount { get; set; }

    public virtual ICollection<BillDetails> BillDetails { get; set; } = new List<BillDetails>();
    public virtual Account? IDUserNavigation { get; set; }
}
