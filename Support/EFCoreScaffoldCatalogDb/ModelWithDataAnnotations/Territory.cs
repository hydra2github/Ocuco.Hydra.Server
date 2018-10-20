using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
{
    public partial class Territory
    {
        public Territory()
        {
            CatalogueTerritory = new HashSet<CatalogueTerritory>();
        }

        public int Id { get; set; }
        [StringLength(50)]
        public string TerritoryName { get; set; }

        [InverseProperty("Territory")]
        public ICollection<CatalogueTerritory> CatalogueTerritory { get; set; }
    }
}
