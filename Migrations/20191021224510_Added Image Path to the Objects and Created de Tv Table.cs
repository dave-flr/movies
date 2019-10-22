using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace movies.Migrations
{
    public partial class AddedImagePathtotheObjectsandCreateddeTvTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Movies");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Movies",
                maxLength: 900,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TvId",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tv",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Year = table.Column<string>(maxLength: 15, nullable: false),
                    Overview = table.Column<string>(maxLength: 900, nullable: false),
                    Rating = table.Column<int>(nullable: false, defaultValue: 0),
                    ImagePath = table.Column<string>(maxLength: 900, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tv", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TvId",
                table: "Comments",
                column: "TvId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tv_TvId",
                table: "Comments",
                column: "TvId",
                principalTable: "Tv",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tv_TvId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "Tv");

            migrationBuilder.DropIndex(
                name: "IX_Comments_TvId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "TvId",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Movies",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }
    }
}
