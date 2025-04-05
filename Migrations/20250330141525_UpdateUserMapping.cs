using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EWallet.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_Users_UserID",
                table: "BankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_RecipientUserID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_SenderUserID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleID",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "tblUsers");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "tblUsers",
                newName: "dUpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "tblUsers",
                newName: "sStatus");

            migrationBuilder.RenameColumn(
                name: "RoleID",
                table: "tblUsers",
                newName: "iRoleID_FK");

            migrationBuilder.RenameColumn(
                name: "PinCode",
                table: "tblUsers",
                newName: "sPinCode");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "tblUsers",
                newName: "sPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "tblUsers",
                newName: "sPasswordHash");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "tblUsers",
                newName: "sFullName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "tblUsers",
                newName: "sEmail");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "tblUsers",
                newName: "dCreatedAt");

            migrationBuilder.RenameColumn(
                name: "CCCD",
                table: "tblUsers",
                newName: "sCCCD");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "tblUsers",
                newName: "dBirthDate");

            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "tblUsers",
                newName: "fBalance");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "tblUsers",
                newName: "iUserID_PK");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleID",
                table: "tblUsers",
                newName: "IX_tblUsers_iRoleID_FK");

            migrationBuilder.AlterColumn<decimal>(
                name: "fBalance",
                table: "tblUsers",
                type: "decimal(15,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblUsers",
                table: "tblUsers",
                column: "iUserID_PK");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_tblUsers_UserID",
                table: "BankAccounts",
                column: "UserID",
                principalTable: "tblUsers",
                principalColumn: "iUserID_PK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblUsers_Roles_iRoleID_FK",
                table: "tblUsers",
                column: "iRoleID_FK",
                principalTable: "Roles",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_tblUsers_RecipientUserID",
                table: "Transactions",
                column: "RecipientUserID",
                principalTable: "tblUsers",
                principalColumn: "iUserID_PK");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_tblUsers_SenderUserID",
                table: "Transactions",
                column: "SenderUserID",
                principalTable: "tblUsers",
                principalColumn: "iUserID_PK",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_tblUsers_UserID",
                table: "BankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_tblUsers_Roles_iRoleID_FK",
                table: "tblUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_tblUsers_RecipientUserID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_tblUsers_SenderUserID",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblUsers",
                table: "tblUsers");

            migrationBuilder.RenameTable(
                name: "tblUsers",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "sStatus",
                table: "Users",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "sPinCode",
                table: "Users",
                newName: "PinCode");

            migrationBuilder.RenameColumn(
                name: "sPhoneNumber",
                table: "Users",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "sPasswordHash",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "sFullName",
                table: "Users",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "sEmail",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "sCCCD",
                table: "Users",
                newName: "CCCD");

            migrationBuilder.RenameColumn(
                name: "iRoleID_FK",
                table: "Users",
                newName: "RoleID");

            migrationBuilder.RenameColumn(
                name: "fBalance",
                table: "Users",
                newName: "Balance");

            migrationBuilder.RenameColumn(
                name: "dUpdatedAt",
                table: "Users",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "dCreatedAt",
                table: "Users",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "dBirthDate",
                table: "Users",
                newName: "BirthDate");

            migrationBuilder.RenameColumn(
                name: "iUserID_PK",
                table: "Users",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_tblUsers_iRoleID_FK",
                table: "Users",
                newName: "IX_Users_RoleID");

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "Users",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_Users_UserID",
                table: "BankAccounts",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_RecipientUserID",
                table: "Transactions",
                column: "RecipientUserID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_SenderUserID",
                table: "Transactions",
                column: "SenderUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleID",
                table: "Users",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
