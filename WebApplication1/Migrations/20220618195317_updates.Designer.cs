﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.testRepo;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220618195317_updates")]
    partial class updates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.Member", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("roleID")
                        .HasColumnType("int");

                    b.HasKey("userId");

                    b.HasIndex("roleID");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("WebApplication1.Models.Movies", b =>
                {
                    b.Property<int>("movieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("movieCategoryID")
                        .HasColumnType("int");

                    b.Property<int>("movieGuide")
                        .HasColumnType("int");

                    b.Property<string>("movieName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("moviePoster")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("movieRating")
                        .HasColumnType("real");

                    b.Property<DateTime>("movieReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("movieStory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("movieTrailer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("subMovieCategoryID")
                        .HasColumnType("int");

                    b.HasKey("movieID");

                    b.HasIndex("movieCategoryID");

                    b.HasIndex("subMovieCategoryID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("WebApplication1.Models.MoviesCategories", b =>
                {
                    b.Property<int>("categoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("categoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("categoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("WebApplication1.Models.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("WebApplication1.Models.SubMoviesCategories", b =>
                {
                    b.Property<int>("subCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("subCategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("subCategoryID");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("WebApplication1.Models.Member", b =>
                {
                    b.HasOne("WebApplication1.Models.Role", "role")
                        .WithMany("Members")
                        .HasForeignKey("roleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("role");
                });

            modelBuilder.Entity("WebApplication1.Models.Movies", b =>
                {
                    b.HasOne("WebApplication1.Models.MoviesCategories", "movieGenres")
                        .WithMany("Movies")
                        .HasForeignKey("movieCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.SubMoviesCategories", "subMovieGenres")
                        .WithMany("Movies")
                        .HasForeignKey("subMovieCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("movieGenres");

                    b.Navigation("subMovieGenres");
                });

            modelBuilder.Entity("WebApplication1.Models.MoviesCategories", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("WebApplication1.Models.Role", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("WebApplication1.Models.SubMoviesCategories", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}