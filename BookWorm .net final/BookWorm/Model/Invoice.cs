using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set;}

        [ForeignKey("CustomerMaster")]
        public int CustomerId { get; set; } 
        public CustomerMaster? Customer { get; set; }
        public float InvoiceAmount { get; set;}

        public RoyaltyCalculation? RoyaltyCalculation { get; set; }
        public InvoiceDetail? InvoiceDetail { get; set; }
    }
}
