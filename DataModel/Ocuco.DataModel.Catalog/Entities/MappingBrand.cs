using System;
using System.Collections.Generic;

namespace Ocuco.DataModel.Catalog.Entities
{
    public partial class MappingBrand
    {
        public int Id { get; set; }
        public int? CatalogueId { get; set; }
        public string CatBrandCode { get; set; }
        public string CatBrandName { get; set; }
        public int? HubBrandId { get; set; }

        public Catalogue Catalogue { get; set; }
        public HubBrand HubBrand { get; set; }
    }
}
