using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotDesks.Migrations
{
    /// <inheritdoc />
    public partial class ChangedIsCancelledPropertySpelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isCancelled",
                table: "Reservations",
                newName: "IsCancelled");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsCancelled",
                table: "Reservations",
                newName: "isCancelled");
        }
    }
}
