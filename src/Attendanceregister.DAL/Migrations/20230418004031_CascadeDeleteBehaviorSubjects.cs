using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Attendanceregister.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDeleteBehaviorSubjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "CN_TeacherSubjects_Subjects",
                table: "TeacherSubjects");

            migrationBuilder.DropForeignKey(
                name: "CN_TeacherSubjects_Teachers",
                table: "TeacherSubjects");

            migrationBuilder.AddForeignKey(
                name: "CN_TeacherSubjects_Subjects",
                table: "TeacherSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "CN_TeacherSubjects_Teachers",
                table: "TeacherSubjects",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "CN_TeacherSubjects_Subjects",
                table: "TeacherSubjects");

            migrationBuilder.DropForeignKey(
                name: "CN_TeacherSubjects_Teachers",
                table: "TeacherSubjects");

            migrationBuilder.AddForeignKey(
                name: "CN_TeacherSubjects_Subjects",
                table: "TeacherSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "CN_TeacherSubjects_Teachers",
                table: "TeacherSubjects",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }
    }
}
