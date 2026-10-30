using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyFlow.Api.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarConcluidaEmTarefa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Concluida",
                table: "Tarefas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Concluida",
                table: "Tarefas");
        }
    }
}
