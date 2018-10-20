using System;
using System.Collections.Generic;

namespace Ocuco.DataModel.Catalog.Entities
{
    public partial class CatalogueMappingGroup
    {
        public CatalogueMappingGroup()
        {
            Catalogue = new HashSet<Catalogue>();
            MappingColorFamily = new HashSet<MappingColorFamily>();
            MappingFrameMaterial = new HashSet<MappingFrameMaterial>();
            MappingGender = new HashSet<MappingGender>();
            MappingRimType = new HashSet<MappingRimType>();
            MappingShape = new HashSet<MappingShape>();
            MappingUserGroup = new HashSet<MappingUserGroup>();
        }

        public int Id { get; set; }
        public string CatalogueFormatName { get; set; }

        public ICollection<Catalogue> Catalogue { get; set; }
        public ICollection<MappingColorFamily> MappingColorFamily { get; set; }
        public ICollection<MappingFrameMaterial> MappingFrameMaterial { get; set; }
        public ICollection<MappingGender> MappingGender { get; set; }
        public ICollection<MappingRimType> MappingRimType { get; set; }
        public ICollection<MappingShape> MappingShape { get; set; }
        public ICollection<MappingUserGroup> MappingUserGroup { get; set; }
    }
}
