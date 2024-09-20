using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTMS.Plugins.PostgreEFCore.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOnDeleteToLetAllConnectedDataToAUserToDeleteWhenUserIsDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainerClients_Users_ClientId",
                table: "TrainerClients");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerClients_Users_TrainerId",
                table: "TrainerClients");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerClients_Users_ClientId",
                table: "TrainerClients",
                column: "ClientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerClients_Users_TrainerId",
                table: "TrainerClients",
                column: "TrainerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainerClients_Users_ClientId",
                table: "TrainerClients");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerClients_Users_TrainerId",
                table: "TrainerClients");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerClients_Users_ClientId",
                table: "TrainerClients",
                column: "ClientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerClients_Users_TrainerId",
                table: "TrainerClients",
                column: "TrainerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
