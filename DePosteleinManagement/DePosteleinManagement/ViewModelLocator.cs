using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DePosteleinManagement.Services;
using DePosteleinManagement.DAL.API;
using DePosteleinManagement.ViewModels;
using DePostelein.ViewModels;

namespace DePosteleinManagement
{
    public class ViewModelLocator
    {
        private readonly INavigationService _navigationService;
        private readonly IDataService _dataService;

        public CustomerOverviewViewModel CustomerOverviewViewModel { get; }
        public EventOverviewViewModel EventOverviewViewModel { get; }
        public LoginViewModel LoginViewModel { get; }
        public MainViewModel MainViewModel { get; }
        public NewDishViewModel NewDishViewModel { get; }
        public NewEventViewModel NewEventViewModel { get; }
        public NewMenuViewModel NewMenuViewModel { get; }
        public StaffViewModel StaffViewModel { get; }


        public ViewModelLocator()
        {
            _navigationService = new NavigationService();
            _dataService = new DataService(new UserRepository(), new MenuRepository(), new DishRepository(), new CustomerRepository(), new DelivererRepository(), new EventRepository(), new IngredientRepository());

            CustomerOverviewViewModel = new CustomerOverviewViewModel(_navigationService, _dataService);
            EventOverviewViewModel = new EventOverviewViewModel(_navigationService, _dataService);
            LoginViewModel = new LoginViewModel(_navigationService, _dataService);
            MainViewModel = new MainViewModel(_navigationService, _dataService);
            NewDishViewModel = new NewDishViewModel(_navigationService, _dataService);
            NewEventViewModel = new NewEventViewModel(_navigationService, _dataService);
            NewMenuViewModel = new NewMenuViewModel(_navigationService, _dataService);
            StaffViewModel = new StaffViewModel(_navigationService, _dataService);
        }
    }
}
