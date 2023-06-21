using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionePratiche.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedTimestampForConflicts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Pratica",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "Pratica");
        }
    }
}
