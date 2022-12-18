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
            //migrationBuilder.CreateTable(
            //    name: "ProgrammingTasks",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Difficulty = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Section = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProgrammingTasks", x => x.Id);
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgrammingTasks");
        }
    }
}
