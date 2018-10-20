using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
{
    public partial class ProductImages
    {
        public int Id { get; set; }
        [Column("UPC")]
        [StringLength(50)]
        public string Upc { get; set; }
        [Column("ImageURL")]
        [StringLength(255)]
        public string ImageUrl { get; set; }
        [StringLength(50)]
        public string OcuProductType { get; set; }
        public int? ManufacturerId { get; set; }

        [ForeignKey("ManufacturerId")]
        [InverseProperty("ProductImages")]
        public Manufacturer Manufacturer { get; set; }
    }
}
