﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace movies.Migrations
{
    public partial class AddeddateandhourfieldtoCommentstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Comments",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Comments");
        }
    }
}
