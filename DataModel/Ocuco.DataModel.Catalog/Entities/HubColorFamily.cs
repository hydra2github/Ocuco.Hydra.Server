using System;
using System.Collections.Generic;

namespace Ocuco.DataModel.Catalog.Entities
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
