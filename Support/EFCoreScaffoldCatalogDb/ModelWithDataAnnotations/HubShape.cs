using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
{
    public partial class HubShape
    {
        public HubShape()
        {
            MappingShape = new HashSet<MappingShape>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        [StringLength(50)]
        public string OcuShapeCode { get; set; }
        [StringLength(50)]
        public string OcuShapeName { get; set; }

        [InverseProperty("HubShape")]
        public ICollection<MappingShape> MappingShape { get; set; }
        [InverseProperty("HubShape")]
        public ICollection<Product> Product { get; set; }
    }
}
