using Microsoft.EntityFrameworkCore.Migrations;

namespace LegalSecure.Data.Migrations
{
    public partial class UpdateSolicitorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LatName",
                table: "Solicitor");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Solicitor",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Solicitor");

            migrationBuilder.AddColumn<string>(
                name: "LatName",
                table: "Solicitor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
