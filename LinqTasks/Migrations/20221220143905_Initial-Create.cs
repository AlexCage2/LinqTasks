using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinqTasks.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "ProgrammingTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    DifficultyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgrammingTasks_Difficulties_DifficultyId",
                        column: x => x.DifficultyId,
                        principalTable: "Difficulties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgrammingTasks_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammingTasks_DifficultyId",
                table: "ProgrammingTasks",
                column: "DifficultyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammingTasks_LanguageId",
                table: "ProgrammingTasks",
                column: "LanguageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgrammingTasks");

            migrationBuilder.DropTable(
                name: "Difficulties");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
