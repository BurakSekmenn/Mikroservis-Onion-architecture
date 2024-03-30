using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Domain.Entities
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public string ProductId { get; set; } // Monga Db tutuyoruz burada string olarak tutuyoruz guid olarak tutukuyoruz

        public string ProductName { get; set; }

        public string ProductPrice { get; set; }

        public int ProductAmount { get; set; }

        public decimal TotalPrice { get; set; }

        public int OrderingID { get; set; }

        public Ordering Ordering{ get; set; }

    }
}
