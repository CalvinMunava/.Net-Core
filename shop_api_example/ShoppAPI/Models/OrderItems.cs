using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppAPI.Models
{
    public class OrderItems
    {
        [Key]
        public int orderItemID { get; set; }

        public int orderID { get; set; }
        public Order Order { get; set; }

        public int phoneID { get; set; }
        public Phone Phone { get; set; }

        public int quantity { get; set; }
    }
}
