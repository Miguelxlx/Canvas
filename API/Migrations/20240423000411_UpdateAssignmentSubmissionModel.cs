using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAssignmentSubmissionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentSubmission_Assignments_AssignmentId",
                table: "AssignmentSubmission");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentSubmission_Students_StudentId",
                table: "AssignmentSubmission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignmentSubmission",
                table: "AssignmentSubmission");

            migrationBuilder.RenameTable(
                name: "AssignmentSubmission",
                newName: "AssignmentSubmissions");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentSubmission_StudentId",
                table: "AssignmentSubmissions",
                newName: "IX_AssignmentSubmissions_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentSubmission_AssignmentId",
                table: "AssignmentSubmissions",
                newName: "IX_AssignmentSubmissions_AssignmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignmentSubmissions",
                table: "AssignmentSubmissions",
                column: "SubmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentSubmissions_Assignments_AssignmentId",
                table: "AssignmentSubmissions",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentSubmissions_Students_StudentId",
                table: "AssignmentSubmissions",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentSubmissions_Assignments_AssignmentId",
                table: "AssignmentSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentSubmissions_Students_StudentId",
                table: "AssignmentSubmissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignmentSubmissions",
                table: "AssignmentSubmissions");

            migrationBuilder.RenameTable(
                name: "AssignmentSubmissions",
                newName: "AssignmentSubmission");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentSubmissions_StudentId",
                table: "AssignmentSubmission",
                newName: "IX_AssignmentSubmission_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentSubmissions_AssignmentId",
                table: "AssignmentSubmission",
                newName: "IX_AssignmentSubmission_AssignmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignmentSubmission",
                table: "AssignmentSubmission",
                column: "SubmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentSubmission_Assignments_AssignmentId",
                table: "AssignmentSubmission",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentSubmission_Students_StudentId",
                table: "AssignmentSubmission",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
