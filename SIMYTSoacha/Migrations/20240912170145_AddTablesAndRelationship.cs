using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIMYTSoacha.Migrations
{
    /// <inheritdoc />
    public partial class AddTablesAndRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_Requests_RequestsRequestId",
                table: "Procedures");

            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_States_StatesStateId",
                table: "Procedures");

            migrationBuilder.DropIndex(
                name: "IX_Procedures_RequestsRequestId",
                table: "Procedures");

            migrationBuilder.DropIndex(
                name: "IX_Procedures_StatesStateId",
                table: "Procedures");

            migrationBuilder.DropColumn(
                name: "RequestsRequestId",
                table: "Procedures");

            migrationBuilder.DropColumn(
                name: "StatesStateId",
                table: "Procedures");

            migrationBuilder.CreateTable(
                name: "TypesVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tvehicle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesVehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrafficLicenses",
                columns: table => new
                {
                    TlicensesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plate = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    VstatesId = table.Column<int>(type: "int", nullable: false),
                    TserviceId = table.Column<int>(type: "int", nullable: false),
                    TvehicleId = table.Column<int>(type: "int", nullable: false),
                    ProcedureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrafficLicenses", x => x.TlicensesId);
                    table.ForeignKey(
                        name: "FK_TrafficLicenses_Procedures_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedures",
                        principalColumn: "ProcedureId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrafficLicenses_States_VstatesId",
                        column: x => x.VstatesId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrafficLicenses_TypesServices_TserviceId",
                        column: x => x.TserviceId,
                        principalTable: "TypesServices",
                        principalColumn: "TservicesId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrafficLicenses_TypesVehicles_TvehicleId",
                        column: x => x.TvehicleId,
                        principalTable: "TypesVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_RequestId",
                table: "Procedures",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_StateId",
                table: "Procedures",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_TrafficLicenses_ProcedureId",
                table: "TrafficLicenses",
                column: "ProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_TrafficLicenses_TserviceId",
                table: "TrafficLicenses",
                column: "TserviceId");

            migrationBuilder.CreateIndex(
                name: "IX_TrafficLicenses_TvehicleId",
                table: "TrafficLicenses",
                column: "TvehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_TrafficLicenses_VstatesId",
                table: "TrafficLicenses",
                column: "VstatesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_Requests_RequestId",
                table: "Procedures",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_States_StateId",
                table: "Procedures",
                column: "StateId",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_Requests_RequestId",
                table: "Procedures");

            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_States_StateId",
                table: "Procedures");

            migrationBuilder.DropTable(
                name: "TrafficLicenses");

            migrationBuilder.DropTable(
                name: "TypesVehicles");

            migrationBuilder.DropIndex(
                name: "IX_Procedures_RequestId",
                table: "Procedures");

            migrationBuilder.DropIndex(
                name: "IX_Procedures_StateId",
                table: "Procedures");

            migrationBuilder.AddColumn<int>(
                name: "RequestsRequestId",
                table: "Procedures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatesStateId",
                table: "Procedures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_RequestsRequestId",
                table: "Procedures",
                column: "RequestsRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_StatesStateId",
                table: "Procedures",
                column: "StatesStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_Requests_RequestsRequestId",
                table: "Procedures",
                column: "RequestsRequestId",
                principalTable: "Requests",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_States_StatesStateId",
                table: "Procedures",
                column: "StatesStateId",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
