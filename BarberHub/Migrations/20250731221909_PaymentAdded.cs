using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberHub.Migrations
{
    /// <inheritdoc />
    public partial class PaymentAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Companies_CompanyId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Users_UserId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDetail_Payment_PaymentId",
                table: "PaymentDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDetail_Portfolios_PortfolioId",
                table: "PaymentDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDetail_ProvidedServices_ServiceId",
                table: "PaymentDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentDetail",
                table: "PaymentDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                table: "Payment");

            migrationBuilder.RenameTable(
                name: "PaymentDetail",
                newName: "paymentDetails");

            migrationBuilder.RenameTable(
                name: "Payment",
                newName: "Payments");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentDetail_ServiceId",
                table: "paymentDetails",
                newName: "IX_paymentDetails_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentDetail_PortfolioId",
                table: "paymentDetails",
                newName: "IX_paymentDetails_PortfolioId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentDetail_PaymentId",
                table: "paymentDetails",
                newName: "IX_paymentDetails_PaymentId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_UserId",
                table: "Payments",
                newName: "IX_Payments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_CompanyId",
                table: "Payments",
                newName: "IX_Payments_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_paymentDetails",
                table: "paymentDetails",
                column: "PaymentDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_paymentDetails_Payments_PaymentId",
                table: "paymentDetails",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "PaymentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_paymentDetails_Portfolios_PortfolioId",
                table: "paymentDetails",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "PortfolioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_paymentDetails_ProvidedServices_ServiceId",
                table: "paymentDetails",
                column: "ServiceId",
                principalTable: "ProvidedServices",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Companies_CompanyId",
                table: "Payments",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_UserId",
                table: "Payments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_paymentDetails_Payments_PaymentId",
                table: "paymentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_paymentDetails_Portfolios_PortfolioId",
                table: "paymentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_paymentDetails_ProvidedServices_ServiceId",
                table: "paymentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Companies_CompanyId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_UserId",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_paymentDetails",
                table: "paymentDetails");

            migrationBuilder.RenameTable(
                name: "Payments",
                newName: "Payment");

            migrationBuilder.RenameTable(
                name: "paymentDetails",
                newName: "PaymentDetail");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_UserId",
                table: "Payment",
                newName: "IX_Payment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_CompanyId",
                table: "Payment",
                newName: "IX_Payment_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_paymentDetails_ServiceId",
                table: "PaymentDetail",
                newName: "IX_PaymentDetail_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_paymentDetails_PortfolioId",
                table: "PaymentDetail",
                newName: "IX_PaymentDetail_PortfolioId");

            migrationBuilder.RenameIndex(
                name: "IX_paymentDetails_PaymentId",
                table: "PaymentDetail",
                newName: "IX_PaymentDetail_PaymentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                table: "Payment",
                column: "PaymentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentDetail",
                table: "PaymentDetail",
                column: "PaymentDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Companies_CompanyId",
                table: "Payment",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Users_UserId",
                table: "Payment",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDetail_Payment_PaymentId",
                table: "PaymentDetail",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "PaymentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDetail_Portfolios_PortfolioId",
                table: "PaymentDetail",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "PortfolioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDetail_ProvidedServices_ServiceId",
                table: "PaymentDetail",
                column: "ServiceId",
                principalTable: "ProvidedServices",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
