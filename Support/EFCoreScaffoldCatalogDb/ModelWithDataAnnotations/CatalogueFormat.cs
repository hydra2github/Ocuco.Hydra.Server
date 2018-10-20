using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
{
    public partial class CatalogueFormat
    {
        public CatalogueFormat()
        {
            Catalogue = new HashSet<Catalogue>();
        }

        public int Id { get; set; }
        [StringLength(50)]
        public string CatalogueFormatName { get; set; }

        [InverseProperty("CatalogueFormat")]
        public ICollection<Catalogue> Catalogue { get; set; }
    }
}
