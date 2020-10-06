using Microsoft.EntityFrameworkCore.Migrations;

namespace EquipmentMngr.Data.Migrations
{
    public partial class Equ9pment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Equipment",
                nullable: false,
                defaultValue: 4,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Equipment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 4);
        }
    }
}
