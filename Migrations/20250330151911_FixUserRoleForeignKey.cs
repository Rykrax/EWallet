using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EWallet.Migrations
{
    /// <inheritdoc />
    public partial class FixUserRoleForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblUsers_tblRoles_iRoleID_FK",
                table: "tblUsers");

            migrationBuilder.DropColumn(
                name: "iRoleID_FK1",
                table: "tblUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role",
                table: "tblUsers",
                column: "iRoleID_FK",
                principalTable: "tblRoles",
                principalColumn: "iRoleID_PK",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Role",
                table: "tblUsers");

            migrationBuilder.AddColumn<byte>(
                name: "iRoleID_FK1",
                table: "tblUsers",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddForeignKey(
                name: "FK_tblUsers_tblRoles_iRoleID_FK",
                table: "tblUsers",
                column: "iRoleID_FK",
                principalTable: "tblRoles",
                principalColumn: "iRoleID_PK",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
