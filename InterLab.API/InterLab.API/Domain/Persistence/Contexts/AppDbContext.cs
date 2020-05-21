using System;
using Microsoft.EntityFrameworkCore;
using InterLab.API.Domain.Models;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InterLab.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Internship> Internships { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<UserData> UserDatas { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Worker> Workers { get; set; }

        //public DbSet<Roles_Processes> Roles_Processes { get; set; }


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


            //2. Document Entity
            builder.Entity<Document>().ToTable("Documents");
            builder.Entity<Document>().HasKey(p => p.Id);
            builder.Entity<Document>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Document>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Document>().Property(p => p.Description).IsRequired().HasMaxLength(200);
            //Relationships
            builder.Entity<Document>().HasOne(p => p.Student)
                .WithMany(p => p.Documents).HasForeignKey(p => p.UserId);


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
            builder.Entity<Internship>().HasMany(p => p.Requests)
                .WithOne(p => p.Internship).HasForeignKey(p => p.InternshipId);

            //4. Process Entity
            builder.Entity<Process>().ToTable("Processes");
            builder.Entity<Process>().HasKey(p => p.Id);
            builder.Entity<Process>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Process>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Process>().Property(p => p.Description).IsRequired().HasMaxLength(50);
            //Relationships



            // 5. Profile Entity
            builder.Entity<Profile>().ToTable("Profiles");
            builder.Entity<Profile>().HasKey(p => p.Id);
            builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Profile>().Property(p => p.Field).IsRequired();
            builder.Entity<Profile>().Property(p => p.semester).IsRequired();
            builder.Entity<Profile>().Property(P => P.Degree).IsRequired();
            builder.Entity<Profile>().Property(p => p.Description).IsRequired();
            
 
            

            //6. UserData Entity
            builder.Entity<UserData>().ToTable("UserDatas");
            builder.Entity<UserData>().HasKey(p => p.Id);
            builder.Entity<UserData>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UserData>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Entity<UserData>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
            builder.Entity<UserData>().Property(p => p.Mail).IsRequired().HasMaxLength(30);
            //Buscar como hacerlo tipo Date
            builder.Entity<UserData>().Property(p => p.Date_Register).IsRequired().HasMaxLength(30);
            builder.Entity<UserData>().Property(p => p.Phone_numbre).IsRequired().HasMaxLength(10);
            builder.Entity<UserData>().Property(p => p.City).IsRequired().HasMaxLength(30);
            builder.Entity<UserData>().Property(p => p.Country).IsRequired().HasMaxLength(20);
            builder.Entity<UserData>().Property(p => p.Type).IsRequired().GetType();
            //RelationShips
            builder.Entity<UserData>().HasOne(p => p.User)
                .WithMany(P => P.UserDatas).HasForeignKey(P => P.UserId);



            //7. Qualification Entity
            builder.Entity<Qualification>().ToTable("Qualifications");
            builder.Entity<Qualification>().HasKey(p => p.Id);
            builder.Entity<Qualification>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Qualification>().Property(p => p.Comment).IsRequired().HasMaxLength(50);
            builder.Entity<Qualification>().Property(p => p.Score).IsRequired().HasMaxLength(10);


            //8. Request Entity
            builder.Entity<Request>().ToTable("Requests");
            builder.Entity<Request>().HasKey(p => p.Id);
            builder.Entity<Request>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Request>().Property(p => p.State).IsRequired().HasMaxLength(10);
            builder.Entity<Request>().Property(p => p.DateSend).IsRequired().HasMaxLength(10);


            //9. Role Entity
            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<Role>().HasKey(p => p.Id);
            builder.Entity<Role>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Role>().Property(p => p.Name).IsRequired().HasMaxLength(10);
            builder.Entity<Role>().Property(p => p.Mail).IsRequired().HasMaxLength(20);
            builder.Entity<Role>().Property(p => p.Type).IsRequired().HasMaxLength(10);
            builder.Entity<Role>().Property(p => p.Description).IsRequired().HasMaxLength(30);
            //RelattionShips  



            //10. Student Entity
            builder.Entity<Student>().ToTable("Students");
            builder.Entity<Student>().HasKey(p => p.Id);

            builder.Entity<Student>().HasOne(p => p.Users)
                  .WithMany(p => p.Students).HasForeignKey(p => p.UserId);

            builder.Entity<Student>().HasMany(p => p.Qualifications)
                .WithOne(p => p.Student).HasForeignKey(p => p.UserId);

            builder.Entity<Student>().HasMany(p => p.Requests)
                .WithOne(p => p.Student).HasForeignKey(p => p.UserId);


            //11. Worker Entity
            builder.Entity<Worker>().ToTable("Workers");
            //Relationship
            builder.Entity<Worker>().HasOne(p => p.Users)
               .WithMany(p => p.Workers).HasForeignKey(p => p.Userid);

            builder.Entity<Worker>()
                .HasKey(t => new { t.Userid, t.CompanyId });

            builder.Entity<Worker>().HasOne(p => p.Company)
                .WithMany(p => p.Workers).HasForeignKey(p => p.CompanyId);

            builder.Entity<Worker>().HasOne(p => p.Users)
                .WithMany(p => p.Workers).HasForeignKey(p => p.Userid);

          
                
 

        }
    }
}
