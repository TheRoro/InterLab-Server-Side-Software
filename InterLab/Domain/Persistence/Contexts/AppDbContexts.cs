using InterLab.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace InterLab.Domain.Persistence.Contexts
{
    public class AppDbContexts : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Entrepreneurs> entrepreneurs { get; set; }

        public AppDbContexts(DbContextOptions<AppDbContexts> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //User Entity
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);

            //Primarykey is not null
            builder.Entity<User>().Property(p => p.Id).IsRequired().
                ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.FirstName).IsRequired().
                HasMaxLength(20);
            builder.Entity<User>().Property(p => p.LastName).IsRequired().
                HasMaxLength(20);
            builder.Entity<User>().Property(p => p.Mail).IsRequired().
                HasMaxLength(20);
            builder.Entity<User>().Property(p => p.password).IsRequired().
                HasMaxLength(20);
            builder.Entity<User>().Property(p => p.Phone_Number).IsRequired().
                HasMaxLength(15);
            builder.Entity<User>().Property(p => p.country).IsRequired().
                HasMaxLength(20);
            builder.Entity<User>().Property(p => p.city).IsRequired().
                HasMaxLength(20);

            //
 
            builder.Entity<Student>().HasMany(p => p.Users).
                 WithOne(p => p.Student).HasForeignKey(p => p.Id);

        }
    }
}
