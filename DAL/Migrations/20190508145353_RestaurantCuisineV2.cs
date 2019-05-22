using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class RestaurantCuisineV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantCuisine_Cuisine_CuisineId",
                table: "RestaurantCuisine");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantCuisine_Restaurants_RestaurantId",
                table: "RestaurantCuisine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantCuisine",
                table: "RestaurantCuisine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cuisine",
                table: "Cuisine");

            migrationBuilder.RenameTable(
                name: "RestaurantCuisine",
                newName: "RestaurantCuisines");

            migrationBuilder.RenameTable(
                name: "Cuisine",
                newName: "Cuisines");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantCuisine_CuisineId",
                table: "RestaurantCuisines",
                newName: "IX_RestaurantCuisines_CuisineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantCuisines",
                table: "RestaurantCuisines",
                columns: new[] { "RestaurantId", "CuisineId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cuisines",
                table: "Cuisines",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantCuisines_Cuisines_CuisineId",
                table: "RestaurantCuisines",
                column: "CuisineId",
                principalTable: "Cuisines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantCuisines_Restaurants_RestaurantId",
                table: "RestaurantCuisines",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantCuisines_Cuisines_CuisineId",
                table: "RestaurantCuisines");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantCuisines_Restaurants_RestaurantId",
                table: "RestaurantCuisines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantCuisines",
                table: "RestaurantCuisines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cuisines",
                table: "Cuisines");

            migrationBuilder.RenameTable(
                name: "RestaurantCuisines",
                newName: "RestaurantCuisine");

            migrationBuilder.RenameTable(
                name: "Cuisines",
                newName: "Cuisine");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantCuisines_CuisineId",
                table: "RestaurantCuisine",
                newName: "IX_RestaurantCuisine_CuisineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantCuisine",
                table: "RestaurantCuisine",
                columns: new[] { "RestaurantId", "CuisineId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cuisine",
                table: "Cuisine",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantCuisine_Cuisine_CuisineId",
                table: "RestaurantCuisine",
                column: "CuisineId",
                principalTable: "Cuisine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantCuisine_Restaurants_RestaurantId",
                table: "RestaurantCuisine",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
