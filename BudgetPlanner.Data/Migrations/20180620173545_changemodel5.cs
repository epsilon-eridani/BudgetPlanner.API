using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetPlanner.Data.Migrations
{
    public partial class changemodel5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ParentCategories_ParentCategoryId",
                table: "Items");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Items",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ParentCategories_ParentCategoryId",
                table: "Items",
                column: "ParentCategoryId",
                principalTable: "ParentCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ParentCategories_ParentCategoryId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Items");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ParentCategories_ParentCategoryId",
                table: "Items",
                column: "ParentCategoryId",
                principalTable: "ParentCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
