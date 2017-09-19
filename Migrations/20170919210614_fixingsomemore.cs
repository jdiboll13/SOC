using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SOC.Migrations
{
    public partial class fixingsomemore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerID",
                table: "CommentsModel");

            migrationBuilder.DropColumn(
                name: "QuestionID",
                table: "CommentsModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnswerID",
                table: "CommentsModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionID",
                table: "CommentsModel",
                nullable: true);
        }
    }
}
