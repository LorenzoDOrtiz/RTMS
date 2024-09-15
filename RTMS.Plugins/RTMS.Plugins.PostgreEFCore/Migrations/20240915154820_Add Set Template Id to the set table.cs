using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTMS.Plugins.PostgreEFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddSetTemplateIdtothesettable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WorkoutTemplateId",
                table: "Workouts",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SetTemplateId",
                table: "ExerciseSets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseTemplateId",
                table: "Exercises",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSets_SetTemplateId",
                table: "ExerciseSets",
                column: "SetTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseSets_ExerciseSetTemplates_SetTemplateId",
                table: "ExerciseSets",
                column: "SetTemplateId",
                principalTable: "ExerciseSetTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseSets_ExerciseSetTemplates_SetTemplateId",
                table: "ExerciseSets");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseSets_SetTemplateId",
                table: "ExerciseSets");

            migrationBuilder.DropColumn(
                name: "SetTemplateId",
                table: "ExerciseSets");

            migrationBuilder.AlterColumn<int>(
                name: "WorkoutTemplateId",
                table: "Workouts",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseTemplateId",
                table: "Exercises",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
