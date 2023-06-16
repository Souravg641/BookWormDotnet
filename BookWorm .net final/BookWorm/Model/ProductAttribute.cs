using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.Models
{
    public class ProductAttribute
    {
        [Key]
        public int ProductAttributeId { get; set; }
        public int AttributeValue {  get; set; }

        [ForeignKey("AttributeMaster")]
        public int AttributeId { get; set; }
        public AttributeMaster? AttributeMaster { get; set; }

        [ForeignKey("ProductMaster")]
        public int ProductId { get; set; }
        public ProductMaster? ProductMaster { get; set; }
    }
}
