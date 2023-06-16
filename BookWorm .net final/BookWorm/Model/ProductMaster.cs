using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.Models
{
    public class ProductMaster
    {
        // Scalar Properties of ProductMaster Table

        [Key]
        public int ProductId { get; set; }                             // Column name ProductID                  
        public string? ProductName { get; set; }                        // Column name ProductName
        public string? ProductEnglishName { get; set; }                 // Column name ProductEnglishName
        public float? ProductBasePrice { get; set; }                    // Column name ProductBasePrice
        public float? ProductSellingPriceCost { get; set; }                       // Column name ProductSPCost
        public float? ProductOfferPrice { get; set; }                   // Column name ProductOfferPrice
        public DateTime ProductOfferPriceExpiryDate { get; set; }        // Column name ProductOffPriceExpiryDate
        public string? ProductDescriptionShort { get; set; }            // Column name ProductDescriptionShort
        public string? ProductDescriptionLong { get; set; }             // Column name ProductDescriptionLong
        public string? ProductISBN { get; set; }                        // Column name ProductISBN
        public string? ProductAuthor { get; set; }                      // Column name ProductAuthor
        public bool? IsRentable { get; set; }                           // Column name IsRentable
        public bool? IsLibrary { get; set; }                            // Column name IsLibrary
        public float? RentPerDay { get; set; }                          // Column name RentPerDay
        public int? MinRentDays { get; set; }                           // Column name MinRentDays
        public String? ProductImagePath { get; set; }                    // Column name ProductImagePath

        [ForeignKey("ProductTypeMaster")]
        public int? TypeId { get; set; }
        public ProductTypeMaster? ProductTypeMaster { get; set; }

        [ForeignKey("LanguageMaster")]
        public int? LanguageId { get; set; }
        public LanguageMaster? LanguageMaster { get; set; }

        [ForeignKey("GenreMaster")]
        public int GenreId { get; set; }
        public GenreMaster? GenreMaster { get; set; }

        public ICollection<ProductAttribute>? ProductAttribute { get; set; }

        public ICollection<ProductBeneficiaryMaster>? ProductBeneficiaries { get; set; }
        public RoyaltyCalculation? RoyaltyCalculation { get; set; }
        public ICollection<InvoiceDetail>? InvoiceDetails { get; set; }
        public ICollection<MyShelf>? MyShelves { get; set; }
    }
}
