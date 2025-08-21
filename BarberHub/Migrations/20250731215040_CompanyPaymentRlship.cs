using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberHub.Migrations
{
    /// <inheritdoc />
    public partial class CompanyPaymentRlship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CompanyId",
                table: "Payment",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Companies_CompanyId",
                table: "Payment",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Companies_CompanyId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_CompanyId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Payment");
        }
    }
}
