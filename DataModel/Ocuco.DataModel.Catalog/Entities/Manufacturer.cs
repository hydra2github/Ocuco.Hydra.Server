using System;
using System.Collections.Generic;

namespace Ocuco.DataModel.Catalog.Entities
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
        public string ManufacturerName { get; set; }

        public ICollection<Catalogue> Catalogue { get; set; }
        public ICollection<HubBrand> HubBrand { get; set; }
        public ICollection<ProductImages> ProductImages { get; set; }
    }
}
