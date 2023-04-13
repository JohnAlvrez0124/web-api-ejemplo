using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lengujedeprogramacion.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Maestros",
                table: "Maestros");

            migrationBuilder.RenameTable(
                name: "Maestros",
                newName: "Maestro");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Maestro",
                newName: "Nombre");

            migrationBuilder.AddColumn<int>(
                name: "edad",
                table: "Maestro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Maestro",
                table: "Maestro",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Maestro",
                table: "Maestro");

            migrationBuilder.DropColumn(
                name: "edad",
                table: "Maestro");

            migrationBuilder.RenameTable(
                name: "Maestro",
                newName: "Maestros");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Maestros",
                newName: "nombre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Maestros",
                table: "Maestros",
                column: "id");
        }
    }
}
