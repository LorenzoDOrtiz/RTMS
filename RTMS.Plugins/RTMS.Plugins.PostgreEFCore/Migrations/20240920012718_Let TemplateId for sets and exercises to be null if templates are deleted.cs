using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTMS.Plugins.PostgreEFCore.Migrations
{
    /// <inheritdoc />
    public partial class LetTemplateIdforsetsandexercisestobenulliftemplatesaredeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SetTemplateId",
                table: "ExerciseSets",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SetTemplateId",
                table: "ExerciseSets",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseTemplateId",
                table: "Exercises",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
