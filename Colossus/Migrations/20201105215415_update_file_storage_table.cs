using Microsoft.EntityFrameworkCore.Migrations;

namespace Colossus.Migrations
{
    public partial class update_file_storage_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "FileStoreages");

            migrationBuilder.AddColumn<string>(
                name: "ParentFolderName",
                table: "FileStoreages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentFolderName",
                table: "FileStoreages");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "FileStoreages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
