using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Migrations
{
    /// <inheritdoc />
    public partial class ManytoMany1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemClients_Clients_ClientID",
                table: "ItemClients");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "ItemClients",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemClients_ClientID",
                table: "ItemClients",
                newName: "IX_ItemClients_ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemClients_Clients_ClientId",
                table: "ItemClients",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemClients_Clients_ClientId",
                table: "ItemClients");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "ItemClients",
                newName: "ClientID");

            migrationBuilder.RenameIndex(
                name: "IX_ItemClients_ClientId",
                table: "ItemClients",
                newName: "IX_ItemClients_ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemClients_Clients_ClientID",
                table: "ItemClients",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
