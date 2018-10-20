using System;
using System.Collections.Generic;

namespace Ocuco.DataModel.Catalog.Entities
{
    public partial class MappingGender
    {
        public int Id { get; set; }
        public int? CatalogueMappingGroupId { get; set; }
        public string CatGenderCode { get; set; }
        public string CatGenderDesc { get; set; }
        public int? HubGenderId { get; set; }

        public CatalogueMappingGroup CatalogueMappingGroup { get; set; }
        public HubGender HubGender { get; set; }
    }
}
