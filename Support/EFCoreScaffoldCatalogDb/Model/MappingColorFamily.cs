using System;
using System.Collections.Generic;

namespace EFCoreScaffoldCatalogDb.Model
{
    public partial class MappingColorFamily
    {
        public int Id { get; set; }
        public int? CatalogueMappingGroupId { get; set; }
        public string CatColorFamily { get; set; }
        public int? HubColorFamilyId { get; set; }

        public CatalogueMappingGroup CatalogueMappingGroup { get; set; }
        public HubColorFamily HubColorFamily { get; set; }
    }
}
