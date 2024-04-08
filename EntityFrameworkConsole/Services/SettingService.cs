using EntityFrameworkConsole.Data;
using EntityFrameworkConsole.Helpers.Exceptions;
using EntityFrameworkConsole.Models;
using EntityFrameworkConsole.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkConsole.Services
{
    internal class SettingService : ISettingService
    {
        private readonly AppDbContext appDbContext;
        public SettingService()
        {
            appDbContext = new AppDbContext();
        }
        public async Task CreateAsync(Setting setting)
        {
            await appDbContext.Settings.AddAsync(setting);
            await appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException("Id cant be null");
            var data = await appDbContext.Settings.FirstOrDefaultAsync(m => m.Id == id);
            if (data is null) throw new NotFoundException("Data Not Found");

            appDbContext.Remove(data);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<List<Setting>> GetAllAsync()
        {
            return await appDbContext.Settings.ToListAsync();
        }

        public async Task<Setting> GetByIdAsync(int id)
        {
            var data =  await appDbContext.Settings.FirstOrDefaultAsync(m => m.Id == id);
            if (data is null) throw new NotFoundException("Data Not Found");
            return data;
        }

        public Task UpdateAsync(Setting setting)
        {
            throw new NotImplementedException();
        }
    }
}
