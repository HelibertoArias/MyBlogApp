﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBlogApp.Infraestructure;

namespace MyBlogApp.Infraestructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210127041306_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("MyBlogApp.Core.Entities.Comment", b =>
                {
                    b.Property<ulong>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<ulong>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("CommentId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("MyBlogApp.Core.Entities.Post", b =>
                {
                    b.Property<ulong>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("AutorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("varchar(2000)");

                    b.Property<ulong>("PostStatusId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("PostId");

                    b.HasIndex("AutorId");

                    b.HasIndex("PostStatusId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("MyBlogApp.Core.Entities.PostStatus", b =>
                {
                    b.Property<ulong>("PostStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("PostStatusId");

                    b.ToTable("PostStatus");
                });

            modelBuilder.Entity("MyBlogApp.Core.Entities.Role", b =>
                {
                    b.Property<ulong>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("MyBlogApp.Core.Entities.User", b =>
                {
                    b.Property<ulong>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<ulong>("RoleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyBlogApp.Core.Entities.Comment", b =>
                {
                    b.HasOne("MyBlogApp.Core.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("MyBlogApp.Core.Entities.Post", b =>
                {
                    b.HasOne("MyBlogApp.Core.Entities.User", "Autor")
                        .WithMany("Posts")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBlogApp.Core.Entities.PostStatus", "PostStatus")
                        .WithMany()
                        .HasForeignKey("PostStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("PostStatus");
                });

            modelBuilder.Entity("MyBlogApp.Core.Entities.User", b =>
                {
                    b.HasOne("MyBlogApp.Core.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MyBlogApp.Core.Entities.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("MyBlogApp.Core.Entities.User", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}