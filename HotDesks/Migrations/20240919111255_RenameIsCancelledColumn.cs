using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotDesks.Migrations
{
    /// <inheritdoc />
    public partial class RenameIsCancelledColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isCanceled",
                table: "Reservations",
                newName: "isCancelled");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isCancelled",
                table: "Reservations",
                newName: "isCanceled");
        }
    }
}
