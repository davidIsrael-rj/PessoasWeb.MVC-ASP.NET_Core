using Microsoft.EntityFrameworkCore.Migrations;

namespace Pessoas.Migrations
{
    public partial class q : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Pessoas",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pessoas",
                newName: "ID");
        }
    }
}
