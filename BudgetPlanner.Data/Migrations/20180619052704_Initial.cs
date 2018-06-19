using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetPlanner.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParentCategories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CustomCategories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ParentCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomCategories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomCategories_ParentCategories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "ParentCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    IsExpense = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    CustomCategoryId = table.Column<int>(nullable: false),
                    ParentCategoryId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Items_CustomCategories_CustomCategoryId",
                        column: x => x.CustomCategoryId,
                        principalTable: "CustomCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_ParentCategories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "ParentCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomCategories_ParentCategoryId",
                table: "CustomCategories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CustomCategoryId",
                table: "Items",
                column: "CustomCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ParentCategoryId",
                table: "Items",
                column: "ParentCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "CustomCategories");

            migrationBuilder.DropTable(
                name: "ParentCategories");
        }
    }
}
