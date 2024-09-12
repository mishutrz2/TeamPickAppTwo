using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamPickAppTwo.Migrations
{
    /// <inheritdoc />
    public partial class AddedPasswordDatapointToList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Lists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Lists");
        }
    }
}
