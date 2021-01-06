using Microsoft.EntityFrameworkCore.Migrations;

namespace VolvoTruck.App.Migrations
{
    public partial class UpdatePlateProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Plate",
                table: "Trucks",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plate",
                table: "Trucks");
        }
    }
}
