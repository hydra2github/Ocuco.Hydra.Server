using System;
using System.Collections.Generic;

namespace Ocuco.DataModel.Catalog.Entities
{
    public partial class MappingUserGroup
    {
        public int Id { get; set; }
        public int? CatalogueMappingGroupId { get; set; }
        public string CatUserGroupCode { get; set; }
        public string CatUserGroupDesc { get; set; }
        public int? HubUserGroupId { get; set; }

        public CatalogueMappingGroup CatalogueMappingGroup { get; set; }
        public HubUserGroup HubUserGroup { get; set; }
    }
}
