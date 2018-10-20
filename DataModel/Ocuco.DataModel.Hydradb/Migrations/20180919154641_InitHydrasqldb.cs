using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ocuco.DataModel.Hydradb.Migrations
{
    public partial class InitHydrasqldb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    OrderNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    ArtDescription = table.Column<string>(nullable: true),
                    ArtDating = table.Column<string>(nullable: true),
                    ArtId = table.Column<string>(nullable: true),
                    Artist = table.Column<string>(nullable: true),
                    ArtistBirthDate = table.Column<DateTime>(nullable: false),
                    ArtistDeathDate = table.Column<DateTime>(nullable: false),
                    ArtistNationality = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtOrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    OrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtOrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtOrderItem_ArtOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "ArtOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArtOrderItem_ArtProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ArtProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtOrderItem_OrderId",
                table: "ArtOrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtOrderItem_ProductId",
                table: "ArtOrderItem",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtOrderItem");

            migrationBuilder.DropTable(
                name: "ArtOrders");

            migrationBuilder.DropTable(
                name: "ArtProducts");
        }
    }
}
