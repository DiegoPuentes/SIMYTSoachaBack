using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIMYTSoacha.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentsTypes",
                columns: table => new
                {
                    DtypesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dtype = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentsTypes", x => x.DtypesId);
                });

            migrationBuilder.CreateTable(
                name: "ExpeditionsCenters",
                columns: table => new
                {
                    EcenterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ecenter = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpeditionsCenters", x => x.EcenterId);
                });

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    HistorieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DtypeId = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    DateBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UtypeId = table.Column<int>(type: "int", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.HistorieId);
                });

            migrationBuilder.CreateTable(
                name: "Infractions",
                columns: table => new
                {
                    InfractionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InfractionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infractions", x => x.InfractionId);
                });

            migrationBuilder.CreateTable(
                name: "Lines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mimpositions",
                columns: table => new
                {
                    MimpositionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MimpositionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mimpositions", x => x.MimpositionId);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NModel = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Pid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Permission = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Pid);
                });

            migrationBuilder.CreateTable(
                name: "Restrictions",
                columns: table => new
                {
                    RestrictionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestrictionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restrictions", x => x.RestrictionId);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatesName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "TypesContacts",
                columns: table => new
                {
                    TcontactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dtype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesContacts", x => x.TcontactId);
                });

            migrationBuilder.CreateTable(
                name: "TypesServices",
                columns: table => new
                {
                    TservicesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TservicesName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesServices", x => x.TservicesId);
                });

            migrationBuilder.CreateTable(
                name: "TypesVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tvehicle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesVehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersTypes",
                columns: table => new
                {
                    UtypesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtypesName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersTypes", x => x.UtypesId);
                });

            migrationBuilder.CreateTable(
                name: "ModelXLine",
                columns: table => new
                {
                    LineNumberId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ModelXLine_Lines_LineNumberId",
                        column: x => x.LineNumberId,
                        principalTable: "Lines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ModelXLine_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PeopleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Names = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lnames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtypeId = table.Column<int>(type: "int", nullable: false),
                    Ndocument = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PeopleId);
                    table.ForeignKey(
                        name: "FK_People_DocumentsTypes_DtypeId",
                        column: x => x.DtypeId,
                        principalTable: "DocumentsTypes",
                        principalColumn: "DtypesId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_People_UsersTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UsersTypes",
                        principalColumn: "UtypesId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UsersXPermissions",
                columns: table => new
                {
                    UtypeId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_UsersXPermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Pid",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UsersXPermissions_UsersTypes_UtypeId",
                        column: x => x.UtypeId,
                        principalTable: "UsersTypes",
                        principalColumn: "UtypesId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TcontactId = table.Column<int>(type: "int", nullable: false),
                    PeopleId = table.Column<int>(type: "int", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contacts_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "PeopleId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Contacts_TypesContacts_TcontactId",
                        column: x => x.TcontactId,
                        principalTable: "TypesContacts",
                        principalColumn: "TcontactId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeopleId = table.Column<int>(type: "int", nullable: false),
                    Request = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OfficerId = table.Column<int>(type: "int", nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_Requests_People_OfficerId",
                        column: x => x.OfficerId,
                        principalTable: "People",
                        principalColumn: "PeopleId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Requests_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "PeopleId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    Nmotor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeopleId = table.Column<int>(type: "int", nullable: false),
                    Echasis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Vehicles_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "PeopleId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Procedures",
                columns: table => new
                {
                    ProcedureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Procedure = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedures", x => x.ProcedureId);
                    table.ForeignKey(
                        name: "FK_Procedures_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Procedures_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DriverLicenses",
                columns: table => new
                {
                    DriverLicenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nlicense = table.Column<int>(type: "int", nullable: false),
                    EcenterId = table.Column<int>(type: "int", nullable: false),
                    DateIssue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    RestrictionId = table.Column<int>(type: "int", nullable: false),
                    ProcedureId = table.Column<int>(type: "int", nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverLicenses", x => x.DriverLicenseId);
                    table.ForeignKey(
                        name: "FK_DriverLicenses_ExpeditionsCenters_EcenterId",
                        column: x => x.EcenterId,
                        principalTable: "ExpeditionsCenters",
                        principalColumn: "EcenterId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DriverLicenses_Procedures_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedures",
                        principalColumn: "ProcedureId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DriverLicenses_Restrictions_RestrictionId",
                        column: x => x.RestrictionId,
                        principalTable: "Restrictions",
                        principalColumn: "RestrictionId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DriverLicenses_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Fines",
                columns: table => new
                {
                    FinesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InfractionId = table.Column<int>(type: "int", nullable: false),
                    MimpositionId = table.Column<int>(type: "int", nullable: false),
                    ProcedureId = table.Column<int>(type: "int", nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fines", x => x.FinesId);
                    table.ForeignKey(
                        name: "FK_Fines_Infractions_InfractionId",
                        column: x => x.InfractionId,
                        principalTable: "Infractions",
                        principalColumn: "InfractionId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Fines_Mimpositions_MimpositionId",
                        column: x => x.MimpositionId,
                        principalTable: "Mimpositions",
                        principalColumn: "MimpositionId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Fines_Procedures_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedures",
                        principalColumn: "ProcedureId",
                        onDelete: ReferentialAction.NoAction);
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
                    ProcedureId = table.Column<int>(type: "int", nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
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
                name: "IX_Contacts_PeopleId",
                table: "Contacts",
                column: "PeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_TcontactId",
                table: "Contacts",
                column: "TcontactId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverLicenses_EcenterId",
                table: "DriverLicenses",
                column: "EcenterId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverLicenses_ProcedureId",
                table: "DriverLicenses",
                column: "ProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverLicenses_RestrictionId",
                table: "DriverLicenses",
                column: "RestrictionId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverLicenses_StateId",
                table: "DriverLicenses",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Fines_InfractionId",
                table: "Fines",
                column: "InfractionId");

            migrationBuilder.CreateIndex(
                name: "IX_Fines_MimpositionId",
                table: "Fines",
                column: "MimpositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Fines_ProcedureId",
                table: "Fines",
                column: "ProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelXLine_LineNumberId",
                table: "ModelXLine",
                column: "LineNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelXLine_ModelId",
                table: "ModelXLine",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_People_DtypeId",
                table: "People",
                column: "DtypeId");

            migrationBuilder.CreateIndex(
                name: "IX_People_UserTypeId",
                table: "People",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_RequestId",
                table: "Procedures",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_StateId",
                table: "Procedures",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_OfficerId",
                table: "Requests",
                column: "OfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_PeopleId",
                table: "Requests",
                column: "PeopleId");

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

            migrationBuilder.CreateIndex(
                name: "IX_UsersXPermissions_PermissionId",
                table: "UsersXPermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersXPermissions_UtypeId",
                table: "UsersXPermissions",
                column: "UtypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ModelId",
                table: "Vehicles",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_PeopleId",
                table: "Vehicles",
                column: "PeopleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "DriverLicenses");

            migrationBuilder.DropTable(
                name: "Fines");

            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "ModelXLine");

            migrationBuilder.DropTable(
                name: "TrafficLicenses");

            migrationBuilder.DropTable(
                name: "UsersXPermissions");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "TypesContacts");

            migrationBuilder.DropTable(
                name: "ExpeditionsCenters");

            migrationBuilder.DropTable(
                name: "Restrictions");

            migrationBuilder.DropTable(
                name: "Infractions");

            migrationBuilder.DropTable(
                name: "Mimpositions");

            migrationBuilder.DropTable(
                name: "Lines");

            migrationBuilder.DropTable(
                name: "Procedures");

            migrationBuilder.DropTable(
                name: "TypesServices");

            migrationBuilder.DropTable(
                name: "TypesVehicles");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "DocumentsTypes");

            migrationBuilder.DropTable(
                name: "UsersTypes");
        }
    }
}
