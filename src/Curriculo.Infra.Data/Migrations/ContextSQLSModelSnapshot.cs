﻿// <auto-generated />
using System;
using Curriculo.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Curriculo.Infra.Data.Migrations
{
    [DbContext(typeof(ContextSQLS))]
    partial class ContextSQLSModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Curriculo.Domain.Models.Product", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

                    b.Property<DateTime?>("CreateAt");

                    b.Property<string>("CreateBy")
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

                    b.Property<DateTime?>("DeleteAt");

                    b.Property<string>("DeleteBy")
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Description")
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

                    b.Property<decimal?>("Price");

                    b.Property<string>("ProductTypeId")
                        .IsRequired()
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

                    b.Property<DateTime?>("UpdateAt");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Curriculo.Domain.Models.ProductType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

                    b.Property<DateTime?>("CreateAt");

                    b.Property<string>("CreateBy")
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

                    b.Property<DateTime?>("DeleteAt");

                    b.Property<string>("DeleteBy")
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

                    b.Property<DateTime?>("UpdateAt");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("Curriculo.Domain.Models.Product", b =>
                {
                    b.HasOne("Curriculo.Domain.Models.ProductType", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
