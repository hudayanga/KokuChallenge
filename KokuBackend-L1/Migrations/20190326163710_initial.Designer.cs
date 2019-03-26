﻿// <auto-generated />
using KokuBackend_L1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KokuBackend_L1.Migrations
{
    [DbContext(typeof(ForexDbContext))]
    [Migration("20190326163710_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KokuBackend.Business.RateL2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("ForexRate");

                    b.Property<string>("Partner");

                    b.Property<int>("Supply");

                    b.HasKey("Id");

                    b.ToTable("L2Rates");
                });

            modelBuilder.Entity("KokuBackend_L1.Business.RateL3", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("EffectiveRate");

                    b.Property<string>("Partner");

                    b.Property<decimal>("Rate");

                    b.Property<decimal>("ServiceCharge");

                    b.Property<int>("Supply");

                    b.Property<decimal>("TakenQuantity");

                    b.HasKey("Id");

                    b.ToTable("L3Rates");
                });
#pragma warning restore 612, 618
        }
    }
}
