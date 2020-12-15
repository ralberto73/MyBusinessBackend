using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBusiness.Core.Data.Migrations
{
    public partial class CreateIdentitySchema01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "EmailConfirmed",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FullName",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Group",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Picture",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Group",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<bool>(
                name: "EmailConfirmed",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
