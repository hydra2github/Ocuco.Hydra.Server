using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
{
    public partial class HubBrand
    {
        public HubBrand()
        {
            MappingBrand = new HashSet<MappingBrand>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        [StringLength(50)]
        public string OcuBrandName { get; set; }
        [StringLength(50)]
        public string OcuBrandCode { get; set; }
        public int? ManufacturerId { get; set; }

        [ForeignKey("ManufacturerId")]
        [InverseProperty("HubBrand")]
        public Manufacturer Manufacturer { get; set; }
        [InverseProperty("HubBrand")]
        public ICollection<MappingBrand> MappingBrand { get; set; }
        [InverseProperty("HubBrand")]
        public ICollection<Product> Product { get; set; }
    }
}
