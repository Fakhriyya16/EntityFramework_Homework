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
    internal class CityService : ICityService
    {
        private readonly AppDbContext _context;
        public CityService()
        {
            _context = new AppDbContext();
        }

        public async Task CreateAsync(City city)
        {
             _context.Cities.Add(city);
             _context.SaveChanges();
        }

        public async Task DeleteAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException("Id cannot be null");
            var city = await _context.Cities.Include(m=>m.Country).FirstOrDefaultAsync(m => m.Id == id);
            if (city == null) throw new NotFoundException("Data not found");

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
        }

        public async Task<List<City>> GetAllAsync()
        {
            var data =  await _context.Cities.Include(m=>m.Country).ToListAsync();
            if (data is null) throw new NotFoundException("Data not found");
            return data;
        }

        public async Task<List<City>> GetAllByCountryIdAsync(int countryId)
        {
            var data = await _context.Cities.Include(m=>m.Country).Where(m=>m.CountryId == countryId).ToListAsync();
            return data;
        }

        public async Task<City> GetByIdAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException("Id cannot be null");
            var city = await _context.Cities.Include(m=>m.Country).FirstOrDefaultAsync(m => m.Id == id);
            if (city == null) throw new NotFoundException("Data not found");
            return city;
        }
    }
}
