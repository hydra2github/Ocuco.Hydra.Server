using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
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
        [StringLength(50)]
        public string CatalogueFormatName { get; set; }

        [InverseProperty("CatalogueMappingGroup")]
        public ICollection<Catalogue> Catalogue { get; set; }
        [InverseProperty("CatalogueMappingGroup")]
        public ICollection<MappingColorFamily> MappingColorFamily { get; set; }
        [InverseProperty("CatalogueMappingGroup")]
        public ICollection<MappingFrameMaterial> MappingFrameMaterial { get; set; }
        [InverseProperty("CatalogueMappingGroup")]
        public ICollection<MappingGender> MappingGender { get; set; }
        [InverseProperty("CatalogueMappingGroup")]
        public ICollection<MappingRimType> MappingRimType { get; set; }
        [InverseProperty("CatalogueMappingGroup")]
        public ICollection<MappingShape> MappingShape { get; set; }
        [InverseProperty("CatalogueMappingGroup")]
        public ICollection<MappingUserGroup> MappingUserGroup { get; set; }
    }
}
