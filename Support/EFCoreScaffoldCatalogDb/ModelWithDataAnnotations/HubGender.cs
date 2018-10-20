using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
{
    public partial class HubGender
    {
        public HubGender()
        {
            MappingGender = new HashSet<MappingGender>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        [StringLength(50)]
        public string OcuGenderCode { get; set; }
        [StringLength(50)]
        public string OcuGenderName { get; set; }

        [InverseProperty("HubGender")]
        public ICollection<MappingGender> MappingGender { get; set; }
        [InverseProperty("HubGender")]
        public ICollection<Product> Product { get; set; }
    }
}
