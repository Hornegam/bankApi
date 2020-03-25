using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class PaymentDetails
    {
        [Key]
        public int PMId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public String CardOwnerName { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(16)")]
        public String CardNumber { get; set; }
 
        [Required]
        [Column(TypeName = "nvarchar(5)")]
        public String ExpirationDate { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(3)")]
        public String CVVNumber { get; set; }
    }
}
