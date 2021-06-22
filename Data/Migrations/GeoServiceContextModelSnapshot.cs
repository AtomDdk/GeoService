﻿// <auto-generated />
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(GeoServiceContext))]
    partial class GeoServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Models.CityDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCapital")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Population")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Data.Models.ContinentDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Continents");
                });

            modelBuilder.Entity("Data.Models.CountryDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContinentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Population")
                        .HasColumnType("bigint");

                    b.Property<long>("Surface")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ContinentId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Data.Models.CountryRiver", b =>
                {
                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("RiverId")
                        .HasColumnType("int");

                    b.HasKey("CountryId", "RiverId");

                    b.HasIndex("RiverId");

                    b.ToTable("CountryRiver");
                });

            modelBuilder.Entity("Data.Models.RiverDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Length")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rivers");
                });

            modelBuilder.Entity("Data.Models.CityDb", b =>
                {
                    b.HasOne("Data.Models.CountryDb", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Data.Models.CountryDb", b =>
                {
                    b.HasOne("Data.Models.ContinentDb", "Continent")
                        .WithMany("Countries")
                        .HasForeignKey("ContinentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Continent");
                });

            modelBuilder.Entity("Data.Models.CountryRiver", b =>
                {
                    b.HasOne("Data.Models.CountryDb", "Country")
                        .WithMany("Rivers")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.RiverDb", "River")
                        .WithMany("Countries")
                        .HasForeignKey("RiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("River");
                });

            modelBuilder.Entity("Data.Models.ContinentDb", b =>
                {
                    b.Navigation("Countries");
                });

            modelBuilder.Entity("Data.Models.CountryDb", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("Rivers");
                });

            modelBuilder.Entity("Data.Models.RiverDb", b =>
                {
                    b.Navigation("Countries");
                });
#pragma warning restore 612, 618
        }
    }
}
