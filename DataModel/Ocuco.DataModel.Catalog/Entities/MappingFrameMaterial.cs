using System;
using System.Collections.Generic;

namespace Ocuco.DataModel.Catalog.Entities
{
    public partial class MappingFrameMaterial
    {
        public int Id { get; set; }
        public int? CatalogueMappingGroupId { get; set; }
        public string CatFrameMaterialCode { get; set; }
        public string CatFrameMaterialDesc { get; set; }
        public int? HubFrameMaterialId { get; set; }

        public CatalogueMappingGroup CatalogueMappingGroup { get; set; }
        public HubFrameMaterial HubFrameMaterial { get; set; }
    }
}
