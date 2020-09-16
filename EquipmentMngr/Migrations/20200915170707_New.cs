using Microsoft.EntityFrameworkCore.Migrations;

namespace EquipmentMngr.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repair_States_StateId",
                table: "Repair");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Repair",
                table: "Repair");

            migrationBuilder.RenameTable(
                name: "Repair",
                newName: "Repairs");

            migrationBuilder.RenameIndex(
                name: "IX_Repair_StateId",
                table: "Repairs",
                newName: "IX_Repairs_StateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Repairs",
                table: "Repairs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_States_StateId",
                table: "Repairs",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_States_StateId",
                table: "Repairs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Repairs",
                table: "Repairs");

            migrationBuilder.RenameTable(
                name: "Repairs",
                newName: "Repair");

            migrationBuilder.RenameIndex(
                name: "IX_Repairs_StateId",
                table: "Repair",
                newName: "IX_Repair_StateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Repair",
                table: "Repair",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Repair_States_StateId",
                table: "Repair",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
