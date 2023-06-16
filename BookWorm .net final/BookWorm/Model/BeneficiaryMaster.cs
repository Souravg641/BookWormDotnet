using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.Models
{
    public class BeneficiaryMaster
    {
        [Key]
        public int BeneficiaryId { get; set;}
        public string? BeneficiaryName { get; set;}

        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email format")]
        public int BeneficiaryEmailId { get; set; }
        public string BeneficiaryContactNo { get; set; }  
        public string? BeneficiaryBankName { get; set; }
        public string? BeneficiaryBankBranch { get; set; }
        public string? BeneficiaryIFSC { get; set; }
        public long BeneficiaryAccountNumber { get; set; }
        public string BeneficiaryAccountType { get; set; }
        public string BeneficiaryPAN { get; set; }

        public ProductBeneficiaryMaster? ProductBeneficiaryMaster { get; set; }
        public ICollection<RoyaltyCalculation>? RoyaltyCalculations { get; set; }
    }
}
