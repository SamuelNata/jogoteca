﻿// <auto-generated />
using System;
using Jogoteca.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Jogoteca.Web.Migrations
{
    [DbContext(typeof(JogotecaDbContext))]
    [Migration("20201102141747_OwnershipRemodeling")]
    partial class OwnershipRemodeling
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Jogoteca.Models.Entities.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(150)")
                        .HasMaxLength(150);

                    b.Property<short?>("Year")
                        .HasColumnName("year")
                        .HasColumnType("smallint");

                    b.HasKey("Id")
                        .HasName("pk_games");

                    b.ToTable("games");
                });

            modelBuilder.Entity("Jogoteca.Models.Entities.GameBorrowing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("GameBorrowerId")
                        .HasColumnName("game_borrower_id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("GameOwnershipId")
                        .HasColumnName("game_ownership_id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("PredictedEndDate")
                        .HasColumnName("predicted_end_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("RealEndDate")
                        .HasColumnName("real_end_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("StartDate")
                        .HasColumnName("start_date")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id")
                        .HasName("pk_game_borrowings");

                    b.HasIndex("GameBorrowerId")
                        .HasName("ix_game_borrowings_game_borrower_id");

                    b.HasIndex("GameOwnershipId")
                        .HasName("ix_game_borrowings_game_ownership_id");

                    b.ToTable("game_borrowings");
                });

            modelBuilder.Entity("Jogoteca.Models.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnName("access_failed_count")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnName("concurrency_stamp")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnName("email_confirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnName("lockout_enabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnName("lockout_end")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("NormalizedEmail")
                        .HasColumnName("normalized_email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnName("normalized_user_name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnName("password_hash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("phone_number")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnName("phone_number_confirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnName("security_stamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnName("two_factor_enabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnName("user_name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Jogoteca.Models.Entities.UserGame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("GameId")
                        .HasColumnName("game_id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id")
                        .HasName("pk_user_games");

                    b.HasIndex("GameId")
                        .HasName("ix_user_games_game_id");

                    b.HasIndex("UserId")
                        .HasName("ix_user_games_user_id");

                    b.ToTable("user_games");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnName("concurrency_stamp")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnName("normalized_name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id")
                        .HasName("pk_roles");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnName("claim_type")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnName("claim_value")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnName("role_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id")
                        .HasName("pk_role_claims");

                    b.HasIndex("RoleId")
                        .HasName("ix_role_claims_role_id");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnName("claim_type")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnName("claim_value")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id")
                        .HasName("pk_user_claims");

                    b.HasIndex("UserId")
                        .HasName("ix_user_claims_user_id");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnName("login_provider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnName("provider_key")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnName("provider_display_name")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("pk_user_logins");

                    b.HasIndex("UserId")
                        .HasName("ix_user_logins_user_id");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnName("role_id")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId")
                        .HasName("pk_user_roles");

                    b.HasIndex("RoleId")
                        .HasName("ix_user_roles_role_id");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnName("login_provider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnName("value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("pk_user_tokens");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Jogoteca.Models.Entities.GameBorrowing", b =>
                {
                    b.HasOne("Jogoteca.Models.Entities.User", "GameBorrower")
                        .WithMany()
                        .HasForeignKey("GameBorrowerId")
                        .HasConstraintName("fk_game_borrowings_users_game_borrower_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Jogoteca.Models.Entities.UserGame", "GameOwnership")
                        .WithMany("GameBorrowings")
                        .HasForeignKey("GameOwnershipId")
                        .HasConstraintName("fk_game_borrowings_user_games_game_ownership_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Jogoteca.Models.Entities.UserGame", b =>
                {
                    b.HasOne("Jogoteca.Models.Entities.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .HasConstraintName("fk_user_games_games_game_id");

                    b.HasOne("Jogoteca.Models.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_games_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_role_claims_asp_net_roles_identity_role_guid_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Jogoteca.Models.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_claims_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Jogoteca.Models.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_logins_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_user_roles_asp_net_roles_identity_role_guid_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Jogoteca.Models.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_roles_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Jogoteca.Models.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_tokens_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}