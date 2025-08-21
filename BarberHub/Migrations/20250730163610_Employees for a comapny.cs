using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberHub.Migrations
{
    /// <inheritdoc />
    public partial class Employeesforacomapny : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeedCompanyId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployeedCompanyId",
                table: "Users",
                column: "EmployeedCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companies_EmployeedCompanyId",
                table: "Users",
                column: "EmployeedCompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companies_EmployeedCompanyId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_EmployeedCompanyId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmployeedCompanyId",
                table: "Users");
        }
    }
}
