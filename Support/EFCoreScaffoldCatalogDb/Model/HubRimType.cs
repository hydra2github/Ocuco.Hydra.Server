using System;
using System.Collections.Generic;

namespace EFCoreScaffoldCatalogDb.Model
{
    public partial class HubRimType
    {
        public HubRimType()
        {
            MappingRimType = new HashSet<MappingRimType>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string OcuRimTypeCode { get; set; }
        public string OcuRimTypeName { get; set; }

        public ICollection<MappingRimType> MappingRimType { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
