using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NET24FilmBorrowSystem.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "ReleaseYear", "Title" },
                values: new object[] { 1, 2013, "The Conjuring" });

            migrationBuilder.InsertData(
                table: "UserMovies",
                columns: new[] { "Id", "BorrowDate", "FK_MovieId", "FK_UserId", "ReturnDate" },
                values: new object[] { 1, new DateTime(2025, 8, 21, 10, 36, 21, 459, DateTimeKind.Local).AddTicks(8437), 1, 1, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserMovies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
