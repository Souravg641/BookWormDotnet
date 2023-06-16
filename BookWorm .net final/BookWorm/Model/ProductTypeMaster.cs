using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.Models
{
    public class ProductTypeMaster
    {
        [Key]
        public int TypeId { get; set; }
        public string? TypeDescription { get; set; }

        public ICollection<LanguageMaster>? LanguageMaster { get; set; }
        public ICollection<ProductMaster>? ProductMasters { get; set; }
   }
}
