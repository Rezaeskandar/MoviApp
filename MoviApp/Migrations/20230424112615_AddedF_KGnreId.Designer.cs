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
    [Migration("20230424112615_AddedF_KGnreId")]
    partial class AddedF_KGnreId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                });

            modelBuilder.Entity("MoviApp.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"));

                    b.Property<int?>("GenersGenerId")
                        .HasColumnType("int");

                    b.Property<string>("Movelink")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<int?>("personsPersonId")
                        .HasColumnType("int");

                    b.HasKey("MovieId");

                    b.HasIndex("GenersGenerId");

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
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("PersonId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("MoviApp.Models.PersonGenere", b =>
                {
                    b.Property<int>("personGenereId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FK_GenreId")
                        .HasColumnType("int");

                    b.Property<int>("FK_personId")
                        .HasColumnType("int");

                    b.HasKey("personGenereId");

                    b.ToTable("PersonGenere");
                });

            modelBuilder.Entity("MoviApp.Models.Movie", b =>
                {
                    b.HasOne("MoviApp.Models.Genre", "Geners")
                        .WithMany()
                        .HasForeignKey("GenersGenerId");

                    b.HasOne("MoviApp.Models.Person", "persons")
                        .WithMany()
                        .HasForeignKey("personsPersonId");

                    b.Navigation("Geners");

                    b.Navigation("persons");
                });

            modelBuilder.Entity("MoviApp.Models.PersonGenere", b =>
                {
                    b.HasOne("MoviApp.Models.Genre", "FK_Gener")
                        .WithMany("persons")
                        .HasForeignKey("personGenereId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviApp.Models.Person", "FK_person")
                        .WithMany("Genres")
                        .HasForeignKey("personGenereId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FK_Gener");

                    b.Navigation("FK_person");
                });

            modelBuilder.Entity("MoviApp.Models.Genre", b =>
                {
                    b.Navigation("persons");
                });

            modelBuilder.Entity("MoviApp.Models.Person", b =>
                {
                    b.Navigation("Genres");
                });
#pragma warning restore 612, 618
        }
    }
}
