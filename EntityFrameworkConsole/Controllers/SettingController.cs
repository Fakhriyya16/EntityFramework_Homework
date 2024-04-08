using EntityFrameworkConsole.Helpers.Exceptions;
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
    internal class SettingController
    {
        private readonly ISettingService _settingService;
        public SettingController()
        {
            _settingService = new SettingService();
        }

        public async Task GetAll()
        {
            var settings = await _settingService.GetAllAsync();

            foreach (var setting in settings)
            {
                Console.WriteLine($"Name: {setting.Name}, Email: {setting.Email}, Phone: {setting.Phone}, Address: {setting.Address}");
            }
        }

        public async Task GetById()
        {
            Console.WriteLine("Add id:");
            int id = int.Parse(Console.ReadLine());

            try
            {
                var result = await _settingService.GetByIdAsync(id);

                if (result == null)
                {
                    throw new NotFoundException("Data Not Found");
                }
                Console.WriteLine($"Name: {result.Name}, Email: {result.Email}, Phone: {result.Phone}, Address: {result.Address}");
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

            Console.WriteLine("Add Email:");
            string email = Console.ReadLine();

            Console.WriteLine("Add Phone:");
            string phone = Console.ReadLine();

            Console.WriteLine("Add Address:");
            string address = Console.ReadLine();

            await _settingService.CreateAsync(new Setting { Name = name, Email = email, Phone = phone, Address = address });
        }

        public async Task DeleteAsync()
        {
            Console.WriteLine("Add id:");
            int id = int.Parse(Console.ReadLine());
            try
            {
                await _settingService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
            
        }
    }
}
