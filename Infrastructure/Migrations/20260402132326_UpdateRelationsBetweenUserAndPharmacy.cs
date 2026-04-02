using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationsBetweenUserAndPharmacy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop FK first, because MySQL requires the index to be dropped before recreating it
            migrationBuilder.DropForeignKey(
                name: "FK_pharmacies_users_id_admin",
                table: "pharmacies");

            migrationBuilder.DropIndex(
                name: "IX_pharmacies_id_admin",
                table: "pharmacies");

            // Recreate index without unique constraint
            migrationBuilder.CreateIndex(
                name: "IX_pharmacies_id_admin",
                table: "pharmacies",
                column: "id_admin");

            // Restore the FK
            migrationBuilder.AddForeignKey(
                name: "FK_pharmacies_users_id_admin",
                table: "pharmacies",
                column: "id_admin",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pharmacies_users_id_admin",
                table: "pharmacies");

            migrationBuilder.DropIndex(
                name: "IX_pharmacies_id_admin",
                table: "pharmacies");

            migrationBuilder.CreateIndex(
                name: "IX_pharmacies_id_admin",
                table: "pharmacies",
                column: "id_admin",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_pharmacies_users_id_admin",
                table: "pharmacies",
                column: "id_admin",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
