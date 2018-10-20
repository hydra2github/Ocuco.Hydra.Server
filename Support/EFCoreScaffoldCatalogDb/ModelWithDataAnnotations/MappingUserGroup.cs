using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
{
    public partial class MappingUserGroup
    {
        public int Id { get; set; }
        [Column("CatalogueMappingGroupID")]
        public int? CatalogueMappingGroupId { get; set; }
        [StringLength(50)]
        public string CatUserGroupCode { get; set; }
        [StringLength(50)]
        public string CatUserGroupDesc { get; set; }
        public int? HubUserGroupId { get; set; }

        [ForeignKey("CatalogueMappingGroupId")]
        [InverseProperty("MappingUserGroup")]
        public CatalogueMappingGroup CatalogueMappingGroup { get; set; }
        [ForeignKey("HubUserGroupId")]
        [InverseProperty("MappingUserGroup")]
        public HubUserGroup HubUserGroup { get; set; }
    }
}
