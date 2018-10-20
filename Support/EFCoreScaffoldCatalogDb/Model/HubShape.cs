using System;
using System.Collections.Generic;

namespace EFCoreScaffoldCatalogDb.Model
{
    public partial class HubShape
    {
        public HubShape()
        {
            MappingShape = new HashSet<MappingShape>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string OcuShapeCode { get; set; }
        public string OcuShapeName { get; set; }

        public ICollection<MappingShape> MappingShape { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
