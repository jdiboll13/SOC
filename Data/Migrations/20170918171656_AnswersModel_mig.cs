using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SOC.Data.Migrations
{
    public partial class AnswersModel_mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "TagsModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TagName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagsModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UsersModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BitForMod = table.Column<bool>(type: "INTEGER", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "QuestionsModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Body = table.Column<string>(type: "TEXT", nullable: true),
                    DatePosted = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersModelID = table.Column<int>(type: "INTEGER", nullable: true),
                    VoteCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionsModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QuestionsModel_UsersModel_UsersModelID",
                        column: x => x.UsersModelID,
                        principalTable: "UsersModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnswersModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Body = table.Column<string>(type: "TEXT", nullable: true),
                    DatePosted = table.Column<DateTime>(type: "TEXT", nullable: false),
                    QuestionID = table.Column<int>(type: "INTEGER", nullable: false),
                    QuestionsModelID = table.Column<int>(type: "INTEGER", nullable: true),
                    UserID = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersModelID = table.Column<int>(type: "INTEGER", nullable: true),
                    VoteCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswersModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AnswersModel_QuestionsModel_QuestionsModelID",
                        column: x => x.QuestionsModelID,
                        principalTable: "QuestionsModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswersModel_UsersModel_UsersModelID",
                        column: x => x.UsersModelID,
                        principalTable: "UsersModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QTiesModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuestionID = table.Column<int>(type: "INTEGER", nullable: false),
                    QuestionsModelID = table.Column<int>(type: "INTEGER", nullable: true),
                    TagID = table.Column<int>(type: "INTEGER", nullable: false),
                    TagsModelID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QTiesModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QTiesModel_QuestionsModel_QuestionsModelID",
                        column: x => x.QuestionsModelID,
                        principalTable: "QuestionsModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QTiesModel_TagsModel_TagsModelID",
                        column: x => x.TagsModelID,
                        principalTable: "TagsModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommentsModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnswerID = table.Column<int>(type: "INTEGER", nullable: false),
                    AnswersModelID = table.Column<int>(type: "INTEGER", nullable: true),
                    Body = table.Column<string>(type: "TEXT", nullable: true),
                    DatePosted = table.Column<DateTime>(type: "TEXT", nullable: false),
                    QuestionID = table.Column<int>(type: "INTEGER", nullable: false),
                    QuestionsModelID = table.Column<int>(type: "INTEGER", nullable: true),
                    UserID = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersModelID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentsModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CommentsModel_AnswersModel_AnswersModelID",
                        column: x => x.AnswersModelID,
                        principalTable: "AnswersModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentsModel_QuestionsModel_QuestionsModelID",
                        column: x => x.QuestionsModelID,
                        principalTable: "QuestionsModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentsModel_UsersModel_UsersModelID",
                        column: x => x.UsersModelID,
                        principalTable: "UsersModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnswersModel_QuestionsModelID",
                table: "AnswersModel",
                column: "QuestionsModelID");

            migrationBuilder.CreateIndex(
                name: "IX_AnswersModel_UsersModelID",
                table: "AnswersModel",
                column: "UsersModelID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentsModel_AnswersModelID",
                table: "CommentsModel",
                column: "AnswersModelID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentsModel_QuestionsModelID",
                table: "CommentsModel",
                column: "QuestionsModelID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentsModel_UsersModelID",
                table: "CommentsModel",
                column: "UsersModelID");

            migrationBuilder.CreateIndex(
                name: "IX_QTiesModel_QuestionsModelID",
                table: "QTiesModel",
                column: "QuestionsModelID");

            migrationBuilder.CreateIndex(
                name: "IX_QTiesModel_TagsModelID",
                table: "QTiesModel",
                column: "TagsModelID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsModel_UsersModelID",
                table: "QuestionsModel",
                column: "UsersModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CommentsModel");

            migrationBuilder.DropTable(
                name: "QTiesModel");

            migrationBuilder.DropTable(
                name: "AnswersModel");

            migrationBuilder.DropTable(
                name: "TagsModel");

            migrationBuilder.DropTable(
                name: "QuestionsModel");

            migrationBuilder.DropTable(
                name: "UsersModel");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
