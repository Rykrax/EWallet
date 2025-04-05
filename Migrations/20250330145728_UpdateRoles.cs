using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EWallet.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblUsers_Roles_iRoleID_FK",
                table: "tblUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "tblRoles");

            migrationBuilder.RenameColumn(
                name: "RoleName",
                table: "tblRoles",
                newName: "sRoleName");

            migrationBuilder.RenameColumn(
                name: "RoleID",
                table: "tblRoles",
                newName: "iRoleID_PK");

            migrationBuilder.AddColumn<byte>(
                name: "iRoleID_FK1",
                table: "tblUsers",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblRoles",
                table: "tblRoles",
                column: "iRoleID_PK");

            migrationBuilder.AddForeignKey(
                name: "FK_tblUsers_tblRoles_iRoleID_FK",
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
                name: "FK_tblUsers_tblRoles_iRoleID_FK",
                table: "tblUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblRoles",
                table: "tblRoles");

            migrationBuilder.DropColumn(
                name: "iRoleID_FK1",
                table: "tblUsers");

            migrationBuilder.RenameTable(
                name: "tblRoles",
                newName: "Roles");

            migrationBuilder.RenameColumn(
                name: "sRoleName",
                table: "Roles",
                newName: "RoleName");

            migrationBuilder.RenameColumn(
                name: "iRoleID_PK",
                table: "Roles",
                newName: "RoleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblUsers_Roles_iRoleID_FK",
                table: "tblUsers",
                column: "iRoleID_FK",
                principalTable: "Roles",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
