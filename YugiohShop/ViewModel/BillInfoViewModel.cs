using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YugiohShop.ViewModel
{
    public class BillDetailsViewModel
    {
        public string productImg { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public double totalAmount => price * quantity;
    }
}
