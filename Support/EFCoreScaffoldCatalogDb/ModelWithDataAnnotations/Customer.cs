using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
{
    public partial class Customer
    {
        public Customer()
        {
            CatalogueSubscription = new HashSet<CatalogueSubscription>();
        }

        public int Id { get; set; }
        [StringLength(50)]
        public string CustomerName { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(50)]
        public string Company { get; set; }

        [InverseProperty("Customer")]
        public ICollection<CatalogueSubscription> CatalogueSubscription { get; set; }
    }
}
