﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SwimSpot.Api.Models;

namespace SwimSpot.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SwimSpot.Shared.SwimmingSpot", b =>
                {
                    b.Property<int>("SwimmingSpotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(17,15)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(17,15)");

                    b.HasKey("SwimmingSpotId");

                    b.ToTable("SwimmingSpots");

                    b.HasData(
                        new
                        {
                            SwimmingSpotId = 1,
                            Latitude = 55.6455217723385m,
                            Longitude = -2.9060585301065363m
                        },
                        new
                        {
                            SwimmingSpotId = 2,
                            Latitude = 55.77398808982048m,
                            Longitude = -3.1221541644140895m
                        });
                });

            modelBuilder.Entity("SwimSpot.Shared.SwimmingSpotComment", b =>
                {
                    b.Property<int>("SwimmingSpotCommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SwimDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SwimmingSpotId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WaterTemp")
                        .HasColumnType("int");

                    b.HasKey("SwimmingSpotCommentId");

                    b.HasIndex("SwimmingSpotId");

                    b.ToTable("SwimmingSpotComments");

                    b.HasData(
                        new
                        {
                            SwimmingSpotCommentId = 1,
                            CommentDate = new DateTime(2021, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Content = "Swam along west shore with Doug",
                            SwimDate = new DateTime(2021, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SwimmingSpotId = 1,
                            UserId = 1,
                            WaterTemp = 20
                        },
                        new
                        {
                            SwimmingSpotCommentId = 2,
                            CommentDate = new DateTime(2021, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Content = "Swam around the island",
                            SwimDate = new DateTime(2021, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SwimmingSpotId = 2,
                            UserId = 1,
                            WaterTemp = 20
                        });
                });

            modelBuilder.Entity("SwimSpot.Shared.SwimmingSpotComment", b =>
                {
                    b.HasOne("SwimSpot.Shared.SwimmingSpot", null)
                        .WithMany("Comments")
                        .HasForeignKey("SwimmingSpotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SwimSpot.Shared.SwimmingSpot", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
