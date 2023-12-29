using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    public partial class KomentariDodati : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Komentari",
                columns: table => new
                {
                    KomentarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vreme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentari", x => x.KomentarId);
                    table.ForeignKey(
                        name: "FK_Komentari_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Komentari_Filmovi",
                columns: table => new
                {
                    KomentarId = table.Column<int>(type: "int", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentari_Filmovi", x => new { x.KomentarId, x.FilmId });
                    table.ForeignKey(
                        name: "FK_Komentari_Filmovi_Filmovi_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Filmovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Komentari_Filmovi_Komentari_KomentarId",
                        column: x => x.KomentarId,
                        principalTable: "Komentari",
                        principalColumn: "KomentarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Komentari_UserId",
                table: "Komentari",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Komentari_Filmovi_FilmId",
                table: "Komentari_Filmovi",
                column: "FilmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Komentari_Filmovi");

            migrationBuilder.DropTable(
                name: "Komentari");
        }
    }
}
