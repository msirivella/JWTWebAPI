using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace API_JWTAuthentication.Model
{
    public partial class WebAPIContext : DbContext
    {
        public WebAPIContext()
        {
        }

        public WebAPIContext(DbContextOptions<WebAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attendance> Attendance { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<OtData> OtData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Database=WebAPI;Username=WebAPI;Password=postsql;Pooling=False;");
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("attendance");

                entity.Property(e => e.Employeeid).HasColumnName("employeeid");

                entity.Property(e => e.Intime)
                    .HasColumnName("intime")
                    .HasMaxLength(50);

                entity.Property(e => e.Outtime)
                    .HasColumnName("outtime")
                    .HasMaxLength(50);

                entity.Property(e => e.Shiftdate)
                    .HasColumnName("shiftdate")
                    .HasMaxLength(20);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany()
                    .HasForeignKey(d => d.Employeeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Employeenumber).HasColumnName("employeenumber");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<OtData>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ot_data");

                entity.Property(e => e.Employeeid).HasColumnName("employeeid");

                entity.Property(e => e.Normalot).HasColumnName("normalot");

                entity.Property(e => e.Premiumot).HasColumnName("premiumot");

                entity.Property(e => e.Shiftdate)
                    .HasColumnName("shiftdate")
                    .HasMaxLength(20);

                entity.HasOne(d => d.Employee)
                    .WithMany()
                    .HasForeignKey(d => d.Employeeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_attendance");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
