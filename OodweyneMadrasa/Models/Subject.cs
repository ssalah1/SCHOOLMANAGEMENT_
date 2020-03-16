using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OodweyneMadrasa.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        [Required]
        [MaxLength(25)]
        public string SubjectName { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        public double Cost { get; set; }
        [Required]
        [MaxLength(50)]
        public string Duration { get; set; }
        [Required]
        public int MaxStudents { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
        // Navigation Property
        public virtual List<Student> Students { get; set; }

    }
}
