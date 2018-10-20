using System;
using System.Collections.Generic;

namespace EFCoreScaffoldCatalogDb.Model
{
    public partial class Customer
    {
        public Customer()
        {
            CatalogueSubscription = new HashSet<CatalogueSubscription>();
        }

        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }

        public ICollection<CatalogueSubscription> CatalogueSubscription { get; set; }
    }
}
