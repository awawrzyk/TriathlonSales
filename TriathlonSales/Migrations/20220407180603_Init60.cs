using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TriathlonSales.Migrations
{
    public partial class Init60 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "docNo",
                table: "CustomerTemporary",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "docNo",
                table: "CustomerTemporary");
        }
    }
}
