using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.Models
{
    public class GenreMaster
    {
        [Key]
        public int GenreId { get; set; }
        public string? GenreDescription { get; set; }

        [ForeignKey("LanguageMaster")]
        public int LanguageId { get; set; }
        public LanguageMaster? LanguageMaster { get; set; }

        public ICollection<ProductMaster>? ProductMasters { get; set; }
    }
}
