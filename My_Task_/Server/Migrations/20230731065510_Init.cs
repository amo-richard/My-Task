using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_Task_.Server.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskItem",
                columns: table => new
                {
                    TaskItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskItemCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskItemParent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskItemStart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskItemEnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskItemStartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskItemEndTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskItemStatus = table.Column<int>(type: "int", nullable: false),
                    NoSubTask = table.Column<bool>(type: "bit", nullable: false),
                    IsCompeted = table.Column<bool>(type: "bit", nullable: false),
                    TaskItemRepeat = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItem", x => x.TaskItemId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskItem");
        }
    }
}
