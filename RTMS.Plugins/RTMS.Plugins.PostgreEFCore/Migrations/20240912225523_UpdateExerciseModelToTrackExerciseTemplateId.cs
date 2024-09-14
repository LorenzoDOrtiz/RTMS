using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTMS.Plugins.PostgreEFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateExerciseModelToTrackExerciseTemplateId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExerciseTemplateId",
                table: "Exercises",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ExerciseTemplateId",
                table: "Exercises",
                column: "ExerciseTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_ExerciseTemplates_ExerciseTemplateId",
                table: "Exercises",
                column: "ExerciseTemplateId",
                principalTable: "ExerciseTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_ExerciseTemplates_ExerciseTemplateId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_ExerciseTemplateId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "ExerciseTemplateId",
                table: "Exercises");
        }
    }
}
