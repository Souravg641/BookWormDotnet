using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.Models
{
    public class RoyaltyCalculation
    {
        [Key]
        public int RoyaltyCalculationId { get; set; }

        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }
        public DateTime RoyaltyCalculationTransactiondate { get; set; } 
        public int Quantity { get; set; }
        public int TransactionType { get; set; }

        [ForeignKey("ProductMaster")]
        public int ProductId { get; set; }
        public ProductMaster? Product { get; set; }

        public ICollection<BeneficiaryMaster>? BeneficiaryMasters { get; set; }

    }
}
