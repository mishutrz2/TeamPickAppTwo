using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamPickAppTwo.Migrations
{
    /// <inheritdoc />
    public partial class CompletedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_MatchDays_MatchDayId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MatchDayId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MatchDayId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "MatchDayPlayers",
                columns: table => new
                {
                    MatchDaysMatchDayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchDayPlayers", x => new { x.MatchDaysMatchDayId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_MatchDayPlayers_AspNetUsers_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchDayPlayers_MatchDays_MatchDaysMatchDayId",
                        column: x => x.MatchDaysMatchDayId,
                        principalTable: "MatchDays",
                        principalColumn: "MatchDayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchDayPlayers_PlayersId",
                table: "MatchDayPlayers",
                column: "PlayersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchDayPlayers");

            migrationBuilder.AddColumn<Guid>(
                name: "MatchDayId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MatchDayId",
                table: "AspNetUsers",
                column: "MatchDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_MatchDays_MatchDayId",
                table: "AspNetUsers",
                column: "MatchDayId",
                principalTable: "MatchDays",
                principalColumn: "MatchDayId");
        }
    }
}
