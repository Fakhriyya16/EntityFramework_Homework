using EntityFrameworkConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkConsole.Services.Interfaces
{
    internal interface ICityService
    {
        public Task<List<City>> GetAllByCountryIdAsync(int countryId);
        public Task CreateAsync(City city);
        public Task DeleteAsync(int? id);
        public Task<List<City>> GetAllAsync();
        public Task<City> GetByIdAsync(int? id);
    }
}
