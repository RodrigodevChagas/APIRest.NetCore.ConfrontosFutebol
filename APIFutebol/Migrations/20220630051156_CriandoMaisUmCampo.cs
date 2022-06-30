using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIFutebol.Migrations
{
    public partial class CriandoMaisUmCampo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChutesAGol",
                table: "Confrontos",
                newName: "ChutesAGol_Time2");

            migrationBuilder.AddColumn<int>(
                name: "ChutesAGol_Time1",
                table: "Confrontos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChutesAGol_Time1",
                table: "Confrontos");

            migrationBuilder.RenameColumn(
                name: "ChutesAGol_Time2",
                table: "Confrontos",
                newName: "ChutesAGol");
        }
    }
}
