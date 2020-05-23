using System;
using Microsoft.EntityFrameworkCore;
using InterLab.API.Domain.Models;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using InterLab.API.Extensions;

namespace InterLab.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Internship> Internships { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkerCompany> WorkerCompanies { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Company Entity
            builder.Entity<Company>().ToTable("Companies");
            builder.Entity<Company>().HasKey(p => p.Id);
            builder.Entity<Company>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Company>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Company>().Property(p => p.Description).IsRequired().HasMaxLength(200);
            builder.Entity<Company>().Property(p => p.Sector).IsRequired().HasMaxLength(30);
            builder.Entity<Company>().Property(p => p.Email).IsRequired().HasMaxLength(30);
            builder.Entity<Company>().Property(p => p.Phone).IsRequired().HasMaxLength(20);
            builder.Entity<Company>().Property(p => p.Address).IsRequired().HasMaxLength(40);
            builder.Entity<Company>().Property(p => p.Country).IsRequired().HasMaxLength(20);
            builder.Entity<Company>().Property(p => p.City).IsRequired().HasMaxLength(20);

            //Relationships:

            //One to many with Qualifications
            builder.Entity<Company>().HasMany(p => p.Qualifications)
                .WithOne(p => p.Company).HasForeignKey(p => p.CompanyId);

            //Many to Many with Worker
            //Already in WorkerCompany Relationship



            //Document Entity
            builder.Entity<Document>().ToTable("Documents");
            builder.Entity<Document>().HasKey(p => p.Id);
            builder.Entity<Document>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Document>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Document>().Property(p => p.Description).IsRequired().HasMaxLength(200);

            //Relationships:

            //One to many with Student
            //Already in Student Relationship



            //Internship Entity
            builder.Entity<Internship>().ToTable("Internships");
            builder.Entity<Internship>().HasKey(p => p.Id);
            builder.Entity<Internship>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Internship>().Property(p => p.State).IsRequired().HasMaxLength(30);
            builder.Entity<Internship>().Property(p => p.Description).IsRequired().HasMaxLength(30);
            builder.Entity<Internship>().Property(p => p.PublicationDate).IsRequired().HasMaxLength(20);
            builder.Entity<Internship>().Property(p => p.StartingDate).IsRequired().HasMaxLength(20);
            builder.Entity<Internship>().Property(p => p.FinishingDate).IsRequired().HasMaxLength(20);
            builder.Entity<Internship>().Property(p => p.Salary).IsRequired().HasMaxLength(30);

            //Relationships:

            //One to One with Requirement
            builder.Entity<Internship>().HasOne(p => p.Requirement)
            .WithOne(p => p.Internship)
            .HasForeignKey<Requirement>(p => p.InternshipId);

            //One to Many with Request
            builder.Entity<Internship>().HasMany(p => p.Requests)
                .WithOne(p => p.Internship).HasForeignKey(p => p.InternshipId);

            //One to Many with Worker
            //Already in Worker Relationship



            //Profile Entity
            builder.Entity<Profile>().ToTable("Profiles");
            builder.Entity<Profile>().HasKey(p => p.Id);
            builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Profile>().Property(p => p.FirstName).IsRequired();
            builder.Entity<Profile>().Property(p => p.LastName).IsRequired();
            builder.Entity<Profile>().Property(p => p.Field).IsRequired();
            builder.Entity<Profile>().Property(p => p.Phone).IsRequired();
            builder.Entity<Profile>().Property(p => p.Description).IsRequired();
            builder.Entity<Profile>().Property(p => p.Country).IsRequired();
            builder.Entity<Profile>().Property(p => p.City).IsRequired();
            //Properties only required for Student
            builder.Entity<Profile>().Property(p => p.University);
            builder.Entity<Profile>().Property(P => P.Degree);
            builder.Entity<Profile>().Property(p => p.Semester);

            //Relationships:

            //One to one with Student
            //Already in Student Relationship

            //One to one with Worker
            //Already in Worker Relationship



            //Qualification Entity
            builder.Entity<Qualification>().ToTable("Qualifications");
            builder.Entity<Qualification>().HasKey(p => p.Id);
            builder.Entity<Qualification>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Qualification>().Property(p => p.Comment).IsRequired().HasMaxLength(50);
            builder.Entity<Qualification>().Property(p => p.Score).IsRequired().HasMaxLength(10);

            //Relationships:

            //One to one with Student
            //Already in Student Relationship

            //One to one with Company
            //Already in Company Relationship



