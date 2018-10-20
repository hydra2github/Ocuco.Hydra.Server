using System;
using System.Collections.Generic;

namespace Ocuco.DataModel.Catalog.Entities
{
    public partial class HubBrand
    {
        public HubBrand()
        {
            MappingBrand = new HashSet<MappingBrand>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string OcuBrandName { get; set; }
        public string OcuBrandCode { get; set; }
        public int? ManufacturerId { get; set; }

        public Manufacturer Manufacturer { get; set; }
        public ICollection<MappingBrand> MappingBrand { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
