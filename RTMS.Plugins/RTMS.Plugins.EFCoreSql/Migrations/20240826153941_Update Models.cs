using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTMS.Plugins.EFCoreSql.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseSets_Exercises_ExerciseId",
                table: "ExerciseSets");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "ExerciseSets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_TemplateId",
                table: "Workouts",
                column: "TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseSets_Exercises_ExerciseId",
                table: "ExerciseSets",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_WorkoutTemplates_TemplateId",
                table: "Workouts",
                column: "TemplateId",
                principalTable: "WorkoutTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseSets_Exercises_ExerciseId",
                table: "ExerciseSets");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_WorkoutTemplates_TemplateId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_TemplateId",
                table: "Workouts");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "ExerciseSets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseSets_Exercises_ExerciseId",
                table: "ExerciseSets",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");
        }
    }
}
