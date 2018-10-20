using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
{
    public partial class MappingGender
    {
        public int Id { get; set; }
        [Column("CatalogueMappingGroupID")]
        public int? CatalogueMappingGroupId { get; set; }
        [StringLength(50)]
        public string CatGenderCode { get; set; }
        [StringLength(50)]
        public string CatGenderDesc { get; set; }
        public int? HubGenderId { get; set; }

        [ForeignKey("CatalogueMappingGroupId")]
        [InverseProperty("MappingGender")]
        public CatalogueMappingGroup CatalogueMappingGroup { get; set; }
        [ForeignKey("HubGenderId")]
        [InverseProperty("MappingGender")]
        public HubGender HubGender { get; set; }
    }
}
