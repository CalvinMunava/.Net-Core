using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Architecture.Models
{
    public class Student
    {
        [Key]
        public int studentId { get; set; }

        [Required]
        [StringLength(100)]       
        public string name { get; set; }

        [Required]
        [StringLength(100)]
        public string Surname { get; set; }

        [Required]
        [StringLength(100)]
        public int studentNumber { get; set; }

        public int courseId { get; set; }
        public Course Course { get; set; }

    }
}
