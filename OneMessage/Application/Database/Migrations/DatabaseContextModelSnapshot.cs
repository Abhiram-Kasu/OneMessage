﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OneMessage.Application.Database;

#nullable disable

namespace OneMessage.Application.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("OneMessage.Application.Models.FriendShip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<int>("FromUserId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("from_user_id");

                    b.Property<int>("ToUserId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("to_user_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_friend_ships");

                    b.HasIndex("FromUserId")
                        .HasDatabaseName("ix_friend_ships_from_user_id");

                    b.HasIndex("Id")
                        .HasDatabaseName("ix_friend_ships_id");

                    b.HasIndex("ToUserId")
                        .HasDatabaseName("ix_friend_ships_to_user_id");

                    b.ToTable("friend_ships", (string)null);
                });

            modelBuilder.Entity("OneMessage.Application.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_roles");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_roles_name");

                    b.ToTable("roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "User"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("OneMessage.Application.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("TEXT")
                        .HasColumnName("email");

                    b.Property<DateTime?>("EmailVerifiedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("email_verified_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("password");

                    b.Property<string>("RememberToken")
                        .HasColumnType("TEXT")
                        .HasColumnName("remember_token");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_users_email");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("OneMessage.Application.Models.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("user_id");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId")
                        .HasName("pk_user_roles");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_user_roles_role_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_user_roles_user_id");

                    b.ToTable("user_roles", (string)null);
                });

            modelBuilder.Entity("OneMessage.Application.Models.FriendShip", b =>
                {
                    b.HasOne("OneMessage.Application.Models.User", "FromUser")
                        .WithMany("FriendShips")
                        .HasForeignKey("FromUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_friend_ships_users_from_user_id");

                    b.HasOne("OneMessage.Application.Models.User", "ToUser")
                        .WithMany()
                        .HasForeignKey("ToUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_friend_ships_users_to_user_id");

                    b.Navigation("FromUser");

                    b.Navigation("ToUser");
                });

            modelBuilder.Entity("OneMessage.Application.Models.UserRole", b =>
                {
                    b.HasOne("OneMessage.Application.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_roles_roles_role_id");

                    b.HasOne("OneMessage.Application.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_roles_users_user_id");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OneMessage.Application.Models.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("OneMessage.Application.Models.User", b =>
                {
                    b.Navigation("FriendShips");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
