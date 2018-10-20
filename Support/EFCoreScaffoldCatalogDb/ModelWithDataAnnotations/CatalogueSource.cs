using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
{
    public partial class CatalogueSource
    {
        public CatalogueSource()
        {
            Catalogue = new HashSet<Catalogue>();
        }

        public int Id { get; set; }
        [StringLength(50)]
        public string CatalogSourceName { get; set; }

        [InverseProperty("CatalogueSource")]
        public ICollection<Catalogue> Catalogue { get; set; }
    }
}
