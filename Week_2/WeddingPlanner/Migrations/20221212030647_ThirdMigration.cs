using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingPlanner.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeddingAssociation_Users_UserId",
                table: "WeddingAssociation");

            migrationBuilder.DropForeignKey(
                name: "FK_WeddingAssociation_Weddings_WeddingId",
                table: "WeddingAssociation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeddingAssociation",
                table: "WeddingAssociation");

            migrationBuilder.RenameTable(
                name: "WeddingAssociation",
                newName: "WeddingAssociations");

            migrationBuilder.RenameIndex(
                name: "IX_WeddingAssociation_WeddingId",
                table: "WeddingAssociations",
                newName: "IX_WeddingAssociations_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_WeddingAssociation_UserId",
                table: "WeddingAssociations",
                newName: "IX_WeddingAssociations_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeddingAssociations",
                table: "WeddingAssociations",
                column: "WeddingAssociationId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeddingAssociations_Users_UserId",
                table: "WeddingAssociations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeddingAssociations_Weddings_WeddingId",
                table: "WeddingAssociations",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "WeddingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeddingAssociations_Users_UserId",
                table: "WeddingAssociations");

            migrationBuilder.DropForeignKey(
                name: "FK_WeddingAssociations_Weddings_WeddingId",
                table: "WeddingAssociations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeddingAssociations",
                table: "WeddingAssociations");

            migrationBuilder.RenameTable(
                name: "WeddingAssociations",
                newName: "WeddingAssociation");

            migrationBuilder.RenameIndex(
                name: "IX_WeddingAssociations_WeddingId",
                table: "WeddingAssociation",
                newName: "IX_WeddingAssociation_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_WeddingAssociations_UserId",
                table: "WeddingAssociation",
                newName: "IX_WeddingAssociation_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeddingAssociation",
                table: "WeddingAssociation",
                column: "WeddingAssociationId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeddingAssociation_Users_UserId",
                table: "WeddingAssociation",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeddingAssociation_Weddings_WeddingId",
                table: "WeddingAssociation",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "WeddingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
