using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
{
    public partial class MappingFrameMaterial
    {
        public int Id { get; set; }
        public int? CatalogueMappingGroupId { get; set; }
        [StringLength(50)]
        public string CatFrameMaterialCode { get; set; }
        [StringLength(50)]
        public string CatFrameMaterialDesc { get; set; }
        public int? HubFrameMaterialId { get; set; }

        [ForeignKey("CatalogueMappingGroupId")]
        [InverseProperty("MappingFrameMaterial")]
        public CatalogueMappingGroup CatalogueMappingGroup { get; set; }
        [ForeignKey("HubFrameMaterialId")]
        [InverseProperty("MappingFrameMaterial")]
        public HubFrameMaterial HubFrameMaterial { get; set; }
    }
}
