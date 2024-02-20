using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExperementsAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemoveColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceExperiments_ExperimentValues_ExperimentValuesId",
                table: "DeviceExperiments");

            migrationBuilder.DropIndex(
                name: "IX_DeviceExperiments_ExperimentValuesId",
                table: "DeviceExperiments");

            migrationBuilder.DropColumn(
                name: "ExperimentValuesId",
                table: "DeviceExperiments");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceExperiments_ExperimentValueId",
                table: "DeviceExperiments",
                column: "ExperimentValueId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceExperiments_ExperimentValues_ExperimentValueId",
                table: "DeviceExperiments",
                column: "ExperimentValueId",
                principalTable: "ExperimentValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceExperiments_ExperimentValues_ExperimentValueId",
                table: "DeviceExperiments");

            migrationBuilder.DropIndex(
                name: "IX_DeviceExperiments_ExperimentValueId",
                table: "DeviceExperiments");

            migrationBuilder.AddColumn<int>(
                name: "ExperimentValuesId",
                table: "DeviceExperiments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceExperiments_ExperimentValuesId",
                table: "DeviceExperiments",
                column: "ExperimentValuesId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceExperiments_ExperimentValues_ExperimentValuesId",
                table: "DeviceExperiments",
                column: "ExperimentValuesId",
                principalTable: "ExperimentValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
