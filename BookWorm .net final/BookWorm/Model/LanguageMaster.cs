using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.Models
{
    public class LanguageMaster
    {
        [Key]
        public int LanguageId { get; set; }
        public string? LanguageDescription { get; set; }

        [ForeignKey("ProductTypeMaster")]
        public int TypeId { get; set; }
        public ProductTypeMaster? ProductTypeMaster { get; set; }

        public ICollection<GenreMaster>? GenreMasters { get; set;}

        public ICollection<ProductMaster>? ProductMasters { get; set;}
    }
}
