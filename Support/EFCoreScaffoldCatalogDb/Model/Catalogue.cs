using System;
using System.Collections.Generic;

namespace EFCoreScaffoldCatalogDb.Model
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
        public string CatalogueName { get; set; }
        public int? CatalogueType { get; set; }
        public int? SupplierId { get; set; }
        public int? ManufacturerId { get; set; }
        public int? CatalogueSourceId { get; set; }
        public int? CatalogueProductTypeId { get; set; }
        public int? CatalogueFormatId { get; set; }
        public int? CatalogueMappingGroupId { get; set; }

        public CatalogueFormat CatalogueFormat { get; set; }
        public CatalogueMappingGroup CatalogueMappingGroup { get; set; }
        public CatalogueProductType CatalogueProductType { get; set; }
        public CatalogueSource CatalogueSource { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<CatalogueSubscription> CatalogueSubscription { get; set; }
        public ICollection<CatalogueTerritory> CatalogueTerritory { get; set; }
        public ICollection<MappingBrand> MappingBrand { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
