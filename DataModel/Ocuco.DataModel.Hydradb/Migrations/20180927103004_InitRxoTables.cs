using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ocuco.DataModel.Hydradb.Migrations
{
    public partial class InitRxoTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RxoDoors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DoorNumber = table.Column<string>(nullable: true),
                    DoorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RxoDoors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RxoWsAuditingTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LuxotticaDoorId = table.Column<int>(nullable: true),
                    DoorNumber = table.Column<string>(nullable: true),
                    EventName = table.Column<string>(nullable: true),
                    EventDescription = table.Column<string>(nullable: true),
                    EventDate = table.Column<DateTime>(nullable: false),
                    EventStatus = table.Column<string>(nullable: true),
                    EventRequest = table.Column<string>(nullable: true),
                    EventResponse = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RxoWsAuditingTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RxoWsAuditingTable_RxoDoors_LuxotticaDoorId",
                        column: x => x.LuxotticaDoorId,
                        principalTable: "RxoDoors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RxoWsAuditingTable_LuxotticaDoorId",
                table: "RxoWsAuditingTable",
                column: "LuxotticaDoorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RxoWsAuditingTable");

            migrationBuilder.DropTable(
                name: "RxoDoors");
        }
    }
}
