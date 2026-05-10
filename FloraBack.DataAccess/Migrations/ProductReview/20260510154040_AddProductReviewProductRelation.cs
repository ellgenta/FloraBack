using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FloraBack.DataAccess.Migrations.ProductReview
{
    /// <inheritdoc />
    public partial class AddProductReviewProductRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ProductId",
                table: "ProductReviews",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviews_Products_ProductId",
                table: "ProductReviews",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviews_Products_ProductId",
                table: "ProductReviews");

            migrationBuilder.DropIndex(
                name: "IX_ProductReviews_ProductId",
                table: "ProductReviews");
        }
    }
}
