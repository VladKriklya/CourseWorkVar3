using Microsoft.EntityFrameworkCore.Migrations;

namespace UIL.Migrations
{
    public partial class AddUserForList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_UserForList_UserForListId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserForList",
                table: "UserForList");

            migrationBuilder.RenameTable(
                name: "UserForList",
                newName: "UserForLists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserForLists",
                table: "UserForLists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_UserForLists_UserForListId",
                table: "Orders",
                column: "UserForListId",
                principalTable: "UserForLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_UserForLists_UserForListId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserForLists",
                table: "UserForLists");

            migrationBuilder.RenameTable(
                name: "UserForLists",
                newName: "UserForList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserForList",
                table: "UserForList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_UserForList_UserForListId",
                table: "Orders",
                column: "UserForListId",
                principalTable: "UserForList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
