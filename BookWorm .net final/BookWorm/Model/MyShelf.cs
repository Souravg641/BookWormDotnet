using BookWorm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.Models
{
    public class MyShelf
    {
        [Key]
        public int ShelfId { get; set; }
        [ForeignKey("CustomerMaster")]
        public int CustomerId { get; set; }
        public CustomerMaster? Customer { get; set; }

        public ICollection<ProductMaster>? ProductMaster { get; set; }
        public string? TransactionType { get; set; }
        public DateTime? ProductExpiryDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
