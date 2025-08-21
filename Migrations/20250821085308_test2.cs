using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NET24FilmBorrowSystem.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserMovies",
                keyColumn: "Id",
                keyValue: 1,
                column: "BorrowDate",
                value: new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserMovies",
                keyColumn: "Id",
                keyValue: 1,
                column: "BorrowDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
