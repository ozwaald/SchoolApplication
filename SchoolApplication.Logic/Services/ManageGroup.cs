using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolApplication.Contracts.ViewModels;
using SchoolApplication.Data;
using SchoolApplication.Data.Models;
using SchoolApplication.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Logic.Services
{
    public class ManageGroup : IManageGroup
    {
        private readonly SchoolDbContext dbContext;
        private readonly IMapper mapper;

        public ManageGroup(SchoolDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task CreateGroupAsync(GroupViewModel groupViewModel)
        {
            var group = mapper.Map<Group>(groupViewModel);

            await dbContext.Groups.AddAsync(group);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete<T>(T entity) where T : class
        {
            dbContext.Remove(entity);

            await dbContext.SaveChangesAsync();
        }
        //public async Task DeleteGroupAsync(string name)
        //{
        //    var group = dbContext.Groups.FirstOrDefaultAsync(g => g.Name == name);

        //    if (group != null)
        //    {
        //        dbContext.Remove(entity);
        //    }
        //    await dbContext.SaveChangesAsync();
        //}
    }
}
