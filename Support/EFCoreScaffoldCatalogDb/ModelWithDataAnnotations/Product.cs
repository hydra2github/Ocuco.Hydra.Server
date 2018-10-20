using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreScaffoldCatalogDb.ModelWithDataAnnotations
{
    public partial class Product
    {
        public int Id { get; set; }
        public int? CatalogueId { get; set; }
        [Column("UPC")]
        [StringLength(50)]
        public string Upc { get; set; }
        [Column("SKUCode")]
        [StringLength(50)]
        public string Skucode { get; set; }
        [StringLength(50)]
        public string ArticleName { get; set; }
        [StringLength(50)]
        public string CatBrandCode { get; set; }
        [StringLength(50)]
        public string CatBrandName { get; set; }
        public int? HubBrandId { get; set; }
        [StringLength(50)]
        public string OcuBrandName { get; set; }
        [StringLength(50)]
        public string CatProductType { get; set; }
        [StringLength(50)]
        public string OcuProductType { get; set; }
        [StringLength(50)]
        public string CatModelCode { get; set; }
        [StringLength(50)]
        public string ModelName { get; set; }
        [StringLength(50)]
        public string SizeCode { get; set; }
        [StringLength(50)]
        public string BridgeSize { get; set; }
        [StringLength(50)]
        public string TempleSize { get; set; }
        [Column(TypeName = "money")]
        public decimal? CostPrice { get; set; }
        [Column("Cost_Price2", TypeName = "money")]
        public decimal? CostPrice2 { get; set; }
        [Column(TypeName = "money")]
        public decimal? SellingPrice { get; set; }
        [Column(TypeName = "money")]
        public decimal? SellingPrice2 { get; set; }
        [StringLength(50)]
        public string OcuArticleCode { get; set; }
        [StringLength(50)]
        public string ColorCode { get; set; }
        [StringLength(50)]
        public string ColorName { get; set; }
        [StringLength(50)]
        public string CatColorFamily { get; set; }
        [Column("HubColorFamilyID")]
        public int? HubColorFamilyId { get; set; }
        [StringLength(50)]
        public string OcuColorFamily { get; set; }
        [StringLength(50)]
        public string CatGenderCode { get; set; }
        [StringLength(50)]
        public string CatGenderDesc { get; set; }
        public int? HubGenderId { get; set; }
        [StringLength(50)]
        public string OcuGender { get; set; }
        [StringLength(50)]
        public string CatUserGroupCode { get; set; }
        [StringLength(50)]
        public string CatUserGroupDesc { get; set; }
        [Column("HubUserGroupID")]
        public int? HubUserGroupId { get; set; }
        [StringLength(50)]
        public string OcuUserGroupName { get; set; }
        [StringLength(50)]
        public string CatFrameMaterialCode { get; set; }
        [StringLength(50)]
        public string CatFrameMaterialDesc { get; set; }
        [Column("HubFrameMaterialID")]
        public int? HubFrameMaterialId { get; set; }
        [StringLength(50)]
        public string OcuFrameMaterialName { get; set; }
        [StringLength(50)]
        public string CatRimTypeCode { get; set; }
        [StringLength(50)]
        public string CatRimTypeDesc { get; set; }
        [Column("HubRimTypeID")]
        public int? HubRimTypeId { get; set; }
        [StringLength(50)]
        public string OcuRimTypeName { get; set; }
        [StringLength(50)]
        public string CatShapeCode { get; set; }
        [StringLength(50)]
        public string CatShapeDesc { get; set; }
        [Column("HubShapeID")]
        public int? HubShapeId { get; set; }
        [StringLength(50)]
        public string OcuShapeName { get; set; }
        [StringLength(50)]
        public string CatCollectionCode { get; set; }
        [StringLength(50)]
        public string CatCollectionName { get; set; }
        public int? HubCollectionId { get; set; }
        [StringLength(50)]
        public string OcuCollectionName { get; set; }
        [StringLength(50)]
        public string LensMaterialCode { get; set; }
        [StringLength(50)]
        public string LensMaterialName { get; set; }
        [StringLength(50)]
        public string LensColor { get; set; }
        [StringLength(50)]
        public string TempleMaterialCode { get; set; }
        [StringLength(50)]
        public string TempleMaterialName { get; set; }
        [StringLength(50)]
        public string TempleColorCode { get; set; }
        [StringLength(50)]
        public string TempleColorName { get; set; }
        [StringLength(50)]
        public string MeasureA { get; set; }
        [StringLength(50)]
        public string MeasureB { get; set; }
        [Column("MeasureED")]
        [StringLength(50)]
        public string MeasureEd { get; set; }
        [Column("FrameDBL")]
        [StringLength(50)]
        public string FrameDbl { get; set; }
        [StringLength(50)]
        public string SunglassesFilter { get; set; }
        [StringLength(50)]
        public string Warehouse { get; set; }

        [ForeignKey("CatalogueId")]
        [InverseProperty("Product")]
        public Catalogue Catalogue { get; set; }
        [ForeignKey("HubBrandId")]
        [InverseProperty("Product")]
        public HubBrand HubBrand { get; set; }
        [ForeignKey("HubColorFamilyId")]
        [InverseProperty("Product")]
        public HubColorFamily HubColorFamily { get; set; }
        [ForeignKey("HubFrameMaterialId")]
        [InverseProperty("Product")]
        public HubFrameMaterial HubFrameMaterial { get; set; }
        [ForeignKey("HubGenderId")]
        [InverseProperty("Product")]
        public HubGender HubGender { get; set; }
        [ForeignKey("HubRimTypeId")]
        [InverseProperty("Product")]
        public HubRimType HubRimType { get; set; }
        [ForeignKey("HubShapeId")]
        [InverseProperty("Product")]
        public HubShape HubShape { get; set; }
        [ForeignKey("HubUserGroupId")]
        [InverseProperty("Product")]
        public HubUserGroup HubUserGroup { get; set; }
    }
}
