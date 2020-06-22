namespace CompanyManagementSystem.DataAccess.Concrete.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using CompanyManagementSystem.Entities.Concrete;

    public partial class CompanyContext : DbContext
    {
        public CompanyContext()
            : base("name=CompanyContext")
        {
        }

        public virtual DbSet<AlımTablosu> AlımTablosu { get; set; }
        public virtual DbSet<Duyuru> Duyuru { get; set; }
        public virtual DbSet<Faturalar> Faturalar { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Raporlar> Raporlar { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlımTablosu>()
                .Property(e => e.Tutar)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Faturalar>()
                .HasMany(e => e.AlımTablosu)
                .WithRequired(e => e.Faturalar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Duyuru)
                .WithOptional(e => e.User)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Log)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserRole>()
                .HasMany(e => e.User)
                .WithRequired(e => e.UserRole)
                .WillCascadeOnDelete(false);
        }
    }
}
