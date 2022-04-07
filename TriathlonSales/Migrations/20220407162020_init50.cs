using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TriathlonSales.Migrations
{
    public partial class init50 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "CustomerTemporary");

            migrationBuilder.AddColumn<int>(
                name: "customerId",
                table: "CustomerTemporary",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "customerId",
                table: "CustomerTemporary");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CustomerTemporary",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
