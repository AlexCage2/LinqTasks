using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinqTasks.Migrations
{
    /// <inheritdoc />
    public partial class AddLanguagesDatabaseAndDifficultiesDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "ProgrammingTasks");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "ProgrammingTasks");

            migrationBuilder.DropColumn(
                name: "Section",
                table: "ProgrammingTasks");

            migrationBuilder.AddColumn<int>(
                name: "DifficultyId",
                table: "ProgrammingTasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "ProgrammingTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Difficulties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammingTasks_DifficultyId",
                table: "ProgrammingTasks",
                column: "DifficultyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammingTasks_LanguageId",
                table: "ProgrammingTasks",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammingTasks_Difficulties_DifficultyId",
                table: "ProgrammingTasks",
                column: "DifficultyId",
                principalTable: "Difficulties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammingTasks_Languages_LanguageId",
                table: "ProgrammingTasks",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammingTasks_Difficulties_DifficultyId",
                table: "ProgrammingTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammingTasks_Languages_LanguageId",
                table: "ProgrammingTasks");

            migrationBuilder.DropTable(
                name: "Difficulties");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_ProgrammingTasks_DifficultyId",
                table: "ProgrammingTasks");

            migrationBuilder.DropIndex(
                name: "IX_ProgrammingTasks_LanguageId",
                table: "ProgrammingTasks");

            migrationBuilder.DropColumn(
                name: "DifficultyId",
                table: "ProgrammingTasks");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ProgrammingTasks");

            migrationBuilder.AddColumn<string>(
                name: "Difficulty",
                table: "ProgrammingTasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "ProgrammingTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Section",
                table: "ProgrammingTasks",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
