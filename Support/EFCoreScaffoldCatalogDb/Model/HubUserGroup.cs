using System;
using System.Collections.Generic;

namespace EFCoreScaffoldCatalogDb.Model
{
    public partial class HubUserGroup
    {
        public HubUserGroup()
        {
            MappingUserGroup = new HashSet<MappingUserGroup>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string OcuUserGroupCode { get; set; }
        public string OcuUserGroupName { get; set; }

        public ICollection<MappingUserGroup> MappingUserGroup { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
