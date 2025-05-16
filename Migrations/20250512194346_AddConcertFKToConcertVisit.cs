using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncoreTrack.Migrations
{
    /// <inheritdoc />
    public partial class AddConcertFKToConcertVisit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcertDate",
                table: "ConcertVisits");

            migrationBuilder.DropColumn(
                name: "ConcertName",
                table: "ConcertVisits");

            migrationBuilder.DropColumn(
                name: "Venue",
                table: "ConcertVisits");

            migrationBuilder.AddColumn<int>(
                name: "ConcertID",
                table: "ConcertVisits",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Concerts",
                columns: table => new
                {
                    ConcertID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConcertName = table.Column<string>(type: "TEXT", nullable: false),
                    ConcertDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Venue = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concerts", x => x.ConcertID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConcertVisits_ConcertID",
                table: "ConcertVisits",
                column: "ConcertID");

            migrationBuilder.AddForeignKey(
                name: "FK_ConcertVisits_Concerts_ConcertID",
                table: "ConcertVisits",
                column: "ConcertID",
                principalTable: "Concerts",
                principalColumn: "ConcertID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConcertVisits_Concerts_ConcertID",
                table: "ConcertVisits");

            migrationBuilder.DropTable(
                name: "Concerts");

            migrationBuilder.DropIndex(
                name: "IX_ConcertVisits_ConcertID",
                table: "ConcertVisits");

            migrationBuilder.DropColumn(
                name: "ConcertID",
                table: "ConcertVisits");

            migrationBuilder.AddColumn<DateTime>(
                name: "ConcertDate",
                table: "ConcertVisits",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ConcertName",
                table: "ConcertVisits",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Venue",
                table: "ConcertVisits",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
