using InterLab.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace InterLab.Domain.Persistence.Contexts
{
    public class AppDbContexts : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Entrepreneur> Entrepreneurs { get; set; }

        public DbSet<Document> Documents { get; set; }

        public DbSet<University> Universities { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Qualification> Qualification { get; set; }

        public DbSet<Request> Requests { get; set; }

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
            builder.Entity<User>().Property(p => p.Password).IsRequired().
                HasMaxLength(20);
            builder.Entity<User>().Property(p => p.Phone_Number).IsRequired().
                HasMaxLength(15);
            builder.Entity<User>().Property(p => p.Country).IsRequired().
                HasMaxLength(20);
            builder.Entity<User>().Property(p => p.City).IsRequired().
                HasMaxLength(20);


            //Relation
            builder.Entity<User>().HasMany(p => p.Student).
                 WithOne(p => p.User).HasForeignKey(p => p.UserId);

        }
    }
}
