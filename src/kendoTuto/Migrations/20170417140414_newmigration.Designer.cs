using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using kendoTuto.Domain.Entities;

namespace kendoTuto.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20170417140414_newmigration")]
    partial class newmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("kendoTuto.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Title");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("kendoTuto.Domain.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EmployeeId");

                    b.Property<string>("ShipAdresse");

                    b.Property<string>("ShipCountry");

                    b.Property<string>("ShipName");

                    b.HasKey("OrderId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("kendoTuto.Domain.Entities.Order", b =>
                {
                    b.HasOne("kendoTuto.Domain.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");
                });
        }
    }
}
