using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
{
    public partial class HubColorFamily
    {
        public HubColorFamily()
        {
            MappingColorFamily = new HashSet<MappingColorFamily>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        [StringLength(50)]
        public string OcuColorFamily { get; set; }

        [InverseProperty("HubColorFamily")]
        public ICollection<MappingColorFamily> MappingColorFamily { get; set; }
        [InverseProperty("HubColorFamily")]
        public ICollection<Product> Product { get; set; }
    }
}
