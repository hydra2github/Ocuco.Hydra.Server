using System;
using System.Collections.Generic;

namespace Ocuco.DataModel.Catalog.Entities
{
    public partial class HubGender
    {
        public HubGender()
        {
            MappingGender = new HashSet<MappingGender>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string OcuGenderCode { get; set; }
        public string OcuGenderName { get; set; }

        public ICollection<MappingGender> MappingGender { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
