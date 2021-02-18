using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCare.Migrations
{
    public partial class IsOtkazano : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOtkazano",
                table: "PacijentPrijemi",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOtkazano",
                table: "PacijentPrijemi");
        }
    }
}
