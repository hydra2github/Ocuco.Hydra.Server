using System;
using System.Collections.Generic;

namespace Ocuco.DataModel.Catalog.Entities
{
    public partial class CatalogueSource
    {
        public CatalogueSource()
        {
            Catalogue = new HashSet<Catalogue>();
        }

        public int Id { get; set; }
        public string CatalogSourceName { get; set; }

        public ICollection<Catalogue> Catalogue { get; set; }
    }
}
