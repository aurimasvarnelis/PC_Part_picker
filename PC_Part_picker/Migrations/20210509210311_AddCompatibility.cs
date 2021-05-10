using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Part_picker.Migrations
{
    public partial class AddCompatibility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Build_Case_CaseId",
                table: "Build");

            migrationBuilder.DropForeignKey(
                name: "FK_Build_Cooler_CoolerId",
                table: "Build");

            migrationBuilder.DropForeignKey(
                name: "FK_Build_Cpu_CpuId",
                table: "Build");

            migrationBuilder.DropForeignKey(
                name: "FK_Build_GPU_GpuId",
                table: "Build");

            migrationBuilder.DropForeignKey(
                name: "FK_Build_Motherboard_MotherboardId",
                table: "Build");

            migrationBuilder.DropForeignKey(
                name: "FK_Build_PSU_PsuId",
                table: "Build");

            migrationBuilder.DropForeignKey(
                name: "FK_Build_RAM_RAMId",
                table: "Build");

            migrationBuilder.DropForeignKey(
                name: "FK_Build_Storage_StorageId",
                table: "Build");

            migrationBuilder.DropTable(
                name: "Case");

            migrationBuilder.DropTable(
                name: "Cooler");

            migrationBuilder.DropTable(
                name: "Cpu");

            migrationBuilder.DropTable(
                name: "GPU");

            migrationBuilder.DropTable(
                name: "Motherboard");

            migrationBuilder.DropTable(
                name: "PSU");

            migrationBuilder.DropTable(
                name: "RAM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Storage",
                table: "Storage");

            migrationBuilder.RenameTable(
                name: "Storage",
                newName: "Part");

            migrationBuilder.AddColumn<int>(
                name: "Consumption",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cores",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Frequency",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Series",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DimensionsId",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeFormat",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnergyEfficiency",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Purpose",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RadiatorSize",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SocketId",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoundLevel",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GPU_Consumption",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GPU_Frequency",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Memory",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MemoryType",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnergyConsumption",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemorySocket",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Motherboard_MemoryType",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProccessorSocket",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Motherboard_SocketId",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PSU_DimensionsId",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Efficiency",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Power",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PSU_SoundLevel",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PSU_Type",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Part",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RAM_Frequency",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MemorySize",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModuleCount",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RAM_Type",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Storage_Speed",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Storage_Type",
                table: "Part",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Part",
                table: "Part",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Compatibility",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compatibility", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartCompatibility",
                columns: table => new
                {
                    PartId = table.Column<int>(nullable: false),
                    CompatibilityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartCompatibility", x => new { x.PartId, x.CompatibilityId });
                    table.ForeignKey(
                        name: "FK_PartCompatibility_Compatibility_CompatibilityId",
                        column: x => x.CompatibilityId,
                        principalTable: "Compatibility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartCompatibility_Part_PartId",
                        column: x => x.PartId,
                        principalTable: "Part",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Part_DimensionsId",
                table: "Part",
                column: "DimensionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Part_SocketId",
                table: "Part",
                column: "SocketId");

            migrationBuilder.CreateIndex(
                name: "IX_Part_Motherboard_SocketId",
                table: "Part",
                column: "Motherboard_SocketId");

            migrationBuilder.CreateIndex(
                name: "IX_Part_PSU_DimensionsId",
                table: "Part",
                column: "PSU_DimensionsId");

            migrationBuilder.CreateIndex(
                name: "IX_PartCompatibility_CompatibilityId",
                table: "PartCompatibility",
                column: "CompatibilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Build_Part_CaseId",
                table: "Build",
                column: "CaseId",
                principalTable: "Part",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Build_Part_CoolerId",
                table: "Build",
                column: "CoolerId",
                principalTable: "Part",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Build_Part_CpuId",
                table: "Build",
                column: "CpuId",
                principalTable: "Part",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Build_Part_GpuId",
                table: "Build",
                column: "GpuId",
                principalTable: "Part",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Build_Part_MotherboardId",
                table: "Build",
                column: "MotherboardId",
                principalTable: "Part",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Build_Part_PsuId",
                table: "Build",
                column: "PsuId",
                principalTable: "Part",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Build_Part_RAMId",
                table: "Build",
                column: "RAMId",
                principalTable: "Part",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Build_Part_StorageId",
                table: "Build",
                column: "StorageId",
                principalTable: "Part",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Part_Dimensions_DimensionsId",
                table: "Part",
                column: "DimensionsId",
                principalTable: "Dimensions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Part_SocketCPU_SocketId",
                table: "Part",
                column: "SocketId",
                principalTable: "SocketCPU",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Part_SocketCPU_Motherboard_SocketId",
                table: "Part",
                column: "Motherboard_SocketId",
                principalTable: "SocketCPU",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Part_Dimensions_PSU_DimensionsId",
                table: "Part",
                column: "PSU_DimensionsId",
                principalTable: "Dimensions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Build_Part_CaseId",
                table: "Build");

            migrationBuilder.DropForeignKey(
                name: "FK_Build_Part_CoolerId",
                table: "Build");

            migrationBuilder.DropForeignKey(
                name: "FK_Build_Part_CpuId",
                table: "Build");

            migrationBuilder.DropForeignKey(
                name: "FK_Build_Part_GpuId",
                table: "Build");

            migrationBuilder.DropForeignKey(
                name: "FK_Build_Part_MotherboardId",
                table: "Build");

            migrationBuilder.DropForeignKey(
                name: "FK_Build_Part_PsuId",
                table: "Build");

            migrationBuilder.DropForeignKey(
                name: "FK_Build_Part_RAMId",
                table: "Build");

            migrationBuilder.DropForeignKey(
                name: "FK_Build_Part_StorageId",
                table: "Build");

            migrationBuilder.DropForeignKey(
                name: "FK_Part_Dimensions_DimensionsId",
                table: "Part");

            migrationBuilder.DropForeignKey(
                name: "FK_Part_SocketCPU_SocketId",
                table: "Part");

            migrationBuilder.DropForeignKey(
                name: "FK_Part_SocketCPU_Motherboard_SocketId",
                table: "Part");

            migrationBuilder.DropForeignKey(
                name: "FK_Part_Dimensions_PSU_DimensionsId",
                table: "Part");

            migrationBuilder.DropTable(
                name: "PartCompatibility");

            migrationBuilder.DropTable(
                name: "Compatibility");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Part",
                table: "Part");

            migrationBuilder.DropIndex(
                name: "IX_Part_DimensionsId",
                table: "Part");

            migrationBuilder.DropIndex(
                name: "IX_Part_SocketId",
                table: "Part");

            migrationBuilder.DropIndex(
                name: "IX_Part_Motherboard_SocketId",
                table: "Part");

            migrationBuilder.DropIndex(
                name: "IX_Part_PSU_DimensionsId",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "Consumption",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "Cores",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "Series",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "DimensionsId",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "SizeFormat",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "EnergyEfficiency",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "Purpose",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "RadiatorSize",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "SocketId",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "SoundLevel",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "GPU_Consumption",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "GPU_Frequency",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "Memory",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "MemoryType",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "EnergyConsumption",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "MemorySocket",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "Motherboard_MemoryType",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "ProccessorSocket",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "Motherboard_SocketId",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "PSU_DimensionsId",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "Efficiency",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "Power",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "PSU_SoundLevel",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "PSU_Type",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "RAM_Frequency",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "MemorySize",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "ModuleCount",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "RAM_Type",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "Storage_Speed",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "Storage_Type",
                table: "Part");

            migrationBuilder.RenameTable(
                name: "Part",
                newName: "Storage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Storage",
                table: "Storage",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Case",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DimensionsId = table.Column<int>(type: "int", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    SizeFormat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Cooler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnergyEfficiency = table.Column<int>(type: "int", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RadiatorSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    SocketId = table.Column<int>(type: "int", nullable: true),
                    SoundLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Speed = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Cpu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Consumption = table.Column<int>(type: "int", nullable: false),
                    Cores = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Series = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cpu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GPU",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Consumption = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Memory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemoryType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPU", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motherboard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnergyConsumption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemorySocket = table.Column<int>(type: "int", nullable: false),
                    MemoryType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ProccessorSocket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    SocketId = table.Column<int>(type: "int", nullable: true)
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
                name: "PSU",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DimensionsId = table.Column<int>(type: "int", nullable: true),
                    Efficiency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Power = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    SoundLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSU", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PSU_Dimensions_DimensionsId",
                        column: x => x.DimensionsId,
                        principalTable: "Dimensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RAM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemorySize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAM", x => x.Id);
                });

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
                name: "IX_PSU_DimensionsId",
                table: "PSU",
                column: "DimensionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Build_Case_CaseId",
                table: "Build",
                column: "CaseId",
                principalTable: "Case",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Build_Cooler_CoolerId",
                table: "Build",
                column: "CoolerId",
                principalTable: "Cooler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Build_Cpu_CpuId",
                table: "Build",
                column: "CpuId",
                principalTable: "Cpu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Build_GPU_GpuId",
                table: "Build",
                column: "GpuId",
                principalTable: "GPU",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Build_Motherboard_MotherboardId",
                table: "Build",
                column: "MotherboardId",
                principalTable: "Motherboard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Build_PSU_PsuId",
                table: "Build",
                column: "PsuId",
                principalTable: "PSU",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Build_RAM_RAMId",
                table: "Build",
                column: "RAMId",
                principalTable: "RAM",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Build_Storage_StorageId",
                table: "Build",
                column: "StorageId",
                principalTable: "Storage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
