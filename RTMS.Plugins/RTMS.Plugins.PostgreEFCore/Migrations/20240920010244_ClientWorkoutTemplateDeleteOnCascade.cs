using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTMS.Plugins.PostgreEFCore.Migrations
{
    /// <inheritdoc />
    public partial class ClientWorkoutTemplateDeleteOnCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientWorkoutTemplates_WorkoutTemplates_WorkoutTemplateId",
                table: "ClientWorkoutTemplates");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientWorkoutTemplates_WorkoutTemplates_WorkoutTemplateId",
                table: "ClientWorkoutTemplates",
                column: "WorkoutTemplateId",
                principalTable: "WorkoutTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientWorkoutTemplates_WorkoutTemplates_WorkoutTemplateId",
                table: "ClientWorkoutTemplates");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientWorkoutTemplates_WorkoutTemplates_WorkoutTemplateId",
                table: "ClientWorkoutTemplates",
                column: "WorkoutTemplateId",
                principalTable: "WorkoutTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
