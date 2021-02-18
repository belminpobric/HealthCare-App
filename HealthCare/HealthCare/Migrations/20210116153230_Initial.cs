using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCare.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ljekari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titula = table.Column<int>(type: "int", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifra = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ljekari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacijenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpolID = table.Column<int>(type: "int", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacijenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacijenti_Spol_SpolID",
                        column: x => x.SpolID,
                        principalTable: "Spol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PacijentPrijemi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumVrijeme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PacijentID = table.Column<int>(type: "int", nullable: false),
                    LjekarID = table.Column<int>(type: "int", nullable: false),
                    IsHitno = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacijentPrijemi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PacijentPrijemi_Ljekari_LjekarID",
                        column: x => x.LjekarID,
                        principalTable: "Ljekari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PacijentPrijemi_Pacijenti_PacijentID",
                        column: x => x.PacijentID,
                        principalTable: "Pacijenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nalazi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NalazOpis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumVrijeme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PacijentPrijemID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nalazi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Nalazi_PacijentPrijemi_PacijentPrijemID",
                        column: x => x.PacijentPrijemID,
                        principalTable: "PacijentPrijemi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nalazi_PacijentPrijemID",
                table: "Nalazi",
                column: "PacijentPrijemID");

            migrationBuilder.CreateIndex(
                name: "IX_Pacijenti_SpolID",
                table: "Pacijenti",
                column: "SpolID");

            migrationBuilder.CreateIndex(
                name: "IX_PacijentPrijemi_LjekarID",
                table: "PacijentPrijemi",
                column: "LjekarID");

            migrationBuilder.CreateIndex(
                name: "IX_PacijentPrijemi_PacijentID",
                table: "PacijentPrijemi",
                column: "PacijentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nalazi");

            migrationBuilder.DropTable(
                name: "PacijentPrijemi");

            migrationBuilder.DropTable(
                name: "Ljekari");

            migrationBuilder.DropTable(
                name: "Pacijenti");

            migrationBuilder.DropTable(
                name: "Spol");
        }
    }
}
