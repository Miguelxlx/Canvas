using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCourseStudentEnrollment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_CourseInfoCourseId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_CourseInfoCourseId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CourseInfoCourseId",
                table: "Students");

            migrationBuilder.CreateTable(
                name: "CourseStudentEnrollment",
                columns: table => new
                {
                    CourseInfoCourseId = table.Column<int>(type: "int", nullable: false),
                    RosterStudentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudentEnrollment", x => new { x.CourseInfoCourseId, x.RosterStudentId });
                    table.ForeignKey(
                        name: "FK_CourseStudentEnrollment_Courses_CourseInfoCourseId",
                        column: x => x.CourseInfoCourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudentEnrollment_Students_RosterStudentId",
                        column: x => x.RosterStudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudentEnrollment_RosterStudentId",
                table: "CourseStudentEnrollment",
                column: "RosterStudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseStudentEnrollment");

            migrationBuilder.AddColumn<int>(
                name: "CourseInfoCourseId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_CourseInfoCourseId",
                table: "Students",
                column: "CourseInfoCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_CourseInfoCourseId",
                table: "Students",
                column: "CourseInfoCourseId",
                principalTable: "Courses",
                principalColumn: "CourseId");
        }
    }
}
