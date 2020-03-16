using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OodweyneMadrasa.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        [MaxLength (20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(6)]
        public string Gender { get; set; }
        [Required]
        public int Age { get; set; }
        //? means that it could be nulible.
        public int? TeacherId { get; set; }
        // Navigation Property 
        public virtual Teacher Teacher { get; set; }
        public int? SubjectId { get; set; }
        // Navigation Property
        public virtual Subject Subject { get; set; }
    }
}
