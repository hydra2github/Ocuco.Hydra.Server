using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
{
    public partial class Catalogue
    {
        public Catalogue()
        {
            CatalogueSubscription = new HashSet<CatalogueSubscription>();
            CatalogueTerritory = new HashSet<CatalogueTerritory>();
            MappingBrand = new HashSet<MappingBrand>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        [StringLength(50)]
        public string CatalogueName { get; set; }
        public int? CatalogueType { get; set; }
        public int? SupplierId { get; set; }
        public int? ManufacturerId { get; set; }
        public int? CatalogueSourceId { get; set; }
        public int? CatalogueProductTypeId { get; set; }
        public int? CatalogueFormatId { get; set; }
        public int? CatalogueMappingGroupId { get; set; }

        [ForeignKey("CatalogueFormatId")]
        [InverseProperty("Catalogue")]
        public CatalogueFormat CatalogueFormat { get; set; }
        [ForeignKey("CatalogueMappingGroupId")]
        [InverseProperty("Catalogue")]
        public CatalogueMappingGroup CatalogueMappingGroup { get; set; }
        [ForeignKey("CatalogueProductTypeId")]
        [InverseProperty("Catalogue")]
        public CatalogueProductType CatalogueProductType { get; set; }
        [ForeignKey("CatalogueSourceId")]
        [InverseProperty("Catalogue")]
        public CatalogueSource CatalogueSource { get; set; }
        [ForeignKey("ManufacturerId")]
        [InverseProperty("Catalogue")]
        public Manufacturer Manufacturer { get; set; }
        [ForeignKey("SupplierId")]
        [InverseProperty("Catalogue")]
        public Supplier Supplier { get; set; }
        [InverseProperty("Catalogue")]
        public ICollection<CatalogueSubscription> CatalogueSubscription { get; set; }
        [InverseProperty("Catalogue")]
        public ICollection<CatalogueTerritory> CatalogueTerritory { get; set; }
        [InverseProperty("Catalogue")]
        public ICollection<MappingBrand> MappingBrand { get; set; }
        [InverseProperty("Catalogue")]
        public ICollection<Product> Product { get; set; }
    }
}
