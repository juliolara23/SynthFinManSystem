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

        [Required] public decimal Amount { get; set; }
        /* amount of the transaction in local currency */

        [Required]
        [MaxLength(20)]
        public string Type { get; set; }
        /* Values: CASH-IN, CASH-OUT, DEBIT, PAYMENT and TRANSFER */

        [Required]
        [MaxLength(100)]
        public string NameOrig { get; set; }
        /* customer who started the transaction */

        [Required]
        [MaxLength(100)]
        public string NameDest { get; set; }
        /* Customer recipient of the transaction. */

        [Required]
        public DateTimeOffset TransactionDate { get; set; }

        [Required]
        public bool IsFraud { get; set; }
        /* identifies a fraudulent transaction (1) and non fraudulent (0) */

    }
}
