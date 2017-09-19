using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SOC.Migrations
{
    public partial class idsfixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "QuestionsModel");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "CommentsModel");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "AnswersModel");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "AnswersModel",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "AnswersModel");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "QuestionsModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "CommentsModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "AnswersModel",
                nullable: true);
        }
    }
}
