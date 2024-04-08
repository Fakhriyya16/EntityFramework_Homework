using EntityFrameworkConsole.Models;
using EntityFrameworkConsole.Services;
using EntityFrameworkConsole.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkConsole.Controllers
{
    internal class CityController
    {
        private readonly ICityService _cityService;
        public CityController()
        {
            _cityService = new CityService();
        }

        public async Task GetAllByCountryId()
        {
            await Console.Out.WriteLineAsync("Add country id:");
            int countryId = int.Parse(Console.ReadLine());

            var cities = await _cityService.GetAllByCountryIdAsync(countryId);

            foreach (var city in cities)
            {
                Console.WriteLine($"Name: {city.Name}, Country: {city.Country.Name}");
            }
        }
        public async Task GetAll()
        {
            try
            {
                var cities = await _cityService.GetAllAsync();

                foreach (var city in cities)
                { 
                    await Console.Out.WriteLineAsync($"Name: {city.Name}, Country: {city.Country.Name}");
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }
        public async Task GetById()
        {
            Console.WriteLine("Add id:");
            int id = int.Parse(Console.ReadLine());

            try
            {
                var city = await _cityService.GetByIdAsync(id);
                await Console.Out.WriteLineAsync($"Name: {city.Name}, Country: {city.Country.Name}");
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }
        public async Task CreateAsync()
        {
            Console.WriteLine("Add Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Add Country Id:");
            int countryId = int.Parse(Console.ReadLine());

            await _cityService.CreateAsync(new City { Name = name, CountryId = countryId });
        }
        public async Task DeleteAsync()
        {
            Console.WriteLine("Add id:");
            int id = int.Parse(Console.ReadLine());
            try
            {
                await _cityService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }
    }
}
