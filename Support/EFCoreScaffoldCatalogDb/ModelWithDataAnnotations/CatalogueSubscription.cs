using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
{
    public partial class CatalogueSubscription
    {
        public int Id { get; set; }
        public int? CatalogueId { get; set; }
        public int? CustomerId { get; set; }
        [StringLength(50)]
        public string SubscriptionName { get; set; }
        public int? Status { get; set; }

        [ForeignKey("CatalogueId")]
        [InverseProperty("CatalogueSubscription")]
        public Catalogue Catalogue { get; set; }
        [ForeignKey("CustomerId")]
        [InverseProperty("CatalogueSubscription")]
        public Customer Customer { get; set; }
    }
}
