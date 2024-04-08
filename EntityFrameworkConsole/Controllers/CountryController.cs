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
    internal class CountryController
    {
        private readonly ICountryService countryService;
        public CountryController()
        {
            countryService = new CountryService();
        }

        public async Task CreateAsync()
        {
            Console.WriteLine("Add Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Add Population:");
            int population = int.Parse(Console.ReadLine());

            await countryService.CreateAsync(new Country {Name=name,Population=population});
        }

        public async Task DeleteAsync()
        {
            Console.WriteLine("Add id:");
            int id = int.Parse(Console.ReadLine());
            try
            {
                await countryService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }

        public async Task GetAll()
        {
            try
            {
                var countries = await countryService.GetAllAsync();

                foreach (var country in countries)
                {
                    await Console.Out.WriteLineAsync($"Name: {country.Name}, Population: {country.Population}");
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
                var country = await countryService.GetByIdAsync(id);
                await Console.Out.WriteLineAsync($"Name: {country.Name}, Population: {country.Population}");
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }
    }
}
