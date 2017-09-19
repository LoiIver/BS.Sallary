using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BS;

namespace BS.Migrations
{
    [DbContext(typeof(DomainModelPostgreSqlContext))]
    partial class DomainModelPostgreSqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("BS.Data.Model.Company", b =>
                {
                    b.Property<long>("CompanyId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyTypeId");

                    b.Property<string>("Description")
                        .HasMaxLength(200);

                    b.Property<bool>("IsBase");

                    b.Property<int>("LicenseCount");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("BS.Data.Model.CompanyServiceType", b =>
                {
                    b.Property<long>("CompanyServiceTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CompanyId");

                    b.Property<long>("ServiceTypeId");

                    b.HasKey("CompanyServiceTypeId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ServiceTypeId");

                    b.ToTable("CompanyServiceTypes");
                });

            modelBuilder.Entity("BS.Data.Model.CompanyType", b =>
                {
                    b.Property<long>("CompanyTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("CompanyTypeId");

                    b.ToTable("CompanyTypes");
                });

            modelBuilder.Entity("BS.Data.Model.ServiceType", b =>
                {
                    b.Property<long>("ServiceTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CompanyTypeId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<long?>("ParentServiceTypeId");

                    b.HasKey("ServiceTypeId");

                    b.HasIndex("CompanyTypeId");

                    b.HasIndex("ParentServiceTypeId");

                    b.ToTable("ServiceTypes");
                });

            modelBuilder.Entity("BS.Data.Model.System.Role", b =>
                {
                    b.Property<long>("RoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BS.Data.Model.System.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .HasMaxLength(100);

                    b.Property<string>("Login")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .HasMaxLength(50);

                    b.Property<string>("Patronymic")
                        .HasMaxLength(100);

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BS.Data.Model.System.UsersRole", b =>
                {
                    b.Property<int>("UsersRoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RoleId");

                    b.Property<long?>("RoleId1");

                    b.Property<int>("UserId");

                    b.HasKey("UsersRoleId");

                    b.HasIndex("RoleId1");

                    b.HasIndex("UserId");

                    b.ToTable("UsersRoles");
                });

            modelBuilder.Entity("BS.Data.Model.CompanyServiceType", b =>
                {
                    b.HasOne("BS.Data.Model.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BS.Data.Model.ServiceType", "ServiceType")
                        .WithMany()
                        .HasForeignKey("ServiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BS.Data.Model.ServiceType", b =>
                {
                    b.HasOne("BS.Data.Model.CompanyType", "CompanyType")
                        .WithMany()
                        .HasForeignKey("CompanyTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BS.Data.Model.ServiceType", "ParentServiceType")
                        .WithMany()
                        .HasForeignKey("ParentServiceTypeId");
                });

            modelBuilder.Entity("BS.Data.Model.System.UsersRole", b =>
                {
                    b.HasOne("BS.Data.Model.System.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId1");

                    b.HasOne("BS.Data.Model.System.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
