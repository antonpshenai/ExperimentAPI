using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExperementsAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Values",
                table: "ExperimentValues",
                newName: "Value");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "ExperimentValues",
                newName: "Values");
        }
    }
}
