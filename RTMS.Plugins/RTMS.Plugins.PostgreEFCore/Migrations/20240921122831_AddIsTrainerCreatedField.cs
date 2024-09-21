using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTMS.Plugins.PostgreEFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddIsTrainerCreatedField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "ExerciseTemplates");

            migrationBuilder.DropColumn(
                name: "AssignedBy",
                table: "ClientWorkoutTemplates");

            migrationBuilder.DropColumn(
                name: "AssignedDate",
                table: "ClientWorkoutTemplates");

            migrationBuilder.AddColumn<bool>(
                name: "IsTrainerCreated",
                table: "WorkoutTemplates",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTrainerCreated",
                table: "WorkoutTemplates");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "ExerciseTemplates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AssignedBy",
                table: "ClientWorkoutTemplates",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "AssignedDate",
                table: "ClientWorkoutTemplates",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
