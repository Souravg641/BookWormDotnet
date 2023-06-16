using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.Models
{
    public class ProductBeneficiaryMaster
    {
        [Key]
        public int ProductBeneficiaryId { get; set; }
        public float ProductBeneficiaryPercentage { get; set; }

        [ForeignKey("BeneficiaryMaster")]
        public int BeneficiaryId { get; set; }
        public BeneficiaryMaster? Beneficiary { get; set; }

        [ForeignKey("ProductMaster")]
        public int ProductId { get; set; }
        public ProductMaster? ProductMaster { get; set; }
    }
}
