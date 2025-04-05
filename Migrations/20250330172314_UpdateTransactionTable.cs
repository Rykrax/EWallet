using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EWallet.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTransactionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_BankAccounts_BankAccountID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_tblUsers_RecipientUserID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_tblUsers_SenderUserID",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "tblTransactions");

            migrationBuilder.RenameColumn(
                name: "TransactionType",
                table: "tblTransactions",
                newName: "sTransactionType");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "tblTransactions",
                newName: "sStatus");

            migrationBuilder.RenameColumn(
                name: "SenderUserID",
                table: "tblTransactions",
                newName: "iSenderUserID_FK");

            migrationBuilder.RenameColumn(
                name: "RecipientUserID",
                table: "tblTransactions",
                newName: "iRecipientUserID_FK");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "tblTransactions",
                newName: "sDescription");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "tblTransactions",
                newName: "dCreatedAt");

            migrationBuilder.RenameColumn(
                name: "BankAccountID",
                table: "tblTransactions",
                newName: "iBankAccountID_FK");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "tblTransactions",
                newName: "fAmount");

            migrationBuilder.RenameColumn(
                name: "TransactionID",
                table: "tblTransactions",
                newName: "iTransactionID_PK");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_SenderUserID",
                table: "tblTransactions",
                newName: "IX_tblTransactions_iSenderUserID_FK");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_RecipientUserID",
                table: "tblTransactions",
                newName: "IX_tblTransactions_iRecipientUserID_FK");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_BankAccountID",
                table: "tblTransactions",
                newName: "IX_tblTransactions_iBankAccountID_FK");

            migrationBuilder.AlterColumn<string>(
                name: "sImage",
                table: "tblBanks",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "sTransactionType",
                table: "tblTransactions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "sStatus",
                table: "tblTransactions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "sDescription",
                table: "tblTransactions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<decimal>(
                name: "fAmount",
                table: "tblTransactions",
                type: "decimal(15,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblTransactions",
                table: "tblTransactions",
                column: "iTransactionID_PK");

            migrationBuilder.AddForeignKey(
                name: "FK_tblTransactions_BankAccounts_iBankAccountID_FK",
                table: "tblTransactions",
                column: "iBankAccountID_FK",
                principalTable: "BankAccounts",
                principalColumn: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblTransactions_tblUsers_iRecipientUserID_FK",
                table: "tblTransactions",
                column: "iRecipientUserID_FK",
                principalTable: "tblUsers",
                principalColumn: "iUserID_PK");

            migrationBuilder.AddForeignKey(
                name: "FK_tblTransactions_tblUsers_iSenderUserID_FK",
                table: "tblTransactions",
                column: "iSenderUserID_FK",
                principalTable: "tblUsers",
                principalColumn: "iUserID_PK",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblTransactions_BankAccounts_iBankAccountID_FK",
                table: "tblTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_tblTransactions_tblUsers_iRecipientUserID_FK",
                table: "tblTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_tblTransactions_tblUsers_iSenderUserID_FK",
                table: "tblTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblTransactions",
                table: "tblTransactions");

            migrationBuilder.RenameTable(
                name: "tblTransactions",
                newName: "Transactions");

            migrationBuilder.RenameColumn(
                name: "sTransactionType",
                table: "Transactions",
                newName: "TransactionType");

            migrationBuilder.RenameColumn(
                name: "sStatus",
                table: "Transactions",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "sDescription",
                table: "Transactions",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "iSenderUserID_FK",
                table: "Transactions",
                newName: "SenderUserID");

            migrationBuilder.RenameColumn(
                name: "iRecipientUserID_FK",
                table: "Transactions",
                newName: "RecipientUserID");

            migrationBuilder.RenameColumn(
                name: "iBankAccountID_FK",
                table: "Transactions",
                newName: "BankAccountID");

            migrationBuilder.RenameColumn(
                name: "fAmount",
                table: "Transactions",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "dCreatedAt",
                table: "Transactions",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "iTransactionID_PK",
                table: "Transactions",
                newName: "TransactionID");

            migrationBuilder.RenameIndex(
                name: "IX_tblTransactions_iSenderUserID_FK",
                table: "Transactions",
                newName: "IX_Transactions_SenderUserID");

            migrationBuilder.RenameIndex(
                name: "IX_tblTransactions_iRecipientUserID_FK",
                table: "Transactions",
                newName: "IX_Transactions_RecipientUserID");

            migrationBuilder.RenameIndex(
                name: "IX_tblTransactions_iBankAccountID_FK",
                table: "Transactions",
                newName: "IX_Transactions_BankAccountID");

            migrationBuilder.AlterColumn<string>(
                name: "sImage",
                table: "tblBanks",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TransactionType",
                table: "Transactions",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Transactions",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Transactions",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "TransactionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_BankAccounts_BankAccountID",
                table: "Transactions",
                column: "BankAccountID",
                principalTable: "BankAccounts",
                principalColumn: "AccountID");

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
    }
}
