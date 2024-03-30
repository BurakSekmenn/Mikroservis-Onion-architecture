using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Features.CQRS.Results.OrderDetailResults
{
    public class GetOrderByIdQueryResult
    {
        public int OrderDetailId { get; set; }
        public string ProductId { get; set; } // Monga Db tutuyoruz burada string olarak tutuyoruz guid olarak tutukuyoruz

        public string ProductName { get; set; }

        public string ProductPrice { get; set; }

        public int ProductAmount { get; set; }

        public decimal TotalPrice { get; set; }

        public int OrderingID { get; set; }
    }
}
