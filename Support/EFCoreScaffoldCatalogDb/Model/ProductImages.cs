using System;
using System.Collections.Generic;

namespace EFCoreScaffoldCatalogDb.Model
{
    public partial class ProductImages
    {
        public int Id { get; set; }
        public string Upc { get; set; }
        public string ImageUrl { get; set; }
        public string OcuProductType { get; set; }
        public int? ManufacturerId { get; set; }

        public Manufacturer Manufacturer { get; set; }
    }
}
