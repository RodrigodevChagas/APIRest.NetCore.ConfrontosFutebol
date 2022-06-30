using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIFutebol.Migrations
{
    public partial class CriandoTabelaFutebol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Confrontos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Campeonato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Times = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estadio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicoPresente = table.Column<int>(type: "int", nullable: false),
                    ChutesAGol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confrontos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Confrontos");
        }
    }
}
