using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Attendanceregister.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CascadeBehaviorForSubjectClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "CN_SubjectClasses_Classes",
                table: "SubjectClasses");

            migrationBuilder.DropForeignKey(
                name: "CN_SubjectClasses_Subjects",
                table: "SubjectClasses");

            migrationBuilder.AddForeignKey(
                name: "CN_SubjectClasses_Classes",
                table: "SubjectClasses",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "CN_SubjectClasses_Subjects",
                table: "SubjectClasses",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "CN_SubjectClasses_Classes",
                table: "SubjectClasses");

            migrationBuilder.DropForeignKey(
                name: "CN_SubjectClasses_Subjects",
                table: "SubjectClasses");

            migrationBuilder.AddForeignKey(
                name: "CN_SubjectClasses_Classes",
                table: "SubjectClasses",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "CN_SubjectClasses_Subjects",
                table: "SubjectClasses",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id");
        }
    }
}
