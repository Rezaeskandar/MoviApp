﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviApp.Data;

#nullable disable

namespace MoviApp.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20230428000706_AddedNewLinkCollom")]
    partial class AddedNewLinkCollom
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MoviApp.Enteties.MovieGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FkGenreId")
                        .HasColumnType("int");

                    b.Property<int>("FkMovieId")
                        .HasColumnType("int");

                    b.Property<int?>("GenresGenerId")
                        .HasColumnType("int");

                    b.Property<int?>("MoviesMovieId")
                        .HasColumnType("int");

                    b.Property<string>("NewLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GenresGenerId");

                    b.HasIndex("MoviesMovieId");

                    b.ToTable("MovieGenres");
                });

            modelBuilder.Entity("MoviApp.Enteties.Rating", b =>
                {
                    b.Property<int>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RatingId"));

                    b.Property<int?>("FkMovieId")
                        .HasColumnType("int");

                    b.Property<int?>("Fk_PersonId")
                        .HasColumnType("int");

                    b.Property<int?>("MoviesMovieId")
                        .HasColumnType("int");

                    b.Property<int?>("PersonsPersonId")
                        .HasColumnType("int");

                    b.Property<int?>("Ratings")
                        .HasColumnType("int");

                    b.HasKey("RatingId");

                    b.HasIndex("MoviesMovieId");

                    b.HasIndex("PersonsPersonId");

                    b.ToTable("Ratings");
                });

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
                });

            modelBuilder.Entity("MoviApp.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"));

                    b.Property<int>("FkPersonId")
                        .HasColumnType("int");

                    b.Property<string>("Movelink")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("personsPersonId")
                        .HasColumnType("int");

                    b.HasKey("MovieId");

                    b.HasIndex("personsPersonId");

                    b.ToTable("Movies");
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
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("MoviApp.Models.PersonGenere", b =>
                {
                    b.Property<int>("personGenereId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("personGenereId"));

                    b.Property<int>("FK_GenreId")
                        .HasColumnType("int");

                    b.Property<int>("FK_personId")
                        .HasColumnType("int");

                    b.Property<int?>("GenresGenerId")
                        .HasColumnType("int");

                    b.Property<string>("NewLinks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonsPersonId")
                        .HasColumnType("int");

                    b.HasKey("personGenereId");

                    b.HasIndex("GenresGenerId");

                    b.HasIndex("PersonsPersonId");

                    b.ToTable("PersonGenere");
                });

            modelBuilder.Entity("MoviApp.Enteties.MovieGenre", b =>
                {
                    b.HasOne("MoviApp.Models.Genre", "Genres")
                        .WithMany("MovieGenres")
                        .HasForeignKey("GenresGenerId");

                    b.HasOne("MoviApp.Models.Movie", "Movies")
                        .WithMany("MovieGenre")
                        .HasForeignKey("MoviesMovieId");

                    b.Navigation("Genres");

                    b.Navigation("Movies");
                });

            modelBuilder.Entity("MoviApp.Enteties.Rating", b =>
                {
                    b.HasOne("MoviApp.Models.Movie", "Movies")
                        .WithMany("Rating")
                        .HasForeignKey("MoviesMovieId");

                    b.HasOne("MoviApp.Models.Person", "Persons")
                        .WithMany("Ratings")
                        .HasForeignKey("PersonsPersonId");

                    b.Navigation("Movies");

                    b.Navigation("Persons");
                });

            modelBuilder.Entity("MoviApp.Models.Movie", b =>
                {
                    b.HasOne("MoviApp.Models.Person", "persons")
                        .WithMany("Movies")
                        .HasForeignKey("personsPersonId");

                    b.Navigation("persons");
                });

            modelBuilder.Entity("MoviApp.Models.PersonGenere", b =>
                {
                    b.HasOne("MoviApp.Models.Genre", "Genres")
                        .WithMany("PersonGenere")
                        .HasForeignKey("GenresGenerId");

                    b.HasOne("MoviApp.Models.Person", "Persons")
                        .WithMany("PersonGenere")
                        .HasForeignKey("PersonsPersonId");

                    b.Navigation("Genres");

                    b.Navigation("Persons");
                });

            modelBuilder.Entity("MoviApp.Models.Genre", b =>
                {
                    b.Navigation("MovieGenres");

                    b.Navigation("PersonGenere");
                });

            modelBuilder.Entity("MoviApp.Models.Movie", b =>
                {
                    b.Navigation("MovieGenre");

                    b.Navigation("Rating");
                });

            modelBuilder.Entity("MoviApp.Models.Person", b =>
                {
                    b.Navigation("Movies");

                    b.Navigation("PersonGenere");

                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
