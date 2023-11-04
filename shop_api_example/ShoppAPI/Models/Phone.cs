using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppAPI.Models
{
    public class Phone
    {
        [Key]
        public int phoneID { get; set; }
        [Required]
        public string phoneName { get; set; }
        [Required]
        public string phoneModel { get; set; }
        [Required]
        public DateTime phoneReleaseYear { get; set; }
        [Required]
        public string phoneStorage { get; set; }
        [Required]
        public decimal phonePrice { get; set; }

    }
}
