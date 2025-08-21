using BarberHub.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Emit;
namespace BarberHub.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        // Define your tables here using DbSet<T>
        public DbSet<Company> Companies { get; set; }

        public DbSet<CompanyType> CompanyTypes { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserProfile> Profiles { get; set; }

        public DbSet<UserRole> Roles { get; set; }

        public DbSet<ProvidedService> ProvidedServices { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Portfolio> Portfolios { get; set; }

        public DbSet<Specialty> Specialties { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<PaymentDetail> paymentDetails { get; set; }
        

        // Optional: Fluent API configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>()
                .HasOne(c => c.CompanyType)
                .WithMany(ct => ct.Companies)
                .HasForeignKey(c => c.CompanyTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.UserProfile)
                .WithOne(up => up.User)
                .HasForeignKey<UserProfile>(up => up.UserId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.UserRole)
                .WithMany(up => up.Users)
                .HasForeignKey(u => u.UserRoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProvidedService>()
                .HasOne(cs => cs.Company)
                .WithMany(c => c.ProvidedServices)
                .HasForeignKey(cs => cs.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Review>()
                .HasOne(r => r.Company)
                .WithMany(c => c.Reviews)
                .HasForeignKey(r => r.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.ReviewerUser)
                .WithMany(u => u.GivenReviews)
                .HasForeignKey(r => r.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.ReviewedUser)
                .WithMany(u => u.ReceivedReviews)
                .HasForeignKey(r => r.ReviewedUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.User)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Portfolio)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PortfolioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>()
                .HasOne(c => c.User)
                .WithMany(u => u.Companies)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.EmployerCompany) // the company they work for
                .WithMany(c => c.Employees)
                .HasForeignKey(u => u.EmployeedCompanyId)
                .OnDelete(DeleteBehavior.SetNull); // optional depending on your needs


            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Company)
                .WithMany(c => c.Payments)
                .HasForeignKey(p => p.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Payment - User (Many-to-One)
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.User)
                .WithMany(u => u.Payments)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict); // prevent cascade delete

            // PaymentDetail - Payment (Many-to-One)
            modelBuilder.Entity<PaymentDetail>()
                .HasOne(pd => pd.Payment)
                .WithMany(p => p.PaymentDetails)
                .HasForeignKey(pd => pd.PaymentId)
                .OnDelete(DeleteBehavior.Cascade); // delete details if payment is deleted

            // PaymentDetail - Service (Many-to-One)
            modelBuilder.Entity<PaymentDetail>()
                .HasOne(pd => pd.Service)
                .WithMany()
                .HasForeignKey(pd => pd.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            // PaymentDetail - Portfolio (Many-to-One)
            modelBuilder.Entity<PaymentDetail>()
                .HasOne(pd => pd.Portfolio)
                .WithMany(p => p.PaymentDetails)
                .HasForeignKey(pd => pd.PortfolioId)
                .OnDelete(DeleteBehavior.Restrict);



        modelBuilder.Entity<Portfolio>()
                .HasMany(p => p.Specialties)
                .WithMany(s => s.Portfolios)
                .UsingEntity<Dictionary<string, object>>(
                    "PortfolioSpecialty", // Join table name
                    j => j
                        .HasOne<Specialty>()
                        .WithMany()
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Portfolio>()
                        .WithMany()
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j =>
                    {
                        j.HasKey("PortfolioId", "SpecialtyId");
                    });
        }
    }
}
