using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinqTasks.Migrations
{
    /// <inheritdoc />
    public partial class ResultToProgrammingTaskAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "ProgrammingTasks",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "ProgrammingTasks");
        }
    }
}
