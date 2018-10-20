using System;
using System.Collections.Generic;

namespace EFCoreScaffoldCatalogDb.Model
{
    public partial class CatalogueSubscription
    {
        public int Id { get; set; }
        public int? CatalogueId { get; set; }
        public int? CustomerId { get; set; }
        public string SubscriptionName { get; set; }
        public int? Status { get; set; }

        public Catalogue Catalogue { get; set; }
        public Customer Customer { get; set; }
    }
}
