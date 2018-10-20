using System;
using System.Collections.Generic;

namespace EFCoreScaffoldCatalogDb.Model
{
    public partial class Supplier
    {
        public Supplier()
        {
            Catalogue = new HashSet<Catalogue>();
        }

        public int Id { get; set; }
        public string SupplierName { get; set; }

        public ICollection<Catalogue> Catalogue { get; set; }
    }
}
