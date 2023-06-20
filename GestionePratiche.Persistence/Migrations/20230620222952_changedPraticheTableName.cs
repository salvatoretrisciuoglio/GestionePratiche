using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionePratiche.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changedPraticheTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pratiche",
                table: "Pratiche");

            migrationBuilder.RenameTable(
                name: "Pratiche",
                newName: "Pratica");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pratica",
                table: "Pratica",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pratica",
                table: "Pratica");

            migrationBuilder.RenameTable(
                name: "Pratica",
                newName: "Pratiche");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pratiche",
                table: "Pratiche",
                column: "Id");
        }
    }
}
