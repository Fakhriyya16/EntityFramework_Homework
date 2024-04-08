using EntityFrameworkConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkConsole.Services.Interfaces
{
    internal interface ICountryService
    {
        public Task CreateAsync(Country country);
        public Task DeleteAsync(int? id);
        public Task<List<Country>> GetAllAsync();
        public Task<Country> GetByIdAsync(int? id);

    }
}
