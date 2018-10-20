using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
{
    public partial class HubUserGroup
    {
        public HubUserGroup()
        {
            MappingUserGroup = new HashSet<MappingUserGroup>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        [StringLength(50)]
        public string OcuUserGroupCode { get; set; }
        [StringLength(50)]
        public string OcuUserGroupName { get; set; }

        [InverseProperty("HubUserGroup")]
        public ICollection<MappingUserGroup> MappingUserGroup { get; set; }
        [InverseProperty("HubUserGroup")]
        public ICollection<Product> Product { get; set; }
    }
}
