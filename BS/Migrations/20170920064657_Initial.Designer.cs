using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BS;

namespace BS.Migrations
{
    [DbContext(typeof(DomainModelPostgreSqlContext))]
    [Migration("20170920064657_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("BS.Data.Model.Company", b =>
                {
                    b.Property<long>("CompanyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(200);

                    b.Property<bool>("IsBase");

                    b.Property<long>("LegalFormId");

                    b.Property<int>("LicenseCount");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("CompanyId");

                    b.HasIndex("LegalFormId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("BS.Data.Model.Employee", b =>
                {
                    b.Property<long>("EmployeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("UserId");

                    b.HasKey("EmployeeId");

                    b.HasIndex("UserId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("BS.Data.Model.LegalForm", b =>
                {
                    b.Property<long>("LegalFormId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsCommercial");

                    b.Property<string>("Name");

                    b.HasKey("LegalFormId");

                    b.ToTable("LegalForms");
                });

            modelBuilder.Entity("BS.Data.Model.Position", b =>
                {
                    b.Property<long>("PositionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("PositionId");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("BS.Data.Model.PositionInCompany", b =>
                {
                    b.Property<long>("PositionInCompanyId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CompanyId");

                    b.Property<long>("EmployeeId");

                    b.Property<DateTime?>("EndDate");

                    b.Property<long>("PositionId");

                    b.Property<DateTime?>("StartDate");

                    b.HasKey("PositionInCompanyId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PositionId");

                    b.ToTable("PositionInCompanys");
                });

            modelBuilder.Entity("BS.Data.Model.System.Menu", b =>
                {
                    b.Property<long>("MenuId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<string>("ActionParameter");

                    b.Property<string>("Caption");

                    b.Property<string>("Controller");

                    b.Property<bool>("Enabled");

                    b.Property<string>("Url");

                    b.HasKey("MenuId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("BS.Data.Model.System.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .HasMaxLength(100);

                    b.Property<string>("Login")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .HasMaxLength(50);

                    b.Property<string>("PatronymicName")
                        .HasMaxLength(100);

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BS.Data.Model.Company", b =>
                {
                    b.HasOne("BS.Data.Model.LegalForm", "LegalForm")
                        .WithMany()
                        .HasForeignKey("LegalFormId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BS.Data.Model.Employee", b =>
                {
                    b.HasOne("BS.Data.Model.System.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BS.Data.Model.PositionInCompany", b =>
                {
                    b.HasOne("BS.Data.Model.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BS.Data.Model.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BS.Data.Model.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
