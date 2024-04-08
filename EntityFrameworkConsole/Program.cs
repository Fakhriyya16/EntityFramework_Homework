using EntityFrameworkConsole.Controllers;

SettingController settingController = new SettingController();
CityController cityController = new CityController();
CountryController countryController = new CountryController();

//await settingController.GetAll();

////await settingController.GetById();

////await settingController.CreateAsync();

//await settingController.DeleteAsync();

//await settingController.GetAll();

//await cityController.GetAllByCountryId();

//await countryController.GetAll();

//await countryController.CreateAsync();

//await countryController.GetAll();

//await countryController.DeleteAsync();

//await countryController.GetAll();

//await countryController.GetById();

await cityController.GetAll();
await cityController.CreateAsync();
await cityController.GetAll();
await cityController.DeleteAsync();
await cityController.GetAll();
await cityController.GetById();



