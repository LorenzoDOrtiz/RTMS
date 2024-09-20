﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTMS.Plugins.PostgreEFCore.Migrations
{
    /// <inheritdoc />
    public partial class ChangeWorkoutTemplateDeleteToSetForeignKeyInWorkoutToNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_WorkoutTemplates_WorkoutTemplateId",
                table: "Workouts");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_WorkoutTemplates_WorkoutTemplateId",
                table: "Workouts",
                column: "WorkoutTemplateId",
                principalTable: "WorkoutTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_WorkoutTemplates_WorkoutTemplateId",
                table: "Workouts");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_WorkoutTemplates_WorkoutTemplateId",
                table: "Workouts",
                column: "WorkoutTemplateId",
                principalTable: "WorkoutTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
