using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bioskopi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bioskopi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Glumci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlSlike = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PunoIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biografija = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Glumci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlSlike = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PunoIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biografija = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filmovi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<double>(type: "float", nullable: false),
                    UrlSlike = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumPocetka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumZavrsetka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KategorijaFilma = table.Column<int>(type: "int", nullable: false),
                    BioskopId = table.Column<int>(type: "int", nullable: false),
                    ProducentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmovi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filmovi_Bioskopi_BioskopId",
                        column: x => x.BioskopId,
                        principalTable: "Bioskopi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Filmovi_Producenti_ProducentId",
                        column: x => x.ProducentId,
                        principalTable: "Producenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Glumci_Filmovi",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    GlumacId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Glumci_Filmovi", x => new { x.GlumacId, x.FilmId });
                    table.ForeignKey(
                        name: "FK_Glumci_Filmovi_Filmovi_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Filmovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Glumci_Filmovi_Glumci_GlumacId",
                        column: x => x.GlumacId,
                        principalTable: "Glumci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmovi_BioskopId",
                table: "Filmovi",
                column: "BioskopId");

            migrationBuilder.CreateIndex(
                name: "IX_Filmovi_ProducentId",
                table: "Filmovi",
                column: "ProducentId");

            migrationBuilder.CreateIndex(
                name: "IX_Glumci_Filmovi_FilmId",
                table: "Glumci_Filmovi",
                column: "FilmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Glumci_Filmovi");

            migrationBuilder.DropTable(
                name: "Filmovi");

            migrationBuilder.DropTable(
                name: "Glumci");

            migrationBuilder.DropTable(
                name: "Bioskopi");

            migrationBuilder.DropTable(
                name: "Producenti");
        }
    }
}
