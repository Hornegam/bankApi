using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI2.Models
{
    public class BankAccount
    {
        [Key]
        public int BankAccountID { get; set; }
        
        [Column(TypeName = "nvarchar(20)")]
        [Required]
        public String AccountNumber { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public String AccountHolder { get; set; }
        [Required]
        public int BankID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public String IFSC { get; set; }

    }
}
