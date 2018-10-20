using System;
using System.Collections.Generic;

namespace Ocuco.DataModel.Catalog.Entities
{
    public partial class Product
    {
        public int Id { get; set; }
        public int? CatalogueId { get; set; }
        public string Upc { get; set; }
        public string Skucode { get; set; }
        public string ArticleName { get; set; }
        public string CatBrandCode { get; set; }
        public string CatBrandName { get; set; }
        public int? HubBrandId { get; set; }
        public string OcuBrandName { get; set; }
        public string CatProductType { get; set; }
        public string OcuProductType { get; set; }
        public string CatModelCode { get; set; }
        public string ModelName { get; set; }
        public string SizeCode { get; set; }
        public string BridgeSize { get; set; }
        public string TempleSize { get; set; }
        public decimal? CostPrice { get; set; }
        public decimal? CostPrice2 { get; set; }
        public decimal? SellingPrice { get; set; }
        public decimal? SellingPrice2 { get; set; }
        public string OcuArticleCode { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string CatColorFamily { get; set; }
        public int? HubColorFamilyId { get; set; }
        public string OcuColorFamily { get; set; }
        public string CatGenderCode { get; set; }
        public string CatGenderDesc { get; set; }
        public int? HubGenderId { get; set; }
        public string OcuGender { get; set; }
        public string CatUserGroupCode { get; set; }
        public string CatUserGroupDesc { get; set; }
        public int? HubUserGroupId { get; set; }
        public string OcuUserGroupName { get; set; }
        public string CatFrameMaterialCode { get; set; }
        public string CatFrameMaterialDesc { get; set; }
        public int? HubFrameMaterialId { get; set; }
        public string OcuFrameMaterialName { get; set; }
        public string CatRimTypeCode { get; set; }
        public string CatRimTypeDesc { get; set; }
        public int? HubRimTypeId { get; set; }
        public string OcuRimTypeName { get; set; }
        public string CatShapeCode { get; set; }
        public string CatShapeDesc { get; set; }
        public int? HubShapeId { get; set; }
        public string OcuShapeName { get; set; }
        public string CatCollectionCode { get; set; }
        public string CatCollectionName { get; set; }
        public int? HubCollectionId { get; set; }
        public string OcuCollectionName { get; set; }
        public string LensMaterialCode { get; set; }
        public string LensMaterialName { get; set; }
        public string LensColor { get; set; }
        public string TempleMaterialCode { get; set; }
        public string TempleMaterialName { get; set; }
        public string TempleColorCode { get; set; }
        public string TempleColorName { get; set; }
        public string MeasureA { get; set; }
        public string MeasureB { get; set; }
        public string MeasureEd { get; set; }
        public string FrameDbl { get; set; }
        public string SunglassesFilter { get; set; }
        public string Warehouse { get; set; }

        public Catalogue Catalogue { get; set; }
        public HubBrand HubBrand { get; set; }
        public HubColorFamily HubColorFamily { get; set; }
        public HubFrameMaterial HubFrameMaterial { get; set; }
        public HubGender HubGender { get; set; }
        public HubRimType HubRimType { get; set; }
        public HubShape HubShape { get; set; }
        public HubUserGroup HubUserGroup { get; set; }
    }
}
