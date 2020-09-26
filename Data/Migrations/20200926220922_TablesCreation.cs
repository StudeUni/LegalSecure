using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LegalSecure.Data.Migrations
{
    public partial class TablesCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    ContactPhone = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    StreetAddress = table.Column<string>(nullable: false),
                    PostCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rate",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RateStart = table.Column<DateTime>(nullable: false),
                    RateEnd = table.Column<DateTime>(nullable: false),
                    RateAnHour = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rate", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Solicitor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LatName = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    ContactPhone = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: false),
                    StreetAddress = table.Column<string>(nullable: false),
                    PostCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Case",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    ClientID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Case", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Case_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    HoursSpent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CaseID = table.Column<int>(nullable: false),
                    SolicitorID = table.Column<int>(nullable: false),
                    RateID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Activity_Case_CaseID",
                        column: x => x.CaseID,
                        principalTable: "Case",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activity_Rate_RateID",
                        column: x => x.RateID,
                        principalTable: "Rate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activity_Solicitor_SolicitorID",
                        column: x => x.SolicitorID,
                        principalTable: "Solicitor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_CaseID",
                table: "Activity",
                column: "CaseID");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_RateID",
                table: "Activity",
                column: "RateID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activity_SolicitorID",
                table: "Activity",
                column: "SolicitorID");

            migrationBuilder.CreateIndex(
                name: "IX_Case_ClientID",
                table: "Case",
                column: "ClientID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Case");

            migrationBuilder.DropTable(
                name: "Rate");

            migrationBuilder.DropTable(
                name: "Solicitor");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
