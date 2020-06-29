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
        public DbSet<User> Users { get; set; }
        public DbSet<UserCompany> UserCompanies { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Company Entity
            builder.Entity<Company>().ToTable("Companies");
            builder.Entity<Company>().HasKey(p => p.Id);
            builder.Entity<Company>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Company>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Company>().Property(p => p.Description).IsRequired().HasMaxLength(300);
            builder.Entity<Company>().Property(p => p.Sector).IsRequired().HasMaxLength(30);
            builder.Entity<Company>().Property(p => p.Email).IsRequired().HasMaxLength(30);
            builder.Entity<Company>().Property(p => p.Phone).IsRequired().HasMaxLength(20);
            builder.Entity<Company>().Property(p => p.Address).IsRequired().HasMaxLength(40);
            builder.Entity<Company>().Property(p => p.Country).IsRequired().HasMaxLength(20);
            builder.Entity<Company>().Property(p => p.City).IsRequired().HasMaxLength(20);

            //Relationships:

            //One to many with Qualifications
            builder.Entity<Company>().HasMany(p => p.Qualifications)
                .WithOne(p => p.Company);

            //One to many with Internships
            builder.Entity<Company>().HasMany(p => p.Internships)
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
            builder.Entity<Internship>().Property(p => p.Description).IsRequired().HasMaxLength(300);
            builder.Entity<Internship>().Property(p => p.PublicationDate).HasMaxLength(40);
            builder.Entity<Internship>().Property(p => p.StartingDate).HasMaxLength(40);
            builder.Entity<Internship>().Property(p => p.FinishingDate).HasMaxLength(40);
            builder.Entity<Internship>().Property(p => p.Salary).IsRequired().HasMaxLength(30);
            builder.Entity<Internship>().Property(p => p.Location).IsRequired();
            builder.Entity<Internship>().Property(p => p.RequiredDocuments).IsRequired();

            //Relationships:

            //One to One with Requirement
            builder.Entity<Internship>().HasOne(p => p.Requirement)
            .WithOne(p => p.Internship)
            .HasForeignKey<Requirement>(p => p.InternshipId);

            //One to Many with Request
            builder.Entity<Internship>().HasMany(p => p.Requests)
                .WithOne(p => p.Internship).HasForeignKey(p => p.InternshipId);

            //One to Many with Company
            //Already in Company Relationship



            //Profile Entity
            builder.Entity<Profile>().ToTable("Profiles");
            builder.Entity<Profile>().HasKey(p => p.Id);
            builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Profile>().Property(p => p.Role).IsRequired();
            builder.Entity<Profile>().Property(p => p.FirstName).IsRequired();
            builder.Entity<Profile>().Property(p => p.LastName).IsRequired();
            builder.Entity<Profile>().Property(p => p.Field);
            builder.Entity<Profile>().Property(p => p.Phone);
            builder.Entity<Profile>().Property(p => p.Description);
            builder.Entity<Profile>().Property(p => p.Country);
            builder.Entity<Profile>().Property(p => p.City);
            //Properties only required for Student
            builder.Entity<Profile>().Property(p => p.University);
            builder.Entity<Profile>().Property(P => P.Degree);
            builder.Entity<Profile>().Property(p => p.Semester);

            //Relationships:

            //One to one with User
            //Already in User Relationship



            //Qualification Entity
            builder.Entity<Qualification>().ToTable("Qualifications");
            builder.Entity<Qualification>().HasKey(p => p.Id);
            builder.Entity<Qualification>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Qualification>().Property(p => p.Comment).IsRequired().HasMaxLength(100);
            builder.Entity<Qualification>().Property(p => p.Score).IsRequired();
            builder.Entity<Qualification>().Property(p => p.Author).IsRequired().HasMaxLength(10);

            //Relationships:

            //One to one with User
            //Already in User Relationship

            //One to one with Company
            //Already in Company Relationship



            //Request Entity
            builder.Entity<Request>().ToTable("Requests");
            builder.Entity<Request>()
                        .HasKey(wc => new { wc.UserId, wc.InternshipId });

            //Relationships:

            //One to one with User
            //Already in User Relationship

            //One to one with Internship
            //Already in Internship Relationship



            //Requirement Entity
            builder.Entity<Requirement>().ToTable("Requirements");
            builder.Entity<Requirement>().HasKey(p => p.Id);
            builder.Entity<Requirement>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Requirement>().Property(p => p.Field).IsRequired().HasMaxLength(30);
            builder.Entity<Requirement>().Property(p => p.Semester).IsRequired();

            //Relationships:

            //One to one with Internship
            //Already in Internship


            //User Entity
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Username).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(40);
            builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.DateCreated).HasMaxLength(20);
            builder.Entity<User>().Property(p => p.Token);

            //Relationships Student:

            //One to many with Document
            builder.Entity<User>()
            .HasMany(d => d.Documents)
            .WithOne(d => d.User)
            .HasForeignKey(d => d.UserId);

            //One to many with Request
            builder.Entity<User>()
            .HasMany(r => r.Requests)
            .WithOne(r => r.User)
            .HasForeignKey(r => r.UserId);

            //One to many with Qualification
            builder.Entity<User>()
            .HasMany(q => q.Qualifications)
            .WithOne(q => q.User);

            //One to one with Profile
            builder.Entity<User>().HasOne(p => p.Profile)
            .WithOne(p => p.User)
            .HasForeignKey<Profile>(p => p.UserId);


            //Relationships Company:

            //Many to Many with User
            //Already in UserCompany Relationship



            //UserCompany Entity
            builder.Entity<UserCompany>().ToTable("UserCompanies");
            builder.Entity<UserCompany>()
            .HasKey(wc => new { wc.UserId, wc.CompanyId });

            //Relationships:

            //One to many with User
            builder.Entity<UserCompany>()
                .HasOne(wc => wc.User)
                .WithMany(w => w.UserCompanies)
                .HasForeignKey(wc => wc.UserId);

            //One to many with Company
            builder.Entity<UserCompany>()
                .HasOne(wc => wc.Company)
                .WithMany(c => c.UserCompanies)
                .HasForeignKey(wc => wc.CompanyId);


            //Missing SnakeCaseExtension
            builder.ApplySnakeCaseNamingConvention();

        }
    }
}
