using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamPickAppTwo.Migrations
{
    /// <inheritdoc />
    public partial class AddedExtraFieldsToMatchDayTeamPerformanceDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Draws",
                table: "MatchDayTeamPerformanceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoalsScored",
                table: "MatchDayTeamPerformanceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Losses",
                table: "MatchDayTeamPerformanceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Performance",
                table: "MatchDayTeamPerformanceDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Wins",
                table: "MatchDayTeamPerformanceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Draws",
                table: "MatchDayTeamPerformanceDetails");

            migrationBuilder.DropColumn(
                name: "GoalsScored",
                table: "MatchDayTeamPerformanceDetails");

            migrationBuilder.DropColumn(
                name: "Losses",
                table: "MatchDayTeamPerformanceDetails");

            migrationBuilder.DropColumn(
                name: "Performance",
                table: "MatchDayTeamPerformanceDetails");

            migrationBuilder.DropColumn(
                name: "Wins",
                table: "MatchDayTeamPerformanceDetails");
        }
    }
}
