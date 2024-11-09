using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learning.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMediaQuestionFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileOptions_ExpiriedAt",
                table: "MediaQuestions");

            migrationBuilder.DropColumn(
                name: "FileOptions_Name",
                table: "MediaQuestions");

            migrationBuilder.RenameColumn(
                name: "FileOptions_PresignedUrl",
                table: "MediaQuestions",
                newName: "MediaFileName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MediaFileName",
                table: "MediaQuestions",
                newName: "FileOptions_PresignedUrl");

            migrationBuilder.AddColumn<DateTime>(
                name: "FileOptions_ExpiriedAt",
                table: "MediaQuestions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FileOptions_Name",
                table: "MediaQuestions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
