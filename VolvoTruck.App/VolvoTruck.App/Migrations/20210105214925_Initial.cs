using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VolvoTruck.App.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caminhoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AnoModelo = table.Column<int>(nullable: false),
                    AnoFabricacao = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Modelo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caminhoes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caminhoes");
        }
    }
}
