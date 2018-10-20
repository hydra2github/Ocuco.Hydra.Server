using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Catalogue = new HashSet<Catalogue>();
            HubBrand = new HashSet<HubBrand>();
            ProductImages = new HashSet<ProductImages>();
        }

        public int Id { get; set; }
        [StringLength(50)]
        public string ManufacturerName { get; set; }

        [InverseProperty("Manufacturer")]
        public ICollection<Catalogue> Catalogue { get; set; }
        [InverseProperty("Manufacturer")]
        public ICollection<HubBrand> HubBrand { get; set; }
        [InverseProperty("Manufacturer")]
        public ICollection<ProductImages> ProductImages { get; set; }
    }
}
