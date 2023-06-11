﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistence.Context;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    partial class EmployeeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.4.23259.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.HasSequence("employee_seq")
                .IncrementsBy(10);

            modelBuilder.Entity("Domain.AggregationModels.EmployeeAggregate.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "employee_seq");

                    b.HasKey("Id");

                    b.ToTable("employees", (string)null);
                });

            modelBuilder.Entity("Domain.AggregationModels.EmployeeAggregate.Employee", b =>
                {
                    b.OwnsOne("Domain.AggregationModels.EmployeeAggregate.BirthDate", "BirthDate", b1 =>
                        {
                            b1.Property<int>("EmployeeId")
                                .HasColumnType("integer");

                            b1.Property<DateOnly>("Value")
                                .HasColumnType("date")
                                .HasColumnName("birth_day");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId");
                        });

                    b.OwnsOne("Domain.AggregationModels.EmployeeAggregate.DateOfEmployment", "DateOfEmployment", b1 =>
                        {
                            b1.Property<int>("EmployeeId")
                                .HasColumnType("integer");

                            b1.Property<DateOnly>("Value")
                                .HasColumnType("date")
                                .HasColumnName("date_of_employment");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId");
                        });

                    b.OwnsOne("Domain.AggregationModels.EmployeeAggregate.Department", "Department", b1 =>
                        {
                            b1.Property<int>("EmployeeId")
                                .HasColumnType("integer");

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasColumnType("varchar(3)")
                                .HasColumnName("code");

                            b1.Property<string>("FullName")
                                .IsRequired()
                                .HasColumnType("varchar(500)")
                                .HasColumnName("full_name");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId");
                        });

                    b.OwnsOne("Domain.AggregationModels.EmployeeAggregate.FullName", "FullName", b1 =>
                        {
                            b1.Property<int>("EmployeeId")
                                .HasColumnType("integer");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("varchar(200)")
                                .HasColumnName("first_name");

                            b1.Property<string>("PatronymicName")
                                .HasColumnType("varchar(200)")
                                .HasColumnName("patronymic_name");

                            b1.Property<string>("Surname")
                                .IsRequired()
                                .HasColumnType("varchar(200)")
                                .HasColumnName("surname");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId");
                        });

                    b.OwnsOne("Domain.AggregationModels.EmployeeAggregate.Salary", "Salary", b1 =>
                        {
                            b1.Property<int>("EmployeeId")
                                .HasColumnType("integer");

                            b1.Property<decimal>("Value")
                                .HasColumnType("numeric(12, 2)")
                                .HasColumnName("salary");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId");
                        });

                    b.Navigation("BirthDate")
                        .IsRequired();

                    b.Navigation("DateOfEmployment")
                        .IsRequired();

                    b.Navigation("Department")
                        .IsRequired();

                    b.Navigation("FullName")
                        .IsRequired();

                    b.Navigation("Salary")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
