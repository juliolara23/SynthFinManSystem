using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthFinManSystem.Model.Objects
{
    [Table("Role")]
    public class Role
    {

        [Key]
        [Required]
        [MaxLength(1)]
        public string Id { get; set; }
        /* ID roles values: D = Adminstrator, M = Manager, A = Assistant */

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

    }
}
