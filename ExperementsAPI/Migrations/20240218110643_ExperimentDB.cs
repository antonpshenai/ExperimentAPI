using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExperementsAPI.Migrations
{
    /// <inheritdoc />
    public partial class ExperimentDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceToken = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experiments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExperimentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExperimentValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Values = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcentValue = table.Column<double>(type: "float", nullable: true),
                    IdExperiments = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperimentValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExperimentValues_Experiments_IdExperiments",
                        column: x => x.IdExperiments,
                        principalTable: "Experiments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceExperiments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDevice = table.Column<int>(type: "int", nullable: false),
                    IdExperiments = table.Column<int>(type: "int", nullable: false),
                    IdExperimentValue = table.Column<int>(type: "int", nullable: false),
                    IdExperimentValues = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceExperiments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceExperiments_Devices_IdDevice",
                        column: x => x.IdDevice,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceExperiments_ExperimentValues_IdExperimentValues",
                        column: x => x.IdExperimentValues,
                        principalTable: "ExperimentValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeviceExperiments_Experiments_IdExperiments",
                        column: x => x.IdExperiments,
                        principalTable: "Experiments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceExperiments_IdDevice",
                table: "DeviceExperiments",
                column: "IdDevice");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceExperiments_IdExperiments",
                table: "DeviceExperiments",
                column: "IdExperiments");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceExperiments_IdExperimentValues",
                table: "DeviceExperiments",
                column: "IdExperimentValues");

            migrationBuilder.CreateIndex(
                name: "IX_ExperimentValues_IdExperiments",
                table: "ExperimentValues",
                column: "IdExperiments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceExperiments");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "ExperimentValues");

            migrationBuilder.DropTable(
                name: "Experiments");
        }
    }
}
