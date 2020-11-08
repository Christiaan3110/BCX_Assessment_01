using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BCX_Assessment_01.EF
{
    public partial class bcxassignment01Context : DbContext
    {
        public bcxassignment01Context()
        {
        }

        public bcxassignment01Context(DbContextOptions<bcxassignment01Context> options)
            : base(options)
        {
        }

        public virtual DbSet<CasualEmployees> CasualEmployees { get; set; }
        public virtual DbSet<CasualEmployeesInCasualTasks> CasualEmployeesInCasualTasks { get; set; }
        public virtual DbSet<CasualRoles> CasualRoles { get; set; }
        public virtual DbSet<CasualTasks> CasualTasks { get; set; }
        public virtual DbSet<CasualTasksLogs> CasualTasksLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=bcxassignment01.database.windows.net;Initial Catalog=bcxassignment01;User ID=dev;Password=L!ghtswitch3110;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CasualEmployees>(entity =>
            {
                entity.HasKey(e => e.CasualEmployeeId)
                    .HasName("PK__CasualEm__F65509109AA50BAF");

                entity.Property(e => e.CasualEmployeeId).HasColumnName("CasualEmployeeID");

                entity.Property(e => e.CasualRoleId).HasColumnName("CasualRoleID");

                entity.Property(e => e.CurrentHourlyRateInZar)
                    .HasColumnName("CurrentHourlyRateInZAR")
                    .HasColumnType("decimal(16, 2)");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.CasualRole)
                    .WithMany(p => p.CasualEmployees)
                    .HasForeignKey(d => d.CasualRoleId)
                    .HasConstraintName("FK__CasualEmp__Casua__5FB337D6");
            });

            modelBuilder.Entity<CasualEmployeesInCasualTasks>(entity =>
            {
                entity.Property(e => e.CasualEmployeesInCasualTasksId).HasColumnName("CasualEmployeesInCasualTasksID");

                entity.Property(e => e.CasualEmployeeId).HasColumnName("CasualEmployeeID");

                entity.Property(e => e.CasualTaskId).HasColumnName("CasualTaskID");

                entity.Property(e => e.DateLinked)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DateUnlinked).HasColumnType("datetime");

                entity.Property(e => e.IsEnabled).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.CasualEmployee)
                    .WithMany(p => p.CasualEmployeesInCasualTasks)
                    .HasForeignKey(d => d.CasualEmployeeId)
                    .HasConstraintName("FK__CasualEmp__Casua__6754599E");

                entity.HasOne(d => d.CasualTask)
                    .WithMany(p => p.CasualEmployeesInCasualTasks)
                    .HasForeignKey(d => d.CasualTaskId)
                    .HasConstraintName("FK__CasualEmp__Casua__68487DD7");
            });

            modelBuilder.Entity<CasualRoles>(entity =>
            {
                entity.HasKey(e => e.CasualRoleId)
                    .HasName("PK__CasualRo__F7930C024D920524");

                entity.Property(e => e.CasualRoleId).HasColumnName("CasualRoleID");

                entity.Property(e => e.CasualRole)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.HourlyRateInZar).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<CasualTasks>(entity =>
            {
                entity.HasKey(e => e.CasualTaskId)
                    .HasName("PK__CasualTa__A0FE864E81A1B91D");

                entity.Property(e => e.CasualTaskId).HasColumnName("CasualTaskID");

                entity.Property(e => e.CasualTask)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.DateCompleted).HasColumnType("datetime");

                entity.Property(e => e.DateStarted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TimeEstiamteInHours).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<CasualTasksLogs>(entity =>
            {
                entity.HasKey(e => e.CasualTasksLogId)
                    .HasName("PK__CasualTa__07BF49C6AED33B31");

                entity.Property(e => e.CasualTasksLogId).HasColumnName("CasualTasksLogID");

                entity.Property(e => e.CasualEmployeeId).HasColumnName("CasualEmployeeID");

                entity.Property(e => e.CasualTaskId).HasColumnName("CasualTaskID");

                entity.Property(e => e.DayOfWork).HasColumnType("datetime");

                entity.Property(e => e.HoursWorkedForDay).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.LogEntryDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
