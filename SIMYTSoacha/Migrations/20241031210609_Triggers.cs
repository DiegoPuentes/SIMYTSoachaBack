using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIMYTSoacha.Migrations
{
    /// <inheritdoc />
    public partial class Triggers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /// <inheritdoc />
            /// Trigger Order
            migrationBuilder.Sql(@"
        CREATE TRIGGER trg_Peoples
        ON People
        AFTER INSERT, UPDATE, DELETE
        AS
        BEGIN
        SET NOCOUNT ON;

        -- Para la inserción
        IF EXISTS(SELECT * FROM inserted)
        INSERT INTO Histories (PeopleId, Fnames, LName, DtypeId, Ndocument, SexId, DateBirth, UtypeId, UserName, Passcode, Isdeleted, ModifyDate, ModifyBy)
        SELECT i.PeopleId, i.Names, i.Lnames, i.DtypeId, i.Ndocument, i.SexId, i.DateBirth, i.UserTypeId, i.UserName, i.Passcodes,0, GETDATE(), 
				CASE
                   WHEN EXISTS(SELECT * FROM deleted) THEN 'UPDATE'
                   ELSE 'INSERT'
                END
        FROM inserted i;


        -- Para la eliminación
        IF EXISTS(SELECT * FROM deleted)
        INSERT INTO Histories (PeopleId, Fnames, LName, DtypeId, Ndocument, SexId, DateBirth, UtypeId, UserName, Passcode, ModifyDate, ModifyBy)
        SELECT d.PeopleId, d.Names, d.Lnames, d.DtypeId, d.Ndocument, d.SexId, d.DateBirth, d.UserTypeId, d.UserName, d.Passcodes, GETDATE(), 'DELETE'
        FROM deleted d;
        END;
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_Peoples;");
        }
    }
}
