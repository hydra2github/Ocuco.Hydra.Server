using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
{
    public partial class MappingBrand
    {
        public int Id { get; set; }
        public int? CatalogueId { get; set; }
        [StringLength(50)]
        public string CatBrandCode { get; set; }
        [StringLength(50)]
        public string CatBrandName { get; set; }
        public int? HubBrandId { get; set; }

        [ForeignKey("CatalogueId")]
        [InverseProperty("MappingBrand")]
        public Catalogue Catalogue { get; set; }
        [ForeignKey("HubBrandId")]
        [InverseProperty("MappingBrand")]
        public HubBrand HubBrand { get; set; }
    }
}
