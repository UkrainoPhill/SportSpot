﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SportSpot.Persistence;

#nullable disable

namespace SportSpot.Persistence.Migrations
{
    [DbContext(typeof(SportSpotDbContext))]
    [Migration("20240618135052_fix_user_3")]
    partial class fix_user_3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SportSpot.Logic.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Rating")
                        .HasColumnType("numeric");

                    b.Property<Guid>("SpotId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SpotId");

                    b.HasIndex("Username");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SportSpot.Logic.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CommentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Link")
                        .HasColumnType("text");

                    b.Property<Guid?>("SpotId")
                        .HasColumnType("uuid");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("SpotId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Images");
                });

            modelBuilder.Entity("SportSpot.Logic.Models.Spot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Interests")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Rating")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Spots");
                });

            modelBuilder.Entity("SportSpot.Logic.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("text")
                        .HasColumnName("Username");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("BirthDate");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("Description");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Email");

                    b.Property<bool>("Gender")
                        .HasColumnType("boolean")
                        .HasColumnName("Gender");

                    b.Property<string>("Interests")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Password");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Surname");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SportSpot.Logic.Models.Comment", b =>
                {
                    b.HasOne("SportSpot.Logic.Models.Spot", "Spot")
                        .WithMany("Comments")
                        .HasForeignKey("SpotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportSpot.Logic.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("Username")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Spot");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SportSpot.Logic.Models.Image", b =>
                {
                    b.HasOne("SportSpot.Logic.Models.Comment", "Comment")
                        .WithMany("Images")
                        .HasForeignKey("CommentId");

                    b.HasOne("SportSpot.Logic.Models.Spot", "Spot")
                        .WithMany("Images")
                        .HasForeignKey("SpotId");

                    b.HasOne("SportSpot.Logic.Models.User", "User")
                        .WithOne("Image")
                        .HasForeignKey("SportSpot.Logic.Models.Image", "Username");

                    b.Navigation("Comment");

                    b.Navigation("Spot");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SportSpot.Logic.Models.Comment", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("SportSpot.Logic.Models.Spot", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("SportSpot.Logic.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Image")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
