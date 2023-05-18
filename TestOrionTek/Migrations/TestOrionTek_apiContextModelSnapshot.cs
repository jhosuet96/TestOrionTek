﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestOrionTek.Data;

#nullable disable

namespace TestOrionTek.Migrations
{
    [DbContext(typeof(TestOrionTek_apiContext))]
    partial class TestOrionTek_apiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestOrionTek.Data.Models.Company", b =>
                {
                    b.Property<int>("IdCompany")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCompany"));

                    b.Property<string>("NameCompany")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("IdCompany");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("TestOrionTek.Data.Models.Customer", b =>
                {
                    b.Property<int>("IdCustomer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCustomer"));

                    b.Property<int>("IdCompany")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("IdCustomer");

                    b.HasIndex("IdCompany");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TestOrionTek.Data.Models.CustomerDetails", b =>
                {
                    b.Property<int>("IdCustomerDetail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCustomerDetail"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCustomer")
                        .HasColumnType("int");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("IdCustomerDetail");

                    b.HasIndex("IdCustomer");

                    b.ToTable("CustomerDetails");
                });

            modelBuilder.Entity("TestOrionTek.Data.Models.Customer", b =>
                {
                    b.HasOne("TestOrionTek.Data.Models.Company", "Company")
                        .WithMany("Customers")
                        .HasForeignKey("IdCompany")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("TestOrionTek.Data.Models.CustomerDetails", b =>
                {
                    b.HasOne("TestOrionTek.Data.Models.Customer", "Customers")
                        .WithMany("CustomerDetails")
                        .HasForeignKey("IdCustomer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("TestOrionTek.Data.Models.Company", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("TestOrionTek.Data.Models.Customer", b =>
                {
                    b.Navigation("CustomerDetails");
                });
#pragma warning restore 612, 618
        }
    }
}