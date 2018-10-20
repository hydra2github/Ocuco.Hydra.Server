using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
{
    public partial class CatalogueProductType
    {
        public CatalogueProductType()
        {
            Catalogue = new HashSet<Catalogue>();
        }

        public int Id { get; set; }
        [StringLength(50)]
        public string CatalogueProductTypeName { get; set; }

        [InverseProperty("CatalogueProductType")]
        public ICollection<Catalogue> Catalogue { get; set; }
    }
}
