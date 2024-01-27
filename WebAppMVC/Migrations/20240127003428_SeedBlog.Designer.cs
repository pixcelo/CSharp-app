﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAppMVC.Models;

#nullable disable

namespace WebAppMVC.Migrations
{
    [DbContext(typeof(BlogContext))]
    [Migration("20240127003428_SeedBlog")]
    partial class SeedBlog
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebAppMVC.Models.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Blog");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "First Blog"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Second Blog"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Third Blog"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
