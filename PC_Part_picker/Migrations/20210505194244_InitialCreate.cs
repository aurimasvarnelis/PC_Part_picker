using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_Part_picker.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Build", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Part",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    BuildId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Cores = table.Column<int>(nullable: true),
                    Frequency = table.Column<string>(nullable: true),
                    Series = table.Column<string>(nullable: true),
                    Consumption = table.Column<int>(nullable: true),
                    Memory = table.Column<string>(nullable: true),
                    GPU_Frequency = table.Column<string>(nullable: true),
                    MemoryType = table.Column<string>(nullable: true),
                    GPU_Consumption = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Part", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Part_Build_BuildId",
                        column: x => x.BuildId,
                        principalTable: "Build",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Part_BuildId",
                table: "Part",
                column: "BuildId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Part");

            migrationBuilder.DropTable(
                name: "Build");
        }
    }
}
