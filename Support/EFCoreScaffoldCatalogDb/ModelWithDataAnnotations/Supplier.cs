using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
{
    public partial class Supplier
    {
        public Supplier()
        {
            Catalogue = new HashSet<Catalogue>();
        }

        public int Id { get; set; }
        [StringLength(50)]
        public string SupplierName { get; set; }

        [InverseProperty("Supplier")]
        public ICollection<Catalogue> Catalogue { get; set; }
    }
}
