using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthFinManSystem.Model.Objects
{
    [Table("Transaction")]
    public class Transaction
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(20)]
        public string Type { get; set; }

        [Required]
        [MaxLength(100)]
        public string NameOrig { get; set; }

        [Required]
        [MaxLength(100)]
        public string NameDest { get; set; }

        [Required]
        public DateTimeOffset TransactionDate { get; set; }

        [Required]
        public bool IsFraud { get; set; }

    }
}
