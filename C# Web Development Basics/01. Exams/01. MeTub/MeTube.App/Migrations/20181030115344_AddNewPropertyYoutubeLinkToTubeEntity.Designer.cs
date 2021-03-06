﻿// <auto-generated />
using MeTube.App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MeTube.App.Migrations
{
    [DbContext(typeof(MeTubeContext))]
    [Migration("20181030115344_AddNewPropertyYoutubeLinkToTubeEntity")]
    partial class AddNewPropertyYoutubeLinkToTubeEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MeTube.App.Models.Tube", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.Property<int>("UploderId");

                    b.Property<int>("Views");

                    b.Property<string>("YouTubeId");

                    b.Property<string>("YoutubeLink");

                    b.HasKey("Id");

                    b.HasIndex("UploderId");

                    b.ToTable("Tubes");
                });

            modelBuilder.Entity("MeTube.App.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MeTube.App.Models.Tube", b =>
                {
                    b.HasOne("MeTube.App.Models.User", "Uploder")
                        .WithMany("Tubes")
                        .HasForeignKey("UploderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
