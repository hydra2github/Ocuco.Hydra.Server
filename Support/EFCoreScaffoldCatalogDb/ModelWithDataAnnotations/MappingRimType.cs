using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
{
    public partial class MappingRimType
    {
        public int Id { get; set; }
        [Column("CatalogueMappingGroupID")]
        public int? CatalogueMappingGroupId { get; set; }
        [StringLength(50)]
        public string CatRimTypeCode { get; set; }
        [StringLength(50)]
        public string CatRimTypeDesc { get; set; }
        public int? HubRimTypeId { get; set; }

        [ForeignKey("CatalogueMappingGroupId")]
        [InverseProperty("MappingRimType")]
        public CatalogueMappingGroup CatalogueMappingGroup { get; set; }
        [ForeignKey("HubRimTypeId")]
        [InverseProperty("MappingRimType")]
        public HubRimType HubRimType { get; set; }
    }
}
