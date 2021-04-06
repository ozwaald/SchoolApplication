using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolApplication.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Data.FluentAPI
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .HasOne(p => p.PrincipalInfo)
                .WithOne(u => u.ApplicationUser)
                .HasForeignKey<PrincipalInfo>(k => k.ApplicationUserId);

            builder
                .HasOne(p => p.StudentInfo)
                .WithOne(u => u.ApplicationUser)
                .HasForeignKey<StudentInfo>(k => k.ApplicationUserId);

            builder
                .HasOne(p => p.TeacherInfo)
                .WithOne(u => u.ApplicationUser)
                .HasForeignKey<TeacherInfo>(k => k.ApplicationUserId);
        }
    }
}
