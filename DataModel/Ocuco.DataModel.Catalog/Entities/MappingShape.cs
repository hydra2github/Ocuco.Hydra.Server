using System;
using System.Collections.Generic;

namespace Ocuco.DataModel.Catalog.Entities
{
    public partial class MappingShape
    {
        public int Id { get; set; }
        public int? CatalogueMappingGroupId { get; set; }
        public string CatShapeCode { get; set; }
        public string CatShapeDesc { get; set; }
        public int? HubShapeId { get; set; }

        public CatalogueMappingGroup CatalogueMappingGroup { get; set; }
        public HubShape HubShape { get; set; }
    }
}
