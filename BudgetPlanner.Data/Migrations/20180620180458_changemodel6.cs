using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetPlanner.Data.Migrations
{
    public partial class changemodel6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CustomCategoryId",
                table: "Items",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CustomCategoryId",
                table: "Items",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
