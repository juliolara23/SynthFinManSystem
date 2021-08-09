using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthFinManSystem.Model.Objects
{
    [Table("User")]
    public class User
    {
        [Key]
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [NotMapped]
        public bool Valid { get; set; }
    }
}
