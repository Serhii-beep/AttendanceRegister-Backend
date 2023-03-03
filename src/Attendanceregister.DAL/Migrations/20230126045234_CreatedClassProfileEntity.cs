using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Attendanceregister.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreatedClassProfileEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassProfileId",
                table: "Classes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ClassProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassProfiles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ClassProfileId",
                table: "Classes",
                column: "ClassProfileId");

            migrationBuilder.AddForeignKey(
                name: "CN_Classes_ClassProfiles",
                table: "Classes",
                column: "ClassProfileId",
                principalTable: "ClassProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "CN_Classes_ClassProfiles",
                table: "Classes");

            migrationBuilder.DropTable(
                name: "ClassProfiles");

            migrationBuilder.DropIndex(
                name: "IX_Classes_ClassProfileId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "ClassProfileId",
                table: "Classes");
        }
    }
}
