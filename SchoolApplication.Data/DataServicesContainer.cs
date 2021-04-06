using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SchoolApplication.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Data
{
    public class DataServicesContainer
    {
        public static void Register(IServiceCollection services, string connectionString)
        {
            services.AddDbContextPool<SchoolDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<SchoolDbContext>();
        }
    }
}
