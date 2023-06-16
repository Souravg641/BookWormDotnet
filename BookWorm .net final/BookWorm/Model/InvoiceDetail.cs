using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.Models
{
    public class InvoiceDetail
    {
        [Key]
        public int InvoiceDetailId { get; set; }

        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }

        [ForeignKey("ProductMaster")]
        public int ProductId { get; set; }
        public ProductMaster? ProductMaster { get; set; }

        public int Quantity { get;set; }
        public float BasePrice { get; set;}
        public string? TransactionType { get; set;}
        public int? RentNumberOfDays { get; set;}
    }
}
