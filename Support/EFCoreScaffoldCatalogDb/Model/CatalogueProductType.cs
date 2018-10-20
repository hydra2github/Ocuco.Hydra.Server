using System;
using System.Collections.Generic;

namespace EFCoreScaffoldCatalogDb.Model
{
    public partial class CatalogueProductType
    {
        public CatalogueProductType()
        {
            Catalogue = new HashSet<Catalogue>();
        }

        public int Id { get; set; }
        public string CatalogueProductTypeName { get; set; }

        public ICollection<Catalogue> Catalogue { get; set; }
    }
}
