using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamPickAppTwo.Migrations
{
    /// <inheritdoc />
    public partial class AddedStructureToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MatchDayId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MatchDays",
                columns: table => new
                {
                    MatchDayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchDayDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfPlayers = table.Column<int>(type: "int", nullable: false),
                    ListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchDays", x => x.MatchDayId);
                    table.ForeignKey(
                        name: "FK_MatchDays_Lists_ListId",
                        column: x => x.ListId,
                        principalTable: "Lists",
                        principalColumn: "ListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchesPlayed = table.Column<int>(type: "int", nullable: false),
                    NumberOfGoalsScored = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "MatchDayTeams",
                columns: table => new
                {
                    MatchDayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchDayTeams", x => new { x.MatchDayId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_MatchDayTeams_MatchDays_MatchDayId",
                        column: x => x.MatchDayId,
                        principalTable: "MatchDays",
                        principalColumn: "MatchDayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchDayTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTeams",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTeams", x => new { x.UserId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_UserTeams_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MatchDayId",
                table: "AspNetUsers",
                column: "MatchDayId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchDays_ListId",
                table: "MatchDays",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchDayTeams_TeamId",
                table: "MatchDayTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTeams_TeamId",
                table: "UserTeams",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_MatchDays_MatchDayId",
                table: "AspNetUsers",
                column: "MatchDayId",
                principalTable: "MatchDays",
                principalColumn: "MatchDayId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_MatchDays_MatchDayId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "MatchDayTeams");

            migrationBuilder.DropTable(
                name: "UserTeams");

            migrationBuilder.DropTable(
                name: "MatchDays");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MatchDayId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MatchDayId",
                table: "AspNetUsers");
        }
    }
}
