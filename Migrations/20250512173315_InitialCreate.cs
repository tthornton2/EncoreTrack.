using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncoreTrack.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AudienceMembers",
                columns: table => new
                {
                    AudienceMemberID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    FirstVisitDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudienceMembers", x => x.AudienceMemberID);
                });

            migrationBuilder.CreateTable(
                name: "ConcertVisits",
                columns: table => new
                {
                    ConcertVisitID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConcertName = table.Column<string>(type: "TEXT", nullable: false),
                    ConcertDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Venue = table.Column<string>(type: "TEXT", nullable: false),
                    AudienceMemberID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcertVisits", x => x.ConcertVisitID);
                    table.ForeignKey(
                        name: "FK_ConcertVisits_AudienceMembers_AudienceMemberID",
                        column: x => x.AudienceMemberID,
                        principalTable: "AudienceMembers",
                        principalColumn: "AudienceMemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConcertVisits_AudienceMemberID",
                table: "ConcertVisits",
                column: "AudienceMemberID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConcertVisits");

            migrationBuilder.DropTable(
                name: "AudienceMembers");
        }
    }
}
