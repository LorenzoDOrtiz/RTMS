using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTMS.Plugins.PostgreEFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_WorkoutTemplates_TemplateId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_TemplateId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "Workouts");

            migrationBuilder.AddColumn<int>(
                name: "WorkoutTemplateId",
                table: "Workouts",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_WorkoutTemplateId",
                table: "Workouts",
                column: "WorkoutTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_WorkoutTemplates_WorkoutTemplateId",
                table: "Workouts",
                column: "WorkoutTemplateId",
                principalTable: "WorkoutTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_WorkoutTemplates_WorkoutTemplateId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_WorkoutTemplateId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "WorkoutTemplateId",
                table: "Workouts");

            migrationBuilder.AddColumn<int>(
                name: "TemplateId",
                table: "Workouts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_TemplateId",
                table: "Workouts",
                column: "TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_WorkoutTemplates_TemplateId",
                table: "Workouts",
                column: "TemplateId",
                principalTable: "WorkoutTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
