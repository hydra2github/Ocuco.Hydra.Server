using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
{
    public partial class MappingShape
    {
        public int Id { get; set; }
        [Column("CatalogueMappingGroupID")]
        public int? CatalogueMappingGroupId { get; set; }
        [StringLength(50)]
        public string CatShapeCode { get; set; }
        [StringLength(50)]
        public string CatShapeDesc { get; set; }
        public int? HubShapeId { get; set; }

        [ForeignKey("CatalogueMappingGroupId")]
        [InverseProperty("MappingShape")]
        public CatalogueMappingGroup CatalogueMappingGroup { get; set; }
        [ForeignKey("HubShapeId")]
        [InverseProperty("MappingShape")]
        public HubShape HubShape { get; set; }
    }
}
