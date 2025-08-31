using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Lecturertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lecturer_Colleges_CollegeId",
                table: "Lecturer");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Lecturer",
                newName: "LastName");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CollegeId",
                table: "Lecturer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Lecturer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Lecturer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturer_Colleges_CollegeId",
                table: "Lecturer",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lecturer_Colleges_CollegeId",
                table: "Lecturer");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Lecturer");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Lecturer");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Lecturer",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "CollegeId",
                table: "Lecturer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturer_Colleges_CollegeId",
                table: "Lecturer",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
