using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIDesafio.Migrations
{
    public partial class DatabaseAtt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDEspera",
                table: "Atendimentos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IDEspera",
                table: "Atendimentos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
