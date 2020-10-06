using Microsoft.EntityFrameworkCore.Migrations;

namespace EquipmentMngr.Data.Migrations
{
    public partial class NewStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Equipment_EquipmentId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_EquipmentId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "Unassigned",
                table: "Assignments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Unassigned",
                table: "Assignments",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_EquipmentId",
                table: "Assignments",
                column: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Equipment_EquipmentId",
                table: "Assignments",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
