using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Part_picker.Migrations
{
    public partial class AddCompatibility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compatibilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compatibilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartCompatibilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompatibilityId = table.Column<int>(nullable: false),
                    CPUId = table.Column<int>(nullable: true),
                    CaseId = table.Column<int>(nullable: true),
                    CoolerId = table.Column<int>(nullable: true),
                    GPUId = table.Column<int>(nullable: true),
                    MotherboardId = table.Column<int>(nullable: true),
                    PSUId = table.Column<int>(nullable: true),
                    RAMId = table.Column<int>(nullable: true),
                    StorageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartCompatibilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartCompatibilities_Cpu_CPUId",
                        column: x => x.CPUId,
                        principalTable: "Cpu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartCompatibilities_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartCompatibilities_Compatibilities_CompatibilityId",
                        column: x => x.CompatibilityId,
                        principalTable: "Compatibilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartCompatibilities_Cooler_CoolerId",
                        column: x => x.CoolerId,
                        principalTable: "Cooler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartCompatibilities_Gpu_GPUId",
                        column: x => x.GPUId,
                        principalTable: "Gpu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartCompatibilities_Motherboard_MotherboardId",
                        column: x => x.MotherboardId,
                        principalTable: "Motherboard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartCompatibilities_Psu_PSUId",
                        column: x => x.PSUId,
                        principalTable: "Psu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartCompatibilities_Ram_RAMId",
                        column: x => x.RAMId,
                        principalTable: "Ram",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartCompatibilities_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartCompatibilities_CPUId",
                table: "PartCompatibilities",
                column: "CPUId");

            migrationBuilder.CreateIndex(
                name: "IX_PartCompatibilities_CaseId",
                table: "PartCompatibilities",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PartCompatibilities_CompatibilityId",
                table: "PartCompatibilities",
                column: "CompatibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_PartCompatibilities_CoolerId",
                table: "PartCompatibilities",
                column: "CoolerId");

            migrationBuilder.CreateIndex(
                name: "IX_PartCompatibilities_GPUId",
                table: "PartCompatibilities",
                column: "GPUId");

            migrationBuilder.CreateIndex(
                name: "IX_PartCompatibilities_MotherboardId",
                table: "PartCompatibilities",
                column: "MotherboardId");

            migrationBuilder.CreateIndex(
                name: "IX_PartCompatibilities_PSUId",
                table: "PartCompatibilities",
                column: "PSUId");

            migrationBuilder.CreateIndex(
                name: "IX_PartCompatibilities_RAMId",
                table: "PartCompatibilities",
                column: "RAMId");

            migrationBuilder.CreateIndex(
                name: "IX_PartCompatibilities_StorageId",
                table: "PartCompatibilities",
                column: "StorageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartCompatibilities");

            migrationBuilder.DropTable(
                name: "Compatibilities");
        }
    }
}
