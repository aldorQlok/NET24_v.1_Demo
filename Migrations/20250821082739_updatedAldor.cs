using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NET24FilmBorrowSystem.Migrations
{
    /// <inheritdoc />
    public partial class updatedAldor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Aldor_Qlok");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Aldor");
        }
    }
}
