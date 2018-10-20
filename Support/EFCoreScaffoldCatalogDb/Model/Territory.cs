using System;
using System.Collections.Generic;

namespace EFCoreScaffoldCatalogDb.Model
{
    public partial class Territory
    {
        public Territory()
        {
            CatalogueTerritory = new HashSet<CatalogueTerritory>();
        }

        public int Id { get; set; }
        public string TerritoryName { get; set; }

        public ICollection<CatalogueTerritory> CatalogueTerritory { get; set; }
    }
}
