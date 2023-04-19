﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviApp.Data;

#nullable disable

namespace MoviApp.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MoviApp.Models.Genre", b =>
                {
                    b.Property<int>("GenerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenerId"));

                    b.Property<string>("Description")
                        .HasMaxLength(400)
                        .HasColumnType("varchar(400)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.HasKey("GenerId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenerId = 1,
                            Description = "The most sold film and emotianl int not recomends for pepole under 14.",
                            Title = "Legal drama"
                        },
                        new
                        {
                            GenerId = 2,
                            Description = "The most sold film and emotianl int not recomends for pepole under 20.",
                            Title = "drama"
                        });
                });

            modelBuilder.Entity("MoviApp.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"));

                    b.Property<string>("Movelink")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<int?>("personGenereId")
                        .HasColumnType("int");

                    b.HasKey("MovieId");

                    b.HasIndex("personGenereId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            Movelink = "https://www.themoviedb.org/movie/19973-comedian",
                            Rating = 5
                        },
                        new
                        {
                            MovieId = 2,
                            Movelink = "https://www.themoviedb.org/movie/79168-drama",
                            Rating = 3
                        });
                });

            modelBuilder.Entity("MoviApp.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("PersonId");

                    b.ToTable("Person");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            Email = "Rezaeskand@gmail.com",
                            Name = "reza"
                        },
                        new
                        {
                            PersonId = 2,
                            Email = "Rasouleskand@gmail.com",
                            Name = "Rasoul"
                        });
                });

            modelBuilder.Entity("MoviApp.Models.PersonGenere", b =>
                {
                    b.Property<int>("personGenereId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("personGenereId"));

                    b.Property<int?>("GenerId")
                        .HasColumnType("int");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("personGenereId");

                    b.HasIndex("GenerId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonGenere");

                    b.HasData(
                        new
                        {
                            personGenereId = 1
                        },
                        new
                        {
                            personGenereId = 2
                        });
                });

            modelBuilder.Entity("MoviApp.Models.Movie", b =>
                {
                    b.HasOne("MoviApp.Models.PersonGenere", "person_GenereId")
                        .WithMany()
                        .HasForeignKey("personGenereId");

                    b.Navigation("person_GenereId");
                });

            modelBuilder.Entity("MoviApp.Models.PersonGenere", b =>
                {
                    b.HasOne("MoviApp.Models.Genre", "FK_GenerId")
                        .WithMany()
                        .HasForeignKey("GenerId");

                    b.HasOne("MoviApp.Models.Person", "FK_persond")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.Navigation("FK_GenerId");

                    b.Navigation("FK_persond");
                });
#pragma warning restore 612, 618
        }
    }
}
