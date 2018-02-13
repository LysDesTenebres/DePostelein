using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DePosteleinManagement.Services;
using DePosteleinManagement.DAL.API;
using DePosteleinManagement.ViewModels;

namespace DePosteleinManagement
{
    public class ViewModelLocator
    {
        private readonly INavigationService _navigationService;
        private readonly IDataService _dataService;

        public LoginViewModel LoginViewModel {get;}
        public MainViewModel MainViewModel { get; }


        public ViewModelLocator()
        {
            _navigationService = new NavigationService();
            _dataService = new DataService(new UserRepository(), new MenuRepository(), new DishRepository()); //needs to receive repositories

            LoginViewModel = new LoginViewModel(_navigationService, _dataService);
            MainViewModel = new MainViewModel(_navigationService, _dataService);
        }
    }
}
