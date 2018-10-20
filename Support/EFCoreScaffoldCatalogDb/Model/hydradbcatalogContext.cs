using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCoreScaffoldCatalogDb.Model
{
    public partial class hydradbcatalogContext : DbContext
    {
        public hydradbcatalogContext()
        {
        }

        public hydradbcatalogContext(DbContextOptions<hydradbcatalogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Catalogue> Catalogue { get; set; }
        public virtual DbSet<CatalogueFormat> CatalogueFormat { get; set; }
        public virtual DbSet<CatalogueMappingGroup> CatalogueMappingGroup { get; set; }
        public virtual DbSet<CatalogueProductType> CatalogueProductType { get; set; }
        public virtual DbSet<CatalogueSource> CatalogueSource { get; set; }
        public virtual DbSet<CatalogueSubscription> CatalogueSubscription { get; set; }
        public virtual DbSet<CatalogueTerritory> CatalogueTerritory { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<HubBrand> HubBrand { get; set; }
        public virtual DbSet<HubCollection> HubCollection { get; set; }
        public virtual DbSet<HubColorFamily> HubColorFamily { get; set; }
        public virtual DbSet<HubFrameMaterial> HubFrameMaterial { get; set; }
        public virtual DbSet<HubGender> HubGender { get; set; }
        public virtual DbSet<HubProductType> HubProductType { get; set; }
        public virtual DbSet<HubRimType> HubRimType { get; set; }
        public virtual DbSet<HubShape> HubShape { get; set; }
        public virtual DbSet<HubUserGroup> HubUserGroup { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<MappingBrand> MappingBrand { get; set; }
        public virtual DbSet<MappingColorFamily> MappingColorFamily { get; set; }
        public virtual DbSet<MappingFrameMaterial> MappingFrameMaterial { get; set; }
        public virtual DbSet<MappingGender> MappingGender { get; set; }
        public virtual DbSet<MappingRimType> MappingRimType { get; set; }
        public virtual DbSet<MappingShape> MappingShape { get; set; }
        public virtual DbSet<MappingUserGroup> MappingUserGroup { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductImages> ProductImages { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Territory> Territory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:hydrahubdb.database.windows.net,1433;Initial Catalog=hydradbcatalog;Persist Security Info=False;User ID=ocuco;Password=dept_star!azure1;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catalogue>(entity =>
            {
                entity.HasIndex(e => e.CatalogueName)
                    .HasName("UK_Catalogue_CatalogueName")
                    .IsUnique();

                entity.Property(e => e.CatalogueName).HasMaxLength(50);

                entity.HasOne(d => d.CatalogueFormat)
                    .WithMany(p => p.Catalogue)
                    .HasForeignKey(d => d.CatalogueFormatId)
                    .HasConstraintName("FK_Catalogue_CatalogueFormatId");

                entity.HasOne(d => d.CatalogueMappingGroup)
                    .WithMany(p => p.Catalogue)
                    .HasForeignKey(d => d.CatalogueMappingGroupId)
                    .HasConstraintName("FK_Catalogue_CatalogueMappingGroupId");

                entity.HasOne(d => d.CatalogueProductType)
                    .WithMany(p => p.Catalogue)
                    .HasForeignKey(d => d.CatalogueProductTypeId)
                    .HasConstraintName("FK_Catalogue_CatalogueProductTypeId");

                entity.HasOne(d => d.CatalogueSource)
                    .WithMany(p => p.Catalogue)
                    .HasForeignKey(d => d.CatalogueSourceId)
                    .HasConstraintName("FK_Catalogue_CatalogueSourceId");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Catalogue)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK_Catalogue_ManufacturerId");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Catalogue)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_Catalogue_SupplierId");
            });

            modelBuilder.Entity<CatalogueFormat>(entity =>
            {
                entity.HasIndex(e => e.CatalogueFormatName)
                    .HasName("UK_CatalogueFormat_CatalogueFormatName")
                    .IsUnique();

                entity.Property(e => e.CatalogueFormatName).HasMaxLength(50);
            });

            modelBuilder.Entity<CatalogueMappingGroup>(entity =>
            {
                entity.HasIndex(e => e.CatalogueFormatName)
                    .HasName("UK_CatalogueMappingGroup_CatalogueFormatName")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CatalogueFormatName).HasMaxLength(50);
            });

            modelBuilder.Entity<CatalogueProductType>(entity =>
            {
                entity.HasIndex(e => e.CatalogueProductTypeName)
                    .HasName("UK_CatalogueProductType_CatalogueProductTypeName")
                    .IsUnique();

                entity.Property(e => e.CatalogueProductTypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<CatalogueSource>(entity =>
            {
                entity.HasIndex(e => e.CatalogSourceName)
                    .HasName("UK_CatalogueSource_CatalogSourceName")
                    .IsUnique();

                entity.Property(e => e.CatalogSourceName).HasMaxLength(50);
            });

            modelBuilder.Entity<CatalogueSubscription>(entity =>
            {
                entity.HasIndex(e => e.CatalogueId)
                    .HasName("fkIdx_CatalogueSubscription_CatalogueId");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("fkIdx_CatalogueSubscription_CustomerId");

                entity.Property(e => e.SubscriptionName).HasMaxLength(50);

                entity.HasOne(d => d.Catalogue)
                    .WithMany(p => p.CatalogueSubscription)
                    .HasForeignKey(d => d.CatalogueId)
                    .HasConstraintName("FK_Catalogue_CatalogueSubscription");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CatalogueSubscription)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Customer_CatalogueSubscription");
            });

            modelBuilder.Entity<CatalogueTerritory>(entity =>
            {
                entity.HasIndex(e => e.CatalogueId)
                    .HasName("fkIdx_CatalogueTerritory_CatalogueId");

                entity.HasIndex(e => e.TerritoryId)
                    .HasName("fkIdx_CatalogueTerritory_TerritoryId");

                entity.HasOne(d => d.Catalogue)
                    .WithMany(p => p.CatalogueTerritory)
                    .HasForeignKey(d => d.CatalogueId)
                    .HasConstraintName("FK_Catalogue_CatalogueTerritory");

                entity.HasOne(d => d.Territory)
                    .WithMany(p => p.CatalogueTerritory)
                    .HasForeignKey(d => d.TerritoryId)
                    .HasConstraintName("FK_Territory_CatalogueTerritory");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.CustomerName)
                    .HasName("UK_Customer_CustomerName")
                    .IsUnique();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(50);

                entity.Property(e => e.CustomerName).HasMaxLength(50);
            });

            modelBuilder.Entity<HubBrand>(entity =>
            {
                entity.HasIndex(e => e.ManufacturerId)
                    .HasName("fkIdx_HubBrand_ManufacturerId");

                entity.Property(e => e.OcuBrandCode).HasMaxLength(50);

                entity.Property(e => e.OcuBrandName).HasMaxLength(50);

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.HubBrand)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK_Manufacturer_HubBrand");
            });

            modelBuilder.Entity<HubCollection>(entity =>
            {
                entity.Property(e => e.OcuCollectionCode).HasMaxLength(50);

                entity.Property(e => e.OcuCollectionName).HasMaxLength(50);
            });

            modelBuilder.Entity<HubColorFamily>(entity =>
            {
                entity.Property(e => e.OcuColorFamily).HasMaxLength(50);
            });

            modelBuilder.Entity<HubFrameMaterial>(entity =>
            {
                entity.Property(e => e.OcuFrameMaterialCode).HasMaxLength(50);

                entity.Property(e => e.OcuFrameMaterialName).HasMaxLength(50);
            });

            modelBuilder.Entity<HubGender>(entity =>
            {
                entity.Property(e => e.OcuGenderCode).HasMaxLength(50);

                entity.Property(e => e.OcuGenderName).HasMaxLength(50);
            });

            modelBuilder.Entity<HubProductType>(entity =>
            {
                entity.Property(e => e.OcuProductType).HasMaxLength(50);
            });

            modelBuilder.Entity<HubRimType>(entity =>
            {
                entity.Property(e => e.OcuRimTypeCode).HasMaxLength(50);

                entity.Property(e => e.OcuRimTypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<HubShape>(entity =>
            {
                entity.Property(e => e.OcuShapeCode).HasMaxLength(50);

                entity.Property(e => e.OcuShapeName).HasMaxLength(50);
            });

            modelBuilder.Entity<HubUserGroup>(entity =>
            {
                entity.Property(e => e.OcuUserGroupCode).HasMaxLength(50);

                entity.Property(e => e.OcuUserGroupName).HasMaxLength(50);
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.HasIndex(e => e.ManufacturerName)
                    .HasName("UK_Manufacturer_ManufacturerName")
                    .IsUnique();

                entity.Property(e => e.ManufacturerName).HasMaxLength(50);
            });

            modelBuilder.Entity<MappingBrand>(entity =>
            {
                entity.HasIndex(e => e.CatalogueId)
                    .HasName("fkIdx_MappingBrand_CatalogueId");

                entity.HasIndex(e => e.HubBrandId)
                    .HasName("fkIdx_MappingBrand_HubBrandId");

                entity.Property(e => e.CatBrandCode).HasMaxLength(50);

                entity.Property(e => e.CatBrandName).HasMaxLength(50);

                entity.HasOne(d => d.Catalogue)
                    .WithMany(p => p.MappingBrand)
                    .HasForeignKey(d => d.CatalogueId)
                    .HasConstraintName("FK_Catalogue_MappingBrand");

                entity.HasOne(d => d.HubBrand)
                    .WithMany(p => p.MappingBrand)
                    .HasForeignKey(d => d.HubBrandId)
                    .HasConstraintName("FK_HubBrand_MappingBrand");
            });

            modelBuilder.Entity<MappingColorFamily>(entity =>
            {
                entity.HasIndex(e => e.CatalogueMappingGroupId)
                    .HasName("fkIdx_MappingColorFamily_CatalogueMappingGroupID");

                entity.HasIndex(e => e.HubColorFamilyId)
                    .HasName("fkIdx_MappingColorFamily_HubColorFamilyId");

                entity.Property(e => e.CatColorFamily).HasMaxLength(50);

                entity.Property(e => e.CatalogueMappingGroupId).HasColumnName("CatalogueMappingGroupID");

                entity.HasOne(d => d.CatalogueMappingGroup)
                    .WithMany(p => p.MappingColorFamily)
                    .HasForeignKey(d => d.CatalogueMappingGroupId)
                    .HasConstraintName("FK_CatalogueMappingGroup_MappingColorFamily");

                entity.HasOne(d => d.HubColorFamily)
                    .WithMany(p => p.MappingColorFamily)
                    .HasForeignKey(d => d.HubColorFamilyId)
                    .HasConstraintName("FK_HubColorFamily_MappingColorFamily");
            });

            modelBuilder.Entity<MappingFrameMaterial>(entity =>
            {
                entity.HasIndex(e => e.CatalogueMappingGroupId)
                    .HasName("fkIdx_MappingFrameMaterial_CatalogueMappingGroupId");

                entity.HasIndex(e => e.HubFrameMaterialId)
                    .HasName("fkIdx_MappingFrameMaterial_HubFrameMaterialId");

                entity.Property(e => e.CatFrameMaterialCode).HasMaxLength(50);

                entity.Property(e => e.CatFrameMaterialDesc).HasMaxLength(50);

                entity.HasOne(d => d.CatalogueMappingGroup)
                    .WithMany(p => p.MappingFrameMaterial)
                    .HasForeignKey(d => d.CatalogueMappingGroupId)
                    .HasConstraintName("FK_CatalogueMappingGroup_MappingFrameMaterial");

                entity.HasOne(d => d.HubFrameMaterial)
                    .WithMany(p => p.MappingFrameMaterial)
                    .HasForeignKey(d => d.HubFrameMaterialId)
                    .HasConstraintName("FK_HubFrameMaterial_MappingFrameMaterial");
            });

            modelBuilder.Entity<MappingGender>(entity =>
            {
                entity.HasIndex(e => e.CatalogueMappingGroupId)
                    .HasName("fkIdx_MappingGender_CatalogueMappingGroupID");

                entity.HasIndex(e => e.HubGenderId)
                    .HasName("fkIdx_MappingGender_HubGenderId");

                entity.Property(e => e.CatGenderCode).HasMaxLength(50);

                entity.Property(e => e.CatGenderDesc).HasMaxLength(50);

                entity.Property(e => e.CatalogueMappingGroupId).HasColumnName("CatalogueMappingGroupID");

                entity.HasOne(d => d.CatalogueMappingGroup)
                    .WithMany(p => p.MappingGender)
                    .HasForeignKey(d => d.CatalogueMappingGroupId)
                    .HasConstraintName("FK_CatalogueMappingGroup_MappingGender");

                entity.HasOne(d => d.HubGender)
                    .WithMany(p => p.MappingGender)
                    .HasForeignKey(d => d.HubGenderId)
                    .HasConstraintName("FK_HubGender_MappingGender");
            });

            modelBuilder.Entity<MappingRimType>(entity =>
            {
                entity.HasIndex(e => e.CatalogueMappingGroupId)
                    .HasName("fkIdx_MappingRimType_CatalogueMappingGroupID");

                entity.HasIndex(e => e.HubRimTypeId)
                    .HasName("fkIdx_MappingRimType_HubRimTypeId");

                entity.Property(e => e.CatRimTypeCode).HasMaxLength(50);

                entity.Property(e => e.CatRimTypeDesc).HasMaxLength(50);

                entity.Property(e => e.CatalogueMappingGroupId).HasColumnName("CatalogueMappingGroupID");

                entity.HasOne(d => d.CatalogueMappingGroup)
                    .WithMany(p => p.MappingRimType)
                    .HasForeignKey(d => d.CatalogueMappingGroupId)
                    .HasConstraintName("FK_CatalogueMappingGroup_MappingRimType");

                entity.HasOne(d => d.HubRimType)
                    .WithMany(p => p.MappingRimType)
                    .HasForeignKey(d => d.HubRimTypeId)
                    .HasConstraintName("FK_HubRimType_MappingRimType");
            });

            modelBuilder.Entity<MappingShape>(entity =>
            {
                entity.HasIndex(e => e.CatalogueMappingGroupId)
                    .HasName("fkIdx_MappingShape_CatalogueMappingGroupID");

                entity.HasIndex(e => e.HubShapeId)
                    .HasName("fkIdx_MappingShape_HubShapeId");

                entity.Property(e => e.CatShapeCode).HasMaxLength(50);

                entity.Property(e => e.CatShapeDesc).HasMaxLength(50);

                entity.Property(e => e.CatalogueMappingGroupId).HasColumnName("CatalogueMappingGroupID");

                entity.HasOne(d => d.CatalogueMappingGroup)
                    .WithMany(p => p.MappingShape)
                    .HasForeignKey(d => d.CatalogueMappingGroupId)
                    .HasConstraintName("FK_CatalogueMappingGroup_MappingShape");

                entity.HasOne(d => d.HubShape)
                    .WithMany(p => p.MappingShape)
                    .HasForeignKey(d => d.HubShapeId)
                    .HasConstraintName("FK_HubShape_MappingShape");
            });

            modelBuilder.Entity<MappingUserGroup>(entity =>
            {
                entity.HasIndex(e => e.CatalogueMappingGroupId)
                    .HasName("fkIdx_MappingUserGroup_CatalogueMappingGroupID");

                entity.HasIndex(e => e.HubUserGroupId)
                    .HasName("fkIdx_MappingUserGroup_HubUserGroupId");

                entity.Property(e => e.CatUserGroupCode).HasMaxLength(50);

                entity.Property(e => e.CatUserGroupDesc).HasMaxLength(50);

                entity.Property(e => e.CatalogueMappingGroupId).HasColumnName("CatalogueMappingGroupID");

                entity.HasOne(d => d.CatalogueMappingGroup)
                    .WithMany(p => p.MappingUserGroup)
                    .HasForeignKey(d => d.CatalogueMappingGroupId)
                    .HasConstraintName("FK_CatalogueMappingGroup_MappingUserGroup");

                entity.HasOne(d => d.HubUserGroup)
                    .WithMany(p => p.MappingUserGroup)
                    .HasForeignKey(d => d.HubUserGroupId)
                    .HasConstraintName("FK_HubUserGroup_MappingUserGroup");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.CatalogueId)
                    .HasName("fkIdx_Product_CatalogueId");

                entity.HasIndex(e => e.HubBrandId)
                    .HasName("fkIdx_Product_HubBrandId");

                entity.HasIndex(e => e.HubColorFamilyId)
                    .HasName("fkIdx_Product_HubColorFamilyID");

                entity.HasIndex(e => e.HubFrameMaterialId)
                    .HasName("fkIdx_Product_HubFrameMaterialID");

                entity.HasIndex(e => e.HubGenderId)
                    .HasName("fkIdx_Product_HubGenderId");

                entity.HasIndex(e => e.HubRimTypeId)
                    .HasName("fkIdx_Product_HubRimTypeID");

                entity.HasIndex(e => e.HubShapeId)
                    .HasName("fkIdx_Product_HubShapeID");

                entity.HasIndex(e => e.HubUserGroupId)
                    .HasName("fkIdx_Product_HubUserGroupID");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ArticleName).HasMaxLength(50);

                entity.Property(e => e.BridgeSize).HasMaxLength(50);

                entity.Property(e => e.CatBrandCode).HasMaxLength(50);

                entity.Property(e => e.CatBrandName).HasMaxLength(50);

                entity.Property(e => e.CatCollectionCode).HasMaxLength(50);

                entity.Property(e => e.CatCollectionName).HasMaxLength(50);

                entity.Property(e => e.CatColorFamily).HasMaxLength(50);

                entity.Property(e => e.CatFrameMaterialCode).HasMaxLength(50);

                entity.Property(e => e.CatFrameMaterialDesc).HasMaxLength(50);

                entity.Property(e => e.CatGenderCode).HasMaxLength(50);

                entity.Property(e => e.CatGenderDesc).HasMaxLength(50);

                entity.Property(e => e.CatModelCode).HasMaxLength(50);

                entity.Property(e => e.CatProductType).HasMaxLength(50);

                entity.Property(e => e.CatRimTypeCode).HasMaxLength(50);

                entity.Property(e => e.CatRimTypeDesc).HasMaxLength(50);

                entity.Property(e => e.CatShapeCode).HasMaxLength(50);

                entity.Property(e => e.CatShapeDesc).HasMaxLength(50);

                entity.Property(e => e.CatUserGroupCode).HasMaxLength(50);

                entity.Property(e => e.CatUserGroupDesc).HasMaxLength(50);

                entity.Property(e => e.ColorCode).HasMaxLength(50);

                entity.Property(e => e.ColorName).HasMaxLength(50);

                entity.Property(e => e.CostPrice).HasColumnType("money");

                entity.Property(e => e.CostPrice2)
                    .HasColumnName("Cost_Price2")
                    .HasColumnType("money");

                entity.Property(e => e.FrameDbl)
                    .HasColumnName("FrameDBL")
                    .HasMaxLength(50);

                entity.Property(e => e.HubColorFamilyId).HasColumnName("HubColorFamilyID");

                entity.Property(e => e.HubFrameMaterialId).HasColumnName("HubFrameMaterialID");

                entity.Property(e => e.HubRimTypeId).HasColumnName("HubRimTypeID");

                entity.Property(e => e.HubShapeId).HasColumnName("HubShapeID");

                entity.Property(e => e.HubUserGroupId).HasColumnName("HubUserGroupID");

                entity.Property(e => e.LensColor).HasMaxLength(50);

                entity.Property(e => e.LensMaterialCode).HasMaxLength(50);

                entity.Property(e => e.LensMaterialName).HasMaxLength(50);

                entity.Property(e => e.MeasureA).HasMaxLength(50);

                entity.Property(e => e.MeasureB).HasMaxLength(50);

                entity.Property(e => e.MeasureEd)
                    .HasColumnName("MeasureED")
                    .HasMaxLength(50);

                entity.Property(e => e.ModelName).HasMaxLength(50);

                entity.Property(e => e.OcuArticleCode).HasMaxLength(50);

                entity.Property(e => e.OcuBrandName).HasMaxLength(50);

                entity.Property(e => e.OcuCollectionName).HasMaxLength(50);

                entity.Property(e => e.OcuColorFamily).HasMaxLength(50);

                entity.Property(e => e.OcuFrameMaterialName).HasMaxLength(50);

                entity.Property(e => e.OcuGender).HasMaxLength(50);

                entity.Property(e => e.OcuProductType).HasMaxLength(50);

                entity.Property(e => e.OcuRimTypeName).HasMaxLength(50);

                entity.Property(e => e.OcuShapeName).HasMaxLength(50);

                entity.Property(e => e.OcuUserGroupName).HasMaxLength(50);

                entity.Property(e => e.SellingPrice).HasColumnType("money");

                entity.Property(e => e.SellingPrice2).HasColumnType("money");

                entity.Property(e => e.SizeCode).HasMaxLength(50);

                entity.Property(e => e.Skucode)
                    .HasColumnName("SKUCode")
                    .HasMaxLength(50);

                entity.Property(e => e.SunglassesFilter).HasMaxLength(50);

                entity.Property(e => e.TempleColorCode).HasMaxLength(50);

                entity.Property(e => e.TempleColorName).HasMaxLength(50);

                entity.Property(e => e.TempleMaterialCode).HasMaxLength(50);

                entity.Property(e => e.TempleMaterialName).HasMaxLength(50);

                entity.Property(e => e.TempleSize).HasMaxLength(50);

                entity.Property(e => e.Upc)
                    .HasColumnName("UPC")
                    .HasMaxLength(50);

                entity.Property(e => e.Warehouse).HasMaxLength(50);

                entity.HasOne(d => d.Catalogue)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CatalogueId)
                    .HasConstraintName("FK_Catalogue_Product");

                entity.HasOne(d => d.HubBrand)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.HubBrandId)
                    .HasConstraintName("FK_HubBrand_Product");

                entity.HasOne(d => d.HubColorFamily)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.HubColorFamilyId)
                    .HasConstraintName("FK_HubColorFamily_Product");

                entity.HasOne(d => d.HubFrameMaterial)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.HubFrameMaterialId)
                    .HasConstraintName("FK_HubFrameMaterial_Product");

                entity.HasOne(d => d.HubGender)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.HubGenderId)
                    .HasConstraintName("FK_HubGender_Product");

                entity.HasOne(d => d.HubRimType)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.HubRimTypeId)
                    .HasConstraintName("FK_HubRimType_Product");

                entity.HasOne(d => d.HubShape)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.HubShapeId)
                    .HasConstraintName("FK_HubShape_Product");

                entity.HasOne(d => d.HubUserGroup)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.HubUserGroupId)
                    .HasConstraintName("FK_HubUserGroup_Product");
            });

            modelBuilder.Entity<ProductImages>(entity =>
            {
                entity.HasIndex(e => e.ManufacturerId)
                    .HasName("fkIdx_ProductImages_ManufacturerId");

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("ImageURL")
                    .HasMaxLength(255);

                entity.Property(e => e.OcuProductType).HasMaxLength(50);

                entity.Property(e => e.Upc)
                    .HasColumnName("UPC")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK_Manufacturer_ProductImages");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasIndex(e => e.SupplierName)
                    .HasName("UK_Supplier_SupplierName")
                    .IsUnique();

                entity.Property(e => e.SupplierName).HasMaxLength(50);
            });

            modelBuilder.Entity<Territory>(entity =>
            {
                entity.HasIndex(e => e.TerritoryName)
                    .HasName("UK_Territory_TerritoryName")
                    .IsUnique();

                entity.Property(e => e.TerritoryName).HasMaxLength(50);
            });
        }
    }
}
