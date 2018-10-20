using System;
using System.Collections.Generic;

namespace EFCoreScaffoldCatalogDb.Model
{
    public partial class HubColorFamily
    {
        public HubColorFamily()
        {
            MappingColorFamily = new HashSet<MappingColorFamily>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string OcuColorFamily { get; set; }

        public ICollection<MappingColorFamily> MappingColorFamily { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
