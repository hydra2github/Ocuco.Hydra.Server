using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
{
    public partial class CatalogueTerritory
    {
        public int Id { get; set; }
        public int? CatalogueId { get; set; }
        public int? TerritoryId { get; set; }

        [ForeignKey("CatalogueId")]
        [InverseProperty("CatalogueTerritory")]
        public Catalogue Catalogue { get; set; }
        [ForeignKey("TerritoryId")]
        [InverseProperty("CatalogueTerritory")]
        public Territory Territory { get; set; }
    }
}
