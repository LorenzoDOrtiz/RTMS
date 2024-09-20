using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTMS.Plugins.PostgreEFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddClientWorkoutTemplatesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientWorkoutTemplates",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkoutTemplateId = table.Column<int>(type: "integer", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AssignedBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientWorkoutTemplates", x => new { x.ClientId, x.WorkoutTemplateId });
                    table.ForeignKey(
                        name: "FK_ClientWorkoutTemplates_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientWorkoutTemplates_WorkoutTemplates_WorkoutTemplateId",
                        column: x => x.WorkoutTemplateId,
                        principalTable: "WorkoutTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientWorkoutTemplates_WorkoutTemplateId",
                table: "ClientWorkoutTemplates",
                column: "WorkoutTemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientWorkoutTemplates");
        }
    }
}
