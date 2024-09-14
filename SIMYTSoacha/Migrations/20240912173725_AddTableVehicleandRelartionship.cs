using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIMYTSoacha.Migrations
{
    /// <inheritdoc />
    public partial class AddTableVehicleandRelartionship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Line",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nline = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Line", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NModel = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelXLine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineNumberId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelXLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelXLine_Line_LineNumberId",
                        column: x => x.LineNumberId,
                        principalTable: "Line",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ModelXLine_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModelXLine_LineNumberId",
                table: "ModelXLine",
                column: "LineNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelXLine_ModelId",
                table: "ModelXLine",
                column: "ModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelXLine");

            migrationBuilder.DropTable(
                name: "Line");

            migrationBuilder.DropTable(
                name: "Models");
        }
    }
}
