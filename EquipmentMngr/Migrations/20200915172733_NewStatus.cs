using Microsoft.EntityFrameworkCore.Migrations;

namespace EquipmentMngr.Migrations
{
    public partial class NewStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Equipment_EquipmentId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_EquipmentId",
                table: "Assignments");
        }
    }
}