            //Request Entity
            builder.Entity<Request>().ToTable("Requests");
            builder.Entity<Request>().HasKey(p => p.Id);
            builder.Entity<Request>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Request>().Property(p => p.State).IsRequired().HasMaxLength(10);
            builder.Entity<Request>().Property(p => p.CreationDate).IsRequired().HasMaxLength(10);

            //Relationships:

            //One to one with Student
            //Already in Student Relationship

            //One to one with Internship
            //Already in Internship Relationship



            //Requirement Entity
            builder.Entity<Requirement>().ToTable("Requirements");
            builder.Entity<Requirement>().HasKey(p => p.Id);
            builder.Entity<Requirement>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Requirement>().Property(p => p.Field).IsRequired().HasMaxLength(10);
            builder.Entity<Requirement>().Property(p => p.Semester).IsRequired().HasMaxLength(10);
            builder.Entity<Requirement>().Property(p => p.Degree).IsRequired().HasMaxLength(10);
            builder.Entity<Requirement>().Property(p => p.Description).IsRequired().HasMaxLength(10);

            //Relationships:

            //One to one with Internship
            //Already in Internship


            //Student Entity
            builder.Entity<Student>().ToTable("Students");
            builder.Entity<Student>().HasKey(p => p.Id);
            builder.Entity<Student>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Student>().Property(p => p.Username).IsRequired().HasMaxLength(10);
            builder.Entity<Student>().Property(p => p.Email).IsRequired().HasMaxLength(10);
            builder.Entity<Student>().Property(p => p.Password).IsRequired().HasMaxLength(10);
            builder.Entity<Student>().Property(p => p.DateCreated).IsRequired().HasMaxLength(10);

            //Relationships:

            //One to many with Document
            builder.Entity<Student>()
            .HasMany(d => d.Documents)
            .WithOne(d => d.Student)
            .HasForeignKey(d => d.StudentId);

            //One to many with Request
            builder.Entity<Student>()
            .HasMany(r => r.Requests)
            .WithOne(r => r.Student)
            .HasForeignKey(r => r.StudentId);

            //One to many with Qualification
            builder.Entity<Student>()
            .HasMany(q => q.Qualifications)
            .WithOne(q => q.Student)
            .HasForeignKey(q => q.StudentId);

            //One to one with Profile
            builder.Entity<Student>().HasOne(p => p.Profile)
            .WithOne(p => p.Student)
            .HasForeignKey<Profile>(p => p.StudentId);



            //Worker Entity
            builder.Entity<Worker>().ToTable("Workers");
            builder.Entity<Worker>().HasKey(p => p.Id);
            builder.Entity<Worker>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Worker>().Property(p => p.Username).IsRequired().HasMaxLength(10);
            builder.Entity<Worker>().Property(p => p.Email).IsRequired().HasMaxLength(10);
            builder.Entity<Worker>().Property(p => p.Password).IsRequired().HasMaxLength(10);
            builder.Entity<Worker>().Property(p => p.DateCreated).IsRequired().HasMaxLength(10);
            builder.Entity<Worker>().Property(p => p.Type).IsRequired().HasMaxLength(10);

            //Relationships:

            //One to many with Internship
            builder.Entity<Worker>()
            .HasMany(i => i.Internships)
            .WithOne(i => i.Worker)
            .HasForeignKey(i => i.WorkerId);

            //One to one with Profile
            builder.Entity<Worker>().HasOne(p => p.Profile)
            .WithOne(p => p.Worker)
            .HasForeignKey<Profile>(p => p.WorkerId);

            //Many to Many with Worker
            //Already in WorkerCompany Relationship

            //WorkerCompany Entity
            builder.Entity<WorkerCompany>().ToTable("WorkerCompanies");
            builder.Entity<WorkerCompany>()
            .HasKey(wc => new { wc.WorkerId, wc.CompanyId });

            //Relationships:

            //One to many with Worker
            builder.Entity<WorkerCompany>()
                .HasOne(wc => wc.Worker)
                .WithMany(w => w.WorkerCompanies)
                .HasForeignKey(wc => wc.WorkerId);

            //One to many with Company
            builder.Entity<WorkerCompany>()
                .HasOne(wc => wc.Company)
                .WithMany(c => c.WorkerCompanies)
                .HasForeignKey(wc => wc.CompanyId);


            //Missing SnakeCaseExtension
            builder.ApplySnakeCaseNamingConvention();

        }
    }
}
