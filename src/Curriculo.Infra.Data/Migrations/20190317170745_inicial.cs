using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Curriculo.Infra.Data.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    DeleteAt = table.Column<DateTime>(nullable: true),
                    DeleteBy = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    DeleteAt = table.Column<DateTime>(nullable: true),
                    DeleteBy = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    Description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    ProductTypeId = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Price = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductTypes");
        }
    }
}
