using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.Models
{
    public class AttributeMaster
    {
        [Key]
        public int AttributeId { get; set; }
        public string? AttributeDescription { get; set; }

        public ICollection<ProductAttribute>? ProductAttributes { get; set; }
    }
}
