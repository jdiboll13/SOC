﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SOC.Data;
using System;

namespace SOC.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170918172811_CommentsModel_mig")]
    partial class CommentsModel_mig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SOC.Models.AnswersModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<DateTime>("DatePosted");

                    b.Property<int>("QuestionID");

                    b.Property<int?>("QuestionsModelID");

                    b.Property<int>("UserID");

                    b.Property<int?>("UsersModelID");

                    b.Property<int>("VoteCount");

                    b.HasKey("ID");

                    b.HasIndex("QuestionsModelID");

                    b.HasIndex("UsersModelID");

                    b.ToTable("AnswersModel");
                });

            modelBuilder.Entity("SOC.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SOC.Models.CommentsModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnswerID");

                    b.Property<int?>("AnswersModelID");

                    b.Property<string>("Body");

                    b.Property<DateTime>("DatePosted");

                    b.Property<int>("QuestionID");

                    b.Property<int?>("QuestionsModelID");

                    b.Property<int>("UserID");

                    b.Property<int?>("UsersModelID");

                    b.HasKey("ID");

                    b.HasIndex("AnswersModelID");

                    b.HasIndex("QuestionsModelID");

                    b.HasIndex("UsersModelID");

                    b.ToTable("CommentsModel");
                });

            modelBuilder.Entity("SOC.Models.QTiesModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("QuestionID");

                    b.Property<int?>("QuestionsModelID");

                    b.Property<int>("TagID");

                    b.Property<int?>("TagsModelID");

                    b.HasKey("ID");

                    b.HasIndex("QuestionsModelID");

                    b.HasIndex("TagsModelID");

                    b.ToTable("QTiesModel");
                });

            modelBuilder.Entity("SOC.Models.QuestionsModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<DateTime>("DatePosted");

                    b.Property<string>("Title");

                    b.Property<int>("UserId");

                    b.Property<int?>("UsersModelID");

                    b.Property<int>("VoteCount");

                    b.HasKey("ID");

                    b.HasIndex("UsersModelID");

                    b.ToTable("QuestionsModel");
                });

            modelBuilder.Entity("SOC.Models.TagsModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TagName");

                    b.HasKey("ID");

                    b.ToTable("TagsModel");
                });

            modelBuilder.Entity("SOC.Models.UsersModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("BitForMod");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("UserName");

                    b.HasKey("ID");

                    b.ToTable("UsersModel");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SOC.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SOC.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SOC.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SOC.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SOC.Models.AnswersModel", b =>
                {
                    b.HasOne("SOC.Models.QuestionsModel", "QuestionsModel")
                        .WithMany()
                        .HasForeignKey("QuestionsModelID");

                    b.HasOne("SOC.Models.UsersModel", "UsersModel")
                        .WithMany()
                        .HasForeignKey("UsersModelID");
                });

            modelBuilder.Entity("SOC.Models.CommentsModel", b =>
                {
                    b.HasOne("SOC.Models.AnswersModel", "AnswersModel")
                        .WithMany()
                        .HasForeignKey("AnswersModelID");

                    b.HasOne("SOC.Models.QuestionsModel", "QuestionsModel")
                        .WithMany()
                        .HasForeignKey("QuestionsModelID");

                    b.HasOne("SOC.Models.UsersModel", "UsersModel")
                        .WithMany()
                        .HasForeignKey("UsersModelID");
                });

            modelBuilder.Entity("SOC.Models.QTiesModel", b =>
                {
                    b.HasOne("SOC.Models.QuestionsModel", "QuestionsModel")
                        .WithMany()
                        .HasForeignKey("QuestionsModelID");

                    b.HasOne("SOC.Models.TagsModel", "TagsModel")
                        .WithMany()
                        .HasForeignKey("TagsModelID");
                });

            modelBuilder.Entity("SOC.Models.QuestionsModel", b =>
                {
                    b.HasOne("SOC.Models.UsersModel", "UsersModel")
                        .WithMany()
                        .HasForeignKey("UsersModelID");
                });
#pragma warning restore 612, 618
        }
    }
}
