using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CVProjekt1._0.Models
{
    public class CVContext : IdentityDbContext<User>
    {
        public CVContext(DbContextOptions<CVContext> options) : base(options)
        {
        }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectUser> ProjectUsers { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectUser>().
                HasKey(pu => new { pu.ProjectId, pu.UserId });

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<User>()
                .HasMany(u => u.ReceivedMessages)
                .WithOne(m => m.Receiver)
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectUser>()
                .HasOne(pu => pu.Project)
                .WithMany(p => p.ProjectUsers)
                .HasForeignKey(pu => pu.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProjectUser>()
                .HasOne(pu => pu.User)
                .WithMany(u => u.ProjectUsers)
                .HasForeignKey(pu => pu.UserId)
                .OnDelete(DeleteBehavior.NoAction);

//            modelBuilder.Entity<User>().HasData(
//                new User
//                {
//                    UserId = "1",
//                    UserName = "ExampleUser1",
//                },
//                new User
//                {
//                    UserId = "2",
//                    UserName="ExampleUser2",
//                }
//);

//            modelBuilder.Entity<Education>().HasData(
//                new Education { EducationId = 1, ResumeId = 1, EducationType = "Bachelor's in Computer Science" },
//                new Education { EducationId = 2, ResumeId = 2, EducationType = "Master's in Business Administration" }
//            );

//            modelBuilder.Entity<Experience>().HasData(
//                new Experience { ExperienceId = 1, ResumeId = 1, ExperienceDescription = "Software Engineer" },
//                new Experience { ExperienceId = 2, ResumeId = 2, ExperienceDescription = "Project Manager" }
//            );

//            modelBuilder.Entity<Skill>().HasData(
//                new Skill { SkillId = 1, ResumeId = 1, SkillName = "C#", SkillDescription = "C# blablabla" },
//                new Skill { SkillId = 2, ResumeId = 2, SkillName = "Project Management", SkillDescription = "ProjectManagement blablabla" }
//            );

//            modelBuilder.Entity<Project>().HasData(
//                new Project { ProjectId = 1, Title = "Web Application Development", Description = "Developing a web application", CreatorId = "1" },
//                new Project { ProjectId = 2, Title = "Business Strategy Planning", Description = "Planning business strategies", CreatorId = "2" }
//            );

//            modelBuilder.Entity<Resume>().HasData(
//                new Resume { ResumeId = 1, UserId = "1" },
//                new Resume { ResumeId = 2, UserId = "2" }
//            );

//            modelBuilder.Entity<ProjectUser>().HasData(
//                new ProjectUser { ProjectId = 1, UserId = "1" },
//                new ProjectUser { ProjectId = 2, UserId = "2" }
//            );
        }
    }
}
