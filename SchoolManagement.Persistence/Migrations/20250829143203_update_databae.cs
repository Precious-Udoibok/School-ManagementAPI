using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update_databae : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lecturer_Courses_CourseId",
                table: "Lecturer");

            migrationBuilder.RenameColumn(
                name: "courses_taken",
                table: "Lecturer",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Lecturer",
                newName: "CollegeId");

            migrationBuilder.RenameIndex(
                name: "IX_Lecturer_CourseId",
                table: "Lecturer",
                newName: "IX_Lecturer_CollegeId");

            migrationBuilder.AddColumn<int>(
                name: "CollegeId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CollegeId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "CourseRegistrations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Students_CollegeId",
                table: "Students",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CollegeId",
                table: "Courses",
                column: "CollegeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Colleges_CollegeId",
                table: "Courses",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturer_Colleges_CollegeId",
                table: "Lecturer",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Colleges_CollegeId",
                table: "Students",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Colleges_CollegeId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecturer_Colleges_CollegeId",
                table: "Lecturer");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Colleges_CollegeId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_CollegeId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CollegeId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CollegeId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CollegeId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "CourseRegistrations");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Lecturer",
                newName: "courses_taken");

            migrationBuilder.RenameColumn(
                name: "CollegeId",
                table: "Lecturer",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Lecturer_CollegeId",
                table: "Lecturer",
                newName: "IX_Lecturer_CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturer_Courses_CourseId",
                table: "Lecturer",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
