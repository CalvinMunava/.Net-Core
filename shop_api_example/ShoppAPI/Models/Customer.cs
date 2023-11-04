using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace ShoppAPI.Models
{
    public class Customer
    {
        [Key]
        public int customerID { get; set; }
        public string customerName { get; set; }
        public string customerSurname { get; set; }
        public string cellPhone { get; set; }
        public string customerRegion { get; set; }
        public Order Order { get; set; }
    }
}
