using System;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;

namespace InterLab.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Company>       Companies       { get; set; }
        public DbSet<Document>      Documents       { get; set; }
        public DbSet<Internship>    Internships     { get; set; }
        public DbSet<Process>       Processes       { get; set; }
        public DbSet<Profile>       Profiles        { get; set; }
        public DbSet<Qualification> Qualifications  { get; set; }
        public DbSet<Request>       Requests        { get; set; }
        public DbSet<Role>          Roles           { get; set; }
        public DbSet<Student>       Students        { get; set; }
        public DbSet<Worker>        Workers         { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Company Entity
            builder.Entity<Company>().ToTable("Companies");
            builder.Entity<Company>().HasKey(p => p.Id);
            builder.Entity<Company>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Company>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            /*builder.Entity<Company>().HasMany(p => p.Products)
                .WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);
                */
            builder.Entity<Company>().HasData
                (
                new Category { Id = 100, Name = "InterLab" },
                new Category { Id = 101, Name = "FastTech" }
                );

            //Document Entity

            //Document Entity

            //Document Entity

        }
    }
}
