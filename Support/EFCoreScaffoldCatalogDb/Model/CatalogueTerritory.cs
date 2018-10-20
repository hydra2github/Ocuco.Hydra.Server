using System;
using System.Collections.Generic;

namespace EFCoreScaffoldCatalogDb.Model
{
    public partial class CatalogueTerritory
    {
        public int Id { get; set; }
        public int? CatalogueId { get; set; }
        public int? TerritoryId { get; set; }

        public Catalogue Catalogue { get; set; }
        public Territory Territory { get; set; }
    }
}
