using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VolvoTruck.App.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trucks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModelYear = table.Column<int>(nullable: false),
                    FabricationYear = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TruckModel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trucks");
        }
    }
}
