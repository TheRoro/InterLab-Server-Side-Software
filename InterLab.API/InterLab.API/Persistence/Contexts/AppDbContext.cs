using System;
using Microsoft.EntityFrameworkCore;
using InterLab.API.Domain.Models;

namespace InterLab.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Internship> Internships { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Worker> Workers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //1. Company Entity
            builder.Entity<Company>().ToTable("Companies");
            builder.Entity<Company>().HasKey(p => p.Id);
            builder.Entity<Company>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Company>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Company>().Property(p => p.Description).IsRequired().HasMaxLength(200);
            builder.Entity<Company>().Property(p => p.Sector).IsRequired().HasMaxLength(30);
            builder.Entity<Company>().Property(p => p.Mail).IsRequired().HasMaxLength(30);
            builder.Entity<Company>().Property(p => p.Phone_Number).IsRequired().HasMaxLength(20);
            builder.Entity<Company>().Property(p => p.Address).IsRequired().HasMaxLength(40);
            builder.Entity<Company>().Property(p => p.City).IsRequired().HasMaxLength(20);
            builder.Entity<Company>().Property(p => p.Country).IsRequired().HasMaxLength(20);
            //Relationships
            builder.Entity<Company>().HasMany(p => p.Qualifications)
                .WithOne(p => p.Company).HasForeignKey(p => p.CompanyId);
            //Missing relationship with Workers_Companies

            builder.Entity<Company>().HasData
                (
                new Company { Id = 100, Name = "InterLab" },
                new Company { Id = 101, Name = "FastTech" },
                new Company { Id = 102, Name = "WAPO" }
                );

            //2. Document Entity
            builder.Entity<Document>().ToTable("Documents");
            builder.Entity<Document>().HasKey(p => p.Id);
            builder.Entity<Document>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Document>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Document>().Property(p => p.Description).IsRequired().HasMaxLength(200);
            //Relationships
            builder.Entity<Document>().HasOne(p => p.Student)
                .WithMany(p => p.Documents).HasForeignKey(p => p.StudentId);


            //3. Internship Entity
            builder.Entity<Internship>().ToTable("Internships");
            builder.Entity<Internship>().HasKey(p => p.Id);
            builder.Entity<Internship>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Internship>().Property(p => p.State).IsRequired().HasMaxLength(30);
            builder.Entity<Internship>().Property(p => p.Description).IsRequired().HasMaxLength(30);
            builder.Entity<Internship>().Property(p => p.DatePublished).IsRequired().HasMaxLength(20);
            builder.Entity<Internship>().Property(p => p.StartingDate).IsRequired().HasMaxLength(20);
            builder.Entity<Internship>().Property(p => p.FinishingDate).IsRequired().HasMaxLength(20);
            builder.Entity<Internship>().Property(p => p.Salary).IsRequired().HasMaxLength(30);
            //Relationships

            builder.Entity<Internship>().HasMany(p => p.Roles)
                .WithOne(p => p.Internship).HasForeignKey(p => p.InternshipId);
            builder.Entity<Internship>().HasMany(p => p.Requests)
                .WithOne(p => p.Internship).HasForeignKey(p => p.InternshipId);
            builder.Entity<Internship>().HasOne(p => p.Profile)
                .WithOne(p => p.Internship).HasForeignKey<Profile>(p => p.InternshipId);

            //4. Process Entity
            builder.Entity<Process>().ToTable("Processes");
            builder.Entity<Process>().HasKey(p => p.Id);
            builder.Entity<Process>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Process>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Process>().Property(p => p.Description).IsRequired().HasMaxLength(50);
            //Relationships





            //5. Profile Entity
            builder.Entity<Profile>().ToTable("Profiles");
            builder.Entity<Profile>().HasKey(p => p.Id);
            builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Profile>().Property(p => p.FullName).IsRequired().HasMaxLength(30);
            builder.Entity<Profile>().Property(p => p.Field).IsRequired().HasMaxLength(30);
            builder.Entity<Profile>().Property(p => p.Degree).IsRequired().HasMaxLength(30);
            builder.Entity<Profile>().Property(p => p.Degree).IsRequired().HasMaxLength(30);
            builder.Entity<Profile>().Property(p => p.Description).IsRequired().HasMaxLength(100);
            //



            //6. Qualification Entity
            builder.Entity<Qualification>().ToTable("Qualifications");
            builder.Entity<Qualification>().HasKey(p => p.Id);
            builder.Entity<Qualification>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Qualification>().Property(p => p.Comment).IsRequired().HasMaxLength(50);
            builder.Entity<Qualification>().Property(p => p.Score).IsRequired().HasMaxLength(10);


            //7. Request Entity
            builder.Entity<Request>().ToTable("Requests");
            builder.Entity<Request>().HasKey(p => p.Id);
            builder.Entity<Request>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Request>().Property(p => p.State).IsRequired().HasMaxLength(10);
            builder.Entity<Request>().Property(p => p.DateSend).IsRequired().HasMaxLength(10);


            //8. Role Entity
            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<Role>().HasKey(p => p.Id);
            builder.Entity<Role>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Role>().Property(p => p.Name).IsRequired().HasMaxLength(10);
            builder.Entity<Role>().Property(p => p.Mail).IsRequired().HasMaxLength(20);
            builder.Entity<Role>().Property(p => p.Type).IsRequired().HasMaxLength(10);
            builder.Entity<Role>().Property(p => p.Description).IsRequired().HasMaxLength(30);

  
            //9. Student Entity
            builder.Entity<Student>().ToTable("Students");
            builder.Entity<Student>().HasKey(p => p.Id);
            builder.Entity<Student>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Entity<Student>().HasOne(p => p.Profile)
                .WithOne(p => p.Student).HasForeignKey<Profile>(p => p.StudentId);


            //10. Worker Entity
            builder.Entity<Worker>().ToTable("Workers");
            builder.Entity<Worker>().HasKey(p => p.Id);
            builder.Entity<Worker>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

            //Relationship
            builder.Entity<Worker>().HasOne(p => p.Profile)
               .WithOne(p => p.Worker).HasForeignKey<Profile>(p => p.WorkerId);

        }
    }
}
