using System;
using System.Collections.Generic;

namespace EFCoreScaffoldCatalogDb.Model
{
    public partial class HubFrameMaterial
    {
        public HubFrameMaterial()
        {
            MappingFrameMaterial = new HashSet<MappingFrameMaterial>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string OcuFrameMaterialCode { get; set; }
        public string OcuFrameMaterialName { get; set; }

        public ICollection<MappingFrameMaterial> MappingFrameMaterial { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
