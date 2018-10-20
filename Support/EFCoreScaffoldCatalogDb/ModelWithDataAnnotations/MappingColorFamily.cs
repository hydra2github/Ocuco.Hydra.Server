using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
{
    public partial class MappingColorFamily
    {
        public int Id { get; set; }
        [Column("CatalogueMappingGroupID")]
        public int? CatalogueMappingGroupId { get; set; }
        [StringLength(50)]
        public string CatColorFamily { get; set; }
        public int? HubColorFamilyId { get; set; }

        [ForeignKey("CatalogueMappingGroupId")]
        [InverseProperty("MappingColorFamily")]
        public CatalogueMappingGroup CatalogueMappingGroup { get; set; }
        [ForeignKey("HubColorFamilyId")]
        [InverseProperty("MappingColorFamily")]
        public HubColorFamily HubColorFamily { get; set; }
    }
}
