using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NET24FilmBorrowSystem.Migrations
{
    /// <inheritdoc />
    public partial class Add_Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovies_Kunder_FK_UserId",
                table: "UserMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kunder",
                table: "Kunder");

            migrationBuilder.RenameTable(
                name: "Kunder",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "Aldor@gmail.com", "Aldor" },
                    { 2, "Tobias@gmail.com", "Tobias" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovies_Users_FK_UserId",
                table: "UserMovies",
                column: "FK_UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovies_Users_FK_UserId",
                table: "UserMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Kunder");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Kunder",
                newName: "Username");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kunder",
                table: "Kunder",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovies_Kunder_FK_UserId",
                table: "UserMovies",
                column: "FK_UserId",
                principalTable: "Kunder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
