using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamPickAppTwo.Migrations
{
    /// <inheritdoc />
    public partial class AddedExtraTableForMatchDayTeamPerformanceDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MatchDayTeamPerformanceDetailsId",
                table: "MatchDayTeams",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MatchDayTeamPerformanceDetails",
                columns: table => new
                {
                    MatchDayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchDayTeamPerformanceDetails", x => new { x.MatchDayId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_MatchDayTeamPerformanceDetails_MatchDayTeams_MatchDayId_TeamId",
                        columns: x => new { x.MatchDayId, x.TeamId },
                        principalTable: "MatchDayTeams",
                        principalColumns: new[] { "MatchDayId", "TeamId" },
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchDayTeamPerformanceDetails");

            migrationBuilder.DropColumn(
                name: "MatchDayTeamPerformanceDetailsId",
                table: "MatchDayTeams");
        }
    }
}
