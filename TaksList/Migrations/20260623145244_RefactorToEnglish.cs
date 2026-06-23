using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaksList.Migrations
{
    /// <inheritdoc />
    public partial class RefactorToEnglish : Migration
    {
        /// <inheritdoc />
     
           protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "TarefaAgendas",
                newName: "ScheduledTasks");

            migrationBuilder.RenameTable(
                name: "TarefaDiarias",
                newName: "RecurringTasks");

            migrationBuilder.RenameColumn(
                name: "previsaoConclusao",
                table: "ScheduledTasks",
                newName: "DueDate");
        }
        

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DueDate",
                table: "ScheduledTasks",
                newName: "previsaoConclusao");

            migrationBuilder.RenameTable(
                name: "ScheduledTasks",
                newName: "TarefaAgendas");

            migrationBuilder.RenameTable(
                name: "RecurringTasks",
                newName: "TarefaDiarias");
        }
    }
}
