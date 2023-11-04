using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Architecture.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }

        [AllowNull]
        public int Quantity { get; set; }

    }
}
