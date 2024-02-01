﻿// <auto-generated />
using System;
using EntertainmentWebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntertainmentWebApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntertainmentWebApi.Model.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("act_gender")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("act_name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Actors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            act_gender = "M",
                            act_name = "Ranbir Kapoor"
                        },
                        new
                        {
                            Id = 2,
                            act_gender = "F",
                            act_name = "Alia Bhatt"
                        },
                        new
                        {
                            Id = 3,
                            act_gender = "F",
                            act_name = "Priyanka Chopra"
                        },
                        new
                        {
                            Id = 4,
                            act_gender = "M",
                            act_name = "Amitabh Bacchan"
                        },
                        new
                        {
                            Id = 5,
                            act_gender = "M",
                            act_name = "Ajay Devagan"
                        },
                        new
                        {
                            Id = 6,
                            act_gender = "M",
                            act_name = "Arshad Warsi"
                        },
                        new
                        {
                            Id = 7,
                            act_gender = "M",
                            act_name = "Sharukh Khan"
                        },
                        new
                        {
                            Id = 8,
                            act_gender = "F",
                            act_name = "Pooja Bhatt"
                        });
                });

            modelBuilder.Entity("EntertainmentWebApi.Model.Director", b =>
                {
                    b.Property<int>("dir_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("dir_id"));

                    b.Property<string>("dir_name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("dir_id");

                    b.ToTable("Directors");

                    b.HasData(
                        new
                        {
                            dir_id = 101,
                            dir_name = "Alia Bhatt"
                        },
                        new
                        {
                            dir_id = 102,
                            dir_name = "Rohit Shetty"
                        },
                        new
                        {
                            dir_id = 103,
                            dir_name = "Pooja Bhatt"
                        },
                        new
                        {
                            dir_id = 104,
                            dir_name = "Sharukh Khan"
                        },
                        new
                        {
                            dir_id = 105,
                            dir_name = "NTR"
                        },
                        new
                        {
                            dir_id = 106,
                            dir_name = "Karan Johar"
                        });
                });

            modelBuilder.Entity("EntertainmentWebApi.Model.Genre", b =>
                {
                    b.Property<int>("genre_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("genre_id"));

                    b.Property<string>("genre_title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("genre_id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            genre_id = 1001,
                            genre_title = "Horror"
                        },
                        new
                        {
                            genre_id = 1002,
                            genre_title = "Sci-Fiction"
                        },
                        new
                        {
                            genre_id = 1003,
                            genre_title = "Comedy"
                        },
                        new
                        {
                            genre_id = 1004,
                            genre_title = "Drama"
                        });
                });

            modelBuilder.Entity("EntertainmentWebApi.Model.Movie", b =>
                {
                    b.Property<int>("mov_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("mov_id"));

                    b.Property<int>("actor_id")
                        .HasColumnType("int");

                    b.Property<int>("director_id")
                        .HasColumnType("int");

                    b.Property<int>("genre_id")
                        .HasColumnType("int");

                    b.Property<string>("mov_lang")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("mov_rel_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("mov_release_country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("mov_title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("mov_year")
                        .HasColumnType("int");

                    b.HasKey("mov_id");

                    b.HasIndex("actor_id");

                    b.HasIndex("director_id");

                    b.HasIndex("genre_id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            mov_id = 801,
                            actor_id = 2,
                            director_id = 101,
                            genre_id = 1002,
                            mov_lang = "PAN India",
                            mov_rel_date = new DateTime(2024, 2, 1, 21, 43, 10, 971, DateTimeKind.Local).AddTicks(1047),
                            mov_release_country = "Worldwide",
                            mov_title = "Brahmastra",
                            mov_year = 2024
                        },
                        new
                        {
                            mov_id = 802,
                            actor_id = 5,
                            director_id = 103,
                            genre_id = 1003,
                            mov_lang = "PAN India",
                            mov_rel_date = new DateTime(2024, 2, 1, 21, 43, 10, 971, DateTimeKind.Local).AddTicks(1059),
                            mov_release_country = "Worldwide",
                            mov_title = "RRR",
                            mov_year = 2024
                        });
                });

            modelBuilder.Entity("EntertainmentWebApi.Model.Review", b =>
                {
                    b.Property<int>("reviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("reviewId"));

                    b.Property<int>("movieId")
                        .HasColumnType("int");

                    b.Property<string>("review_Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("review_Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("reviewId");

                    b.HasIndex("movieId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            reviewId = 201,
                            movieId = 801,
                            review_Text = "Rotten tomatotes",
                            review_Title = "1 star"
                        },
                        new
                        {
                            reviewId = 202,
                            movieId = 801,
                            review_Text = "Very Bad movie",
                            review_Title = "1 star"
                        },
                        new
                        {
                            reviewId = 203,
                            movieId = 801,
                            review_Text = "Fantastic movie",
                            review_Title = "4 star"
                        });
                });

            modelBuilder.Entity("EntertainmentWebApi.Model.Movie", b =>
                {
                    b.HasOne("EntertainmentWebApi.Model.Actor", "Actor")
                        .WithMany("Movies")
                        .HasForeignKey("actor_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntertainmentWebApi.Model.Director", "Director")
                        .WithMany("Movies")
                        .HasForeignKey("director_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntertainmentWebApi.Model.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("genre_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Director");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("EntertainmentWebApi.Model.Review", b =>
                {
                    b.HasOne("EntertainmentWebApi.Model.Movie", "Movies")
                        .WithMany("Reviews")
                        .HasForeignKey("movieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movies");
                });

            modelBuilder.Entity("EntertainmentWebApi.Model.Actor", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("EntertainmentWebApi.Model.Director", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("EntertainmentWebApi.Model.Genre", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("EntertainmentWebApi.Model.Movie", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
