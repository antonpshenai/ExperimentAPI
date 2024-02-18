using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExperementsAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceExperiments_Devices_IdDevice",
                table: "DeviceExperiments");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceExperiments_ExperimentValues_IdExperimentValues",
                table: "DeviceExperiments");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceExperiments_Experiments_IdExperiments",
                table: "DeviceExperiments");

            migrationBuilder.DropForeignKey(
                name: "FK_ExperimentValues_Experiments_IdExperiments",
                table: "ExperimentValues");

            migrationBuilder.RenameColumn(
                name: "IdExperiments",
                table: "ExperimentValues",
                newName: "ExperimentsId");

            migrationBuilder.RenameIndex(
                name: "IX_ExperimentValues_IdExperiments",
                table: "ExperimentValues",
                newName: "IX_ExperimentValues_ExperimentsId");

            migrationBuilder.RenameColumn(
                name: "IdExperiments",
                table: "DeviceExperiments",
                newName: "ExperimentsId");

            migrationBuilder.RenameColumn(
                name: "IdExperimentValues",
                table: "DeviceExperiments",
                newName: "ExperimentValuesId");

            migrationBuilder.RenameColumn(
                name: "IdExperimentValue",
                table: "DeviceExperiments",
                newName: "ExperimentValueId");

            migrationBuilder.RenameColumn(
                name: "IdDevice",
                table: "DeviceExperiments",
                newName: "DeviceId");

            migrationBuilder.RenameIndex(
                name: "IX_DeviceExperiments_IdExperimentValues",
                table: "DeviceExperiments",
                newName: "IX_DeviceExperiments_ExperimentValuesId");

            migrationBuilder.RenameIndex(
                name: "IX_DeviceExperiments_IdExperiments",
                table: "DeviceExperiments",
                newName: "IX_DeviceExperiments_ExperimentsId");

            migrationBuilder.RenameIndex(
                name: "IX_DeviceExperiments_IdDevice",
                table: "DeviceExperiments",
                newName: "IX_DeviceExperiments_DeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceExperiments_Devices_DeviceId",
                table: "DeviceExperiments",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceExperiments_ExperimentValues_ExperimentValuesId",
                table: "DeviceExperiments",
                column: "ExperimentValuesId",
                principalTable: "ExperimentValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceExperiments_Experiments_ExperimentsId",
                table: "DeviceExperiments",
                column: "ExperimentsId",
                principalTable: "Experiments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExperimentValues_Experiments_ExperimentsId",
                table: "ExperimentValues",
                column: "ExperimentsId",
                principalTable: "Experiments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceExperiments_Devices_DeviceId",
                table: "DeviceExperiments");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceExperiments_ExperimentValues_ExperimentValuesId",
                table: "DeviceExperiments");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceExperiments_Experiments_ExperimentsId",
                table: "DeviceExperiments");

            migrationBuilder.DropForeignKey(
                name: "FK_ExperimentValues_Experiments_ExperimentsId",
                table: "ExperimentValues");

            migrationBuilder.RenameColumn(
                name: "ExperimentsId",
                table: "ExperimentValues",
                newName: "IdExperiments");

            migrationBuilder.RenameIndex(
                name: "IX_ExperimentValues_ExperimentsId",
                table: "ExperimentValues",
                newName: "IX_ExperimentValues_IdExperiments");

            migrationBuilder.RenameColumn(
                name: "ExperimentsId",
                table: "DeviceExperiments",
                newName: "IdExperiments");

            migrationBuilder.RenameColumn(
                name: "ExperimentValuesId",
                table: "DeviceExperiments",
                newName: "IdExperimentValues");

            migrationBuilder.RenameColumn(
                name: "ExperimentValueId",
                table: "DeviceExperiments",
                newName: "IdExperimentValue");

            migrationBuilder.RenameColumn(
                name: "DeviceId",
                table: "DeviceExperiments",
                newName: "IdDevice");

            migrationBuilder.RenameIndex(
                name: "IX_DeviceExperiments_ExperimentValuesId",
                table: "DeviceExperiments",
                newName: "IX_DeviceExperiments_IdExperimentValues");

            migrationBuilder.RenameIndex(
                name: "IX_DeviceExperiments_ExperimentsId",
                table: "DeviceExperiments",
                newName: "IX_DeviceExperiments_IdExperiments");

            migrationBuilder.RenameIndex(
                name: "IX_DeviceExperiments_DeviceId",
                table: "DeviceExperiments",
                newName: "IX_DeviceExperiments_IdDevice");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceExperiments_Devices_IdDevice",
                table: "DeviceExperiments",
                column: "IdDevice",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceExperiments_ExperimentValues_IdExperimentValues",
                table: "DeviceExperiments",
                column: "IdExperimentValues",
                principalTable: "ExperimentValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceExperiments_Experiments_IdExperiments",
                table: "DeviceExperiments",
                column: "IdExperiments",
                principalTable: "Experiments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExperimentValues_Experiments_IdExperiments",
                table: "ExperimentValues",
                column: "IdExperiments",
                principalTable: "Experiments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
