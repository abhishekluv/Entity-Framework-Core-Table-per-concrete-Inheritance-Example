﻿// <auto-generated />
using EFCoreTablePerConcreteInheritance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCoreTablePerConcreteInheritance.Migrations
{
    [DbContext(typeof(MyApplicationContext))]
    [Migration("20230922103910_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("VehicleSequence");

            modelBuilder.Entity("EFCoreTablePerConcreteInheritance.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR [VehicleSequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Make")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("EFCoreTablePerConcreteInheritance.Models.Car", b =>
                {
                    b.HasBaseType("EFCoreTablePerConcreteInheritance.Models.Vehicle");

                    b.Property<int>("TrunkSize")
                        .HasColumnType("int");

                    b.ToTable("Cars", (string)null);
                });

            modelBuilder.Entity("EFCoreTablePerConcreteInheritance.Models.Motorcycle", b =>
                {
                    b.HasBaseType("EFCoreTablePerConcreteInheritance.Models.Vehicle");

                    b.Property<int>("EnginePower")
                        .HasColumnType("int");

                    b.ToTable("Motorcycles", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
