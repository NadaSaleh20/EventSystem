using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class RelationEventWithUserTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Supervisor",
                table: "Event");

            migrationBuilder.AddColumn<string>(
                name: "SupervisorId",
                table: "Event",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_SupervisorId",
                table: "Event",
                column: "SupervisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_AspNetUsers_SupervisorId",
                table: "Event",
                column: "SupervisorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_AspNetUsers_SupervisorId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_SupervisorId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "SupervisorId",
                table: "Event");

            migrationBuilder.AddColumn<string>(
                name: "Supervisor",
                table: "Event",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
