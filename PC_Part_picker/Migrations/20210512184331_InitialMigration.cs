using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Part_picker.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cpu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Cores = table.Column<int>(nullable: false),
                    Frequency = table.Column<string>(nullable: true),
                    Series = table.Column<string>(nullable: true),
                    Consumption = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cpu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dimensions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Length = table.Column<string>(nullable: true),
                    Width = table.Column<string>(nullable: true),
                    Height = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimensions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gpu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Memory = table.Column<string>(nullable: true),
                    Frequency = table.Column<string>(nullable: true),
                    MemoryType = table.Column<string>(nullable: true),
                    Consumption = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gpu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ram",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Frequency = table.Column<string>(nullable: true),
                    ModuleCount = table.Column<string>(nullable: true),
                    MemorySize = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ram", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocketCPU",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Socket = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocketCPU", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Capacity = table.Column<string>(nullable: true),
                    Connector = table.Column<string>(nullable: true),
                    Cache = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Case",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    FormFactor = table.Column<int>(nullable: false),
                    DimensionsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Case", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Case_Dimensions_DimensionsId",
                        column: x => x.DimensionsId,
                        principalTable: "Dimensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Psu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    FormFactor = table.Column<int>(nullable: false),
                    Wattage = table.Column<string>(nullable: true),
                    Modular = table.Column<string>(nullable: true),
                    EfficiencyRating = table.Column<string>(nullable: true),
                    DimensionsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Psu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Psu_Dimensions_DimensionsId",
                        column: x => x.DimensionsId,
                        principalTable: "Dimensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cooler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    SoundLevel = table.Column<string>(nullable: true),
                    Speed = table.Column<string>(nullable: true),
                    RadiatorSize = table.Column<string>(nullable: true),
                    SocketId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cooler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cooler_SocketCPU_SocketId",
                        column: x => x.SocketId,
                        principalTable: "SocketCPU",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Motherboard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    MemorySlots = table.Column<int>(nullable: false),
                    MemoryType = table.Column<string>(nullable: true),
                    FormFactor = table.Column<int>(nullable: false),
                    SocketId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motherboard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motherboard_SocketCPU_SocketId",
                        column: x => x.SocketId,
                        principalTable: "SocketCPU",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Build",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    RatingCount = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Publication = table.Column<bool>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    CpuId = table.Column<int>(nullable: true),
                    CoolerId = table.Column<int>(nullable: true),
                    MotherboardId = table.Column<int>(nullable: true),
                    RamId = table.Column<int>(nullable: true),
                    StorageId = table.Column<int>(nullable: true),
                    GpuId = table.Column<int>(nullable: true),
                    PsuId = table.Column<int>(nullable: true),
                    CaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Build", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Build_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Build_Cooler_CoolerId",
                        column: x => x.CoolerId,
                        principalTable: "Cooler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Build_Cpu_CpuId",
                        column: x => x.CpuId,
                        principalTable: "Cpu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Build_Gpu_GpuId",
                        column: x => x.GpuId,
                        principalTable: "Gpu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Build_Motherboard_MotherboardId",
                        column: x => x.MotherboardId,
                        principalTable: "Motherboard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Build_Psu_PsuId",
                        column: x => x.PsuId,
                        principalTable: "Psu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Build_Ram_RamId",
                        column: x => x.RamId,
                        principalTable: "Ram",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Build_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Build_CaseId",
                table: "Build",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Build_CoolerId",
                table: "Build",
                column: "CoolerId");

            migrationBuilder.CreateIndex(
                name: "IX_Build_CpuId",
                table: "Build",
                column: "CpuId");

            migrationBuilder.CreateIndex(
                name: "IX_Build_GpuId",
                table: "Build",
                column: "GpuId");

            migrationBuilder.CreateIndex(
                name: "IX_Build_MotherboardId",
                table: "Build",
                column: "MotherboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Build_PsuId",
                table: "Build",
                column: "PsuId");

            migrationBuilder.CreateIndex(
                name: "IX_Build_RamId",
                table: "Build",
                column: "RamId");

            migrationBuilder.CreateIndex(
                name: "IX_Build_StorageId",
                table: "Build",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Case_DimensionsId",
                table: "Case",
                column: "DimensionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Cooler_SocketId",
                table: "Cooler",
                column: "SocketId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboard_SocketId",
                table: "Motherboard",
                column: "SocketId");

            migrationBuilder.CreateIndex(
                name: "IX_Psu_DimensionsId",
                table: "Psu",
                column: "DimensionsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Build");

            migrationBuilder.DropTable(
                name: "Case");

            migrationBuilder.DropTable(
                name: "Cooler");

            migrationBuilder.DropTable(
                name: "Cpu");

            migrationBuilder.DropTable(
                name: "Gpu");

            migrationBuilder.DropTable(
                name: "Motherboard");

            migrationBuilder.DropTable(
                name: "Psu");

            migrationBuilder.DropTable(
                name: "Ram");

            migrationBuilder.DropTable(
                name: "Storage");

            migrationBuilder.DropTable(
                name: "SocketCPU");

            migrationBuilder.DropTable(
                name: "Dimensions");
        }
    }
}
