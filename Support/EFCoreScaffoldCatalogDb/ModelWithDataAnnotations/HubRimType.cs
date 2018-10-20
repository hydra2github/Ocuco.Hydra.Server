using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
{
    public partial class HubRimType
    {
        public HubRimType()
        {
            MappingRimType = new HashSet<MappingRimType>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        [StringLength(50)]
        public string OcuRimTypeCode { get; set; }
        [StringLength(50)]
        public string OcuRimTypeName { get; set; }

        [InverseProperty("HubRimType")]
        public ICollection<MappingRimType> MappingRimType { get; set; }
        [InverseProperty("HubRimType")]
        public ICollection<Product> Product { get; set; }
    }
}
