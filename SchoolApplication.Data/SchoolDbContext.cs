using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolApplication.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SchoolApplication.Data.FluentAPI;

namespace SchoolApplication.Data
{
    public class SchoolDbContext : IdentityDbContext<ApplicationUser>
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<StudentInfo> StudentInfos { get; set; }
        public DbSet<TeacherInfo> TeacherInfos { get; set; }
        public DbSet<PrincipalInfo> PrincipalInfos { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ScheduledLesson> ScheduledLessons { get; set; }
        public DbSet<LessonType> LessonTypes { get; set; }
        public DbSet<StudentApplication> StudentApplications { get; set; }
        public DbSet<TeacherApplication> TeacherApplications { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());


            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                
                UserName = "yahya.wpm@gmail.com",
                NormalizedUserName = "YAHYA.WPM@GMAIL.COM",
                Email = "yahya.wpm@gmail.com",
                NormalizedEmail = "YAHYA.WPM@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Yahya77+"),
                SecurityStamp = string.Empty,
                ApplicationUserType = ApplicationUserType.Principal
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
