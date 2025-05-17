using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ICNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmailVerificationCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    IsEmailVerified = table.Column<bool>(type: "bit", nullable: false),
                    MobileVerificationCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    IsMobileVerified = table.Column<bool>(type: "bit", nullable: false),
                    AcceptedPrivacyPolicy = table.Column<bool>(type: "bit", nullable: false),
                    PolicyAcceptanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pin = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    IsBiometricLoginEnable = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VerificationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
