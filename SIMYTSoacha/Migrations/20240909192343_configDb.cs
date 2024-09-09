using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIMYTSoacha.Migrations
{
    /// <inheritdoc />
    public partial class configDb : Migration
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
                    Dtype = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
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
                    Ecenter = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Lname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DtypeId = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    DateBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UtypeId = table.Column<int>(type: "int", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    InfractionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infractions", x => x.InfractionId);
                });

            migrationBuilder.CreateTable(
                name: "Mimpositions",
                columns: table => new
                {
                    MimpositionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MimpositionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mimpositions", x => x.MimpositionId);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Pid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Permission = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
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
                    RestrictionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
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
                    StatesName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
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
                    Dtype = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    TservicesName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesServices", x => x.TservicesId);
                });

            migrationBuilder.CreateTable(
                name: "UsersTypes",
                columns: table => new
                {
                    UtypesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtypesName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersTypes", x => x.UtypesId);
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
                    UserTypeXPermission = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PeopleId);
                    table.ForeignKey(
                        name: "FK_People_DocumentsTypes_DtypeId",
                        column: x => x.DtypeId,
                        principalTable: "DocumentsTypes",
                        principalColumn: "DtypesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersXPermissions",
                columns: table => new
                {
                    UpermissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtypeId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    Permission = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersXPermissions", x => x.UpermissionId);
                    table.ForeignKey(
                        name: "FK_UsersXPermissions_Permissions_Permission",
                        column: x => x.Permission,
                        principalTable: "Permissions",
                        principalColumn: "Pid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersXPermissions_UsersTypes_UtypeId",
                        column: x => x.UtypeId,
                        principalTable: "UsersTypes",
                        principalColumn: "UtypesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TcontactId = table.Column<int>(type: "int", nullable: false),
                    TypesContactsTcontactId = table.Column<int>(type: "int", nullable: false),
                    PeopleId = table.Column<int>(type: "int", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contacts_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "PeopleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contacts_TypesContacts_TypesContactsTcontactId",
                        column: x => x.TypesContactsTcontactId,
                        principalTable: "TypesContacts",
                        principalColumn: "TcontactId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    ManagersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeopleId = table.Column<int>(type: "int", nullable: false),
                    UserTypeXPermission = table.Column<int>(type: "int", nullable: false),
                    UsersXPermissionsUpermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.ManagersId);
                    table.ForeignKey(
                        name: "FK_Managers_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "PeopleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Managers_UsersXPermissions_UsersXPermissionsUpermissionId",
                        column: x => x.UsersXPermissionsUpermissionId,
                        principalTable: "UsersXPermissions",
                        principalColumn: "UpermissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeopleId = table.Column<int>(type: "int", nullable: false),
                    Request = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    ManagersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_Requests_Managers_ManagersId",
                        column: x => x.ManagersId,
                        principalTable: "Managers",
                        principalColumn: "ManagersId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "PeopleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Procedures",
                columns: table => new
                {
                    ProcedureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Procedure = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    StatesStateId = table.Column<int>(type: "int", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    RequestsRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedures", x => x.ProcedureId);
                    table.ForeignKey(
                        name: "FK_Procedures_Requests_RequestsRequestId",
                        column: x => x.RequestsRequestId,
                        principalTable: "Requests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Procedures_States_StatesStateId",
                        column: x => x.StatesStateId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriverLicenses",
                columns: table => new
                {
                    DriverLicenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nlicense = table.Column<int>(type: "int", nullable: false),
                    EcenterId = table.Column<int>(type: "int", nullable: false),
                    EcentersEcenterId = table.Column<int>(type: "int", nullable: false),
                    DateIssue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    StatesStateId = table.Column<int>(type: "int", nullable: false),
                    RestrictionId = table.Column<int>(type: "int", nullable: false),
                    RestrictionsRestrictionId = table.Column<int>(type: "int", nullable: false),
                    ProcedureId = table.Column<int>(type: "int", nullable: false),
                    ProceduresProcedureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverLicenses", x => x.DriverLicenseId);
                    table.ForeignKey(
                        name: "FK_DriverLicenses_ExpeditionsCenters_EcentersEcenterId",
                        column: x => x.EcentersEcenterId,
                        principalTable: "ExpeditionsCenters",
                        principalColumn: "EcenterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverLicenses_Procedures_ProceduresProcedureId",
                        column: x => x.ProceduresProcedureId,
                        principalTable: "Procedures",
                        principalColumn: "ProcedureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverLicenses_Restrictions_RestrictionsRestrictionId",
                        column: x => x.RestrictionsRestrictionId,
                        principalTable: "Restrictions",
                        principalColumn: "RestrictionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverLicenses_States_StatesStateId",
                        column: x => x.StatesStateId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fines",
                columns: table => new
                {
                    FinesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InfractionId = table.Column<int>(type: "int", nullable: false),
                    InfractionsInfractionId = table.Column<int>(type: "int", nullable: false),
                    MimpositionId = table.Column<int>(type: "int", nullable: false),
                    MimpositionsMimpositionId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    ManagersId = table.Column<int>(type: "int", nullable: false),
                    ProcedureId = table.Column<int>(type: "int", nullable: false),
                    ProceduresProcedureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fines", x => x.FinesId);
                    table.ForeignKey(
                        name: "FK_Fines_Infractions_InfractionsInfractionId",
                        column: x => x.InfractionsInfractionId,
                        principalTable: "Infractions",
                        principalColumn: "InfractionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fines_Managers_ManagersId",
                        column: x => x.ManagersId,
                        principalTable: "Managers",
                        principalColumn: "ManagersId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fines_Mimpositions_MimpositionsMimpositionId",
                        column: x => x.MimpositionsMimpositionId,
                        principalTable: "Mimpositions",
                        principalColumn: "MimpositionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fines_Procedures_ProceduresProcedureId",
                        column: x => x.ProceduresProcedureId,
                        principalTable: "Procedures",
                        principalColumn: "ProcedureId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrafficLicenses",
                columns: table => new
                {
                    TlicensesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plate = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    VstatesId = table.Column<int>(type: "int", nullable: false),
                    StatesStateId = table.Column<int>(type: "int", nullable: false),
                    TserviceId = table.Column<int>(type: "int", nullable: false),
                    ServicesTservicesId = table.Column<int>(type: "int", nullable: false),
                    TvehicleId = table.Column<int>(type: "int", nullable: false),
                    ProcedureId = table.Column<int>(type: "int", nullable: false),
                    ProceduresProcedureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrafficLicenses", x => x.TlicensesId);
                    table.ForeignKey(
                        name: "FK_TrafficLicenses_Procedures_ProceduresProcedureId",
                        column: x => x.ProceduresProcedureId,
                        principalTable: "Procedures",
                        principalColumn: "ProcedureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrafficLicenses_States_StatesStateId",
                        column: x => x.StatesStateId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrafficLicenses_TypesServices_ServicesTservicesId",
                        column: x => x.ServicesTservicesId,
                        principalTable: "TypesServices",
                        principalColumn: "TservicesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_PeopleId",
                table: "Contacts",
                column: "PeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_TypesContactsTcontactId",
                table: "Contacts",
                column: "TypesContactsTcontactId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverLicenses_EcentersEcenterId",
                table: "DriverLicenses",
                column: "EcentersEcenterId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverLicenses_ProceduresProcedureId",
                table: "DriverLicenses",
                column: "ProceduresProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverLicenses_RestrictionsRestrictionId",
                table: "DriverLicenses",
                column: "RestrictionsRestrictionId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverLicenses_StatesStateId",
                table: "DriverLicenses",
                column: "StatesStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Fines_InfractionsInfractionId",
                table: "Fines",
                column: "InfractionsInfractionId");

            migrationBuilder.CreateIndex(
                name: "IX_Fines_ManagersId",
                table: "Fines",
                column: "ManagersId");

            migrationBuilder.CreateIndex(
                name: "IX_Fines_MimpositionsMimpositionId",
                table: "Fines",
                column: "MimpositionsMimpositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Fines_ProceduresProcedureId",
                table: "Fines",
                column: "ProceduresProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_PeopleId",
                table: "Managers",
                column: "PeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_UsersXPermissionsUpermissionId",
                table: "Managers",
                column: "UsersXPermissionsUpermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_People_DtypeId",
                table: "People",
                column: "DtypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_RequestsRequestId",
                table: "Procedures",
                column: "RequestsRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_StatesStateId",
                table: "Procedures",
                column: "StatesStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ManagersId",
                table: "Requests",
                column: "ManagersId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_PeopleId",
                table: "Requests",
                column: "PeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_TrafficLicenses_ProceduresProcedureId",
                table: "TrafficLicenses",
                column: "ProceduresProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_TrafficLicenses_ServicesTservicesId",
                table: "TrafficLicenses",
                column: "ServicesTservicesId");

            migrationBuilder.CreateIndex(
                name: "IX_TrafficLicenses_StatesStateId",
                table: "TrafficLicenses",
                column: "StatesStateId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersXPermissions_Permission",
                table: "UsersXPermissions",
                column: "Permission");

            migrationBuilder.CreateIndex(
                name: "IX_UsersXPermissions_UtypeId",
                table: "UsersXPermissions",
                column: "UtypeId");
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
                name: "TrafficLicenses");

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
                name: "Procedures");

            migrationBuilder.DropTable(
                name: "TypesServices");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "UsersXPermissions");

            migrationBuilder.DropTable(
                name: "DocumentsTypes");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "UsersTypes");
        }
    }
}
