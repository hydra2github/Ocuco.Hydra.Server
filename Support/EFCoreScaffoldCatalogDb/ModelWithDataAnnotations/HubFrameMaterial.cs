using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
{
    public partial class HubFrameMaterial
    {
        public HubFrameMaterial()
        {
            MappingFrameMaterial = new HashSet<MappingFrameMaterial>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        [StringLength(50)]
        public string OcuFrameMaterialCode { get; set; }
        [StringLength(50)]
        public string OcuFrameMaterialName { get; set; }

        [InverseProperty("HubFrameMaterial")]
        public ICollection<MappingFrameMaterial> MappingFrameMaterial { get; set; }
        [InverseProperty("HubFrameMaterial")]
        public ICollection<Product> Product { get; set; }
    }
}
