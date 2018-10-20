using System;
using System.Collections.Generic;

namespace EFCoreScaffoldCatalogDb.Model
{
    public partial class MappingRimType
    {
        public int Id { get; set; }
        public int? CatalogueMappingGroupId { get; set; }
        public string CatRimTypeCode { get; set; }
        public string CatRimTypeDesc { get; set; }
        public int? HubRimTypeId { get; set; }

        public CatalogueMappingGroup CatalogueMappingGroup { get; set; }
        public HubRimType HubRimType { get; set; }
    }
}
