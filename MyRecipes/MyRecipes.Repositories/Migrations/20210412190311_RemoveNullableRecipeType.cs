using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRecipes.Repositories.Migrations
{
    public partial class RemoveNullableRecipeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_RecipeTypes_RecipeTypeId",
                table: "Recipes");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeTypeId",
                table: "Recipes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_RecipeTypes_RecipeTypeId",
                table: "Recipes",
                column: "RecipeTypeId",
                principalTable: "RecipeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_RecipeTypes_RecipeTypeId",
                table: "Recipes");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeTypeId",
                table: "Recipes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_RecipeTypes_RecipeTypeId",
                table: "Recipes",
                column: "RecipeTypeId",
                principalTable: "RecipeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
