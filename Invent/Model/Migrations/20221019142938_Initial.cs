using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "INVENTORIES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVENTORIES", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LOCATIONS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "VARCHAR(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LOCATION = table.Column<string>(type: "VARCHAR(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IS_REMOTE = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    INVENTORY_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOCATIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LOCATIONS_INVENTORIES_INVENTORY_ID",
                        column: x => x.INVENTORY_ID,
                        principalTable: "INVENTORIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ITEMS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "VARCHAR(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRIPTION = table.Column<string>(type: "VARCHAR(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ADDED_AT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CODE = table.Column<string>(type: "VARCHAR(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IS_MISSING = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ITEM_TYPE = table.Column<int>(type: "int", nullable: false),
                    LOCATION_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITEMS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ITEMS_LOCATIONS_LOCATION_ID",
                        column: x => x.LOCATION_ID,
                        principalTable: "LOCATIONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ITEMS_CODE",
                table: "ITEMS",
                column: "CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ITEMS_LOCATION_ID",
                table: "ITEMS",
                column: "LOCATION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LOCATIONS_INVENTORY_ID",
                table: "LOCATIONS",
                column: "INVENTORY_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ITEMS");

            migrationBuilder.DropTable(
                name: "LOCATIONS");

            migrationBuilder.DropTable(
                name: "INVENTORIES");
        }
    }
}
