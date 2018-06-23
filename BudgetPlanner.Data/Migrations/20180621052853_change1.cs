using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetPlanner.Data.Migrations
{
    public partial class change1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_CustomCategories_CustomCategoryId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "CustomCategoryId",
                table: "Items",
                newName: "CustomCategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Items_CustomCategoryId",
                table: "Items",
                newName: "IX_Items_CustomCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_CustomCategories_CustomCategoryID",
                table: "Items",
                column: "CustomCategoryID",
                principalTable: "CustomCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_CustomCategories_CustomCategoryID",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "CustomCategoryID",
                table: "Items",
                newName: "CustomCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_CustomCategoryID",
                table: "Items",
                newName: "IX_Items_CustomCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_CustomCategories_CustomCategoryId",
                table: "Items",
                column: "CustomCategoryId",
                principalTable: "CustomCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
