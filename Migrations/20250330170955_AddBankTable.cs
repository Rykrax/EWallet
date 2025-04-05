using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EWallet.Migrations
{
    /// <inheritdoc />
    public partial class AddBankTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_Banks_BankID",
                table: "BankAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Banks",
                table: "Banks");

            migrationBuilder.RenameTable(
                name: "Banks",
                newName: "tblBanks");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "tblBanks",
                newName: "sImage");

            migrationBuilder.RenameColumn(
                name: "BankName",
                table: "tblBanks",
                newName: "sBankName");

            migrationBuilder.RenameColumn(
                name: "BankID",
                table: "tblBanks",
                newName: "sBankID_PK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblBanks",
                table: "tblBanks",
                column: "sBankID_PK");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_tblBanks_BankID",
                table: "BankAccounts",
                column: "BankID",
                principalTable: "tblBanks",
                principalColumn: "sBankID_PK",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_tblBanks_BankID",
                table: "BankAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblBanks",
                table: "tblBanks");

            migrationBuilder.RenameTable(
                name: "tblBanks",
                newName: "Banks");

            migrationBuilder.RenameColumn(
                name: "sImage",
                table: "Banks",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "sBankName",
                table: "Banks",
                newName: "BankName");

            migrationBuilder.RenameColumn(
                name: "sBankID_PK",
                table: "Banks",
                newName: "BankID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Banks",
                table: "Banks",
                column: "BankID");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_Banks_BankID",
                table: "BankAccounts",
                column: "BankID",
                principalTable: "Banks",
                principalColumn: "BankID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
