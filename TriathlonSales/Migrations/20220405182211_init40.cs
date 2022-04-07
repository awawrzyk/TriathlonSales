using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TriathlonSales.Migrations
{
    public partial class init40 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesOrdersPositions");

            migrationBuilder.CreateTable(
                name: "CustomerTemporary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTemporary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrdersItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    docNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    posId = table.Column<int>(type: "int", nullable: false),
                    posName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrdersItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerTemporary");

            migrationBuilder.DropTable(
                name: "SalesOrdersItems");

            migrationBuilder.CreateTable(
                name: "SalesOrdersPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    docNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    posId = table.Column<int>(type: "int", nullable: false),
                    posName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrdersPositions", x => x.Id);
                });
        }
    }
}
