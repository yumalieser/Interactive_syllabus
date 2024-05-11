using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interactive_Syllabus.Migrations
{
    /// <inheritdoc />
    public partial class add_database_v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Academicianes_StudentsClasses_StudentsClassID",
                table: "Academicianes");

            migrationBuilder.DropIndex(
                name: "IX_Academicianes_StudentsClassID",
                table: "Academicianes");

            migrationBuilder.DropColumn(
                name: "StudentsClassID",
                table: "Academicianes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentsClassID",
                table: "Academicianes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Academicianes_StudentsClassID",
                table: "Academicianes",
                column: "StudentsClassID");

            migrationBuilder.AddForeignKey(
                name: "FK_Academicianes_StudentsClasses_StudentsClassID",
                table: "Academicianes",
                column: "StudentsClassID",
                principalTable: "StudentsClasses",
                principalColumn: "StudentsClassID");
        }
    }
}
