using Domain.AggregationModels.EmployeeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Context;

public class EmployeeContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    
    public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());
    }

    private class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employees");

            builder.HasKey(e => e.Id);

            builder.Ignore(e => e.DomainEvents);

            builder.Property(e => e.Id)
                .UseHiLo("employee_seq");

            builder.OwnsOne(e => e.Department, d =>
            {
                d.Property(x => x.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(3)")
                    .IsRequired();

                d.Property(x => x.FullName)
                    .HasColumnName("full_name")
                    .HasColumnType("varchar(500)")
                    .IsRequired();
            });

            builder.OwnsOne(e => e.FullName, fn =>
            {
                fn.Property(x => x.Surname)
                    .HasColumnName("surname")
                    .HasColumnType("varchar(200)")
                    .IsRequired();

                fn.Property(x => x.FirstName)
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(200)")
                    .IsRequired();

                fn.Property(x => x.PatronymicName)
                    .HasColumnType("varchar(200)")
                    .HasColumnName("patronymic_name");
            });

            builder.OwnsOne(e => e.BirthDate, bd =>
            {
                bd.Property(x => x.Value)
                    .HasColumnName("birth_day")
                    .HasColumnType("date")
                    .IsRequired();
            });

            builder.OwnsOne(e => e.DateOfEmployment, doe =>
            {
                doe.Property(x => x.Value)
                    .HasColumnName("date_of_employment")
                    .HasColumnName("date")
                    .IsRequired();
            });

            builder.OwnsOne(e => e.Salary, s =>
            {
                s.Property(x => x.Value)
                    .HasColumnName("salary")
                    .HasColumnType("numeric(12, 2)")
                    .IsRequired();
            });
        }
    }
}