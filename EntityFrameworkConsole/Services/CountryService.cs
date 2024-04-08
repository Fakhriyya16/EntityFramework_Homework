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
    internal class CountryService : ICountryService
    {
        private readonly AppDbContext _context;
        public CountryService()
        {
            _context = new AppDbContext();
        }
        public async Task CreateAsync(Country country)
        {
            _context.Countries.Add(country);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException("Id cannot be null");
            var country = await _context.Countries.FirstOrDefaultAsync(m=>m.Id == id);
            if (country == null) throw new NotFoundException("Data not found");

            _context.Remove(country);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Country>> GetAllAsync()
        {
            var data = await _context.Countries.ToListAsync();
            if (data is null) throw new NotFoundException("Data not found");
            return data;
        }

        public async Task<Country> GetByIdAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException("Id cannot be null");
            var country = await _context.Countries.FirstOrDefaultAsync(m => m.Id == id);
            if (country == null) throw new NotFoundException("Data not found");
            return country;
        }
    }
}
