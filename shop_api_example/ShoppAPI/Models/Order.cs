using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppAPI.Models
{
    public class Order
    {
        [Key]
        public int orderID { get; set; }
        public string orderNo { get; set; }

        public int customerID { get; set; }
        public Customer Customer { get; set; }

        public string payMethod { get; set; }
        public decimal grandTotal { get; set; }

        public OrderItems orderItems { get; set; }
    }
}
