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
        public DelivererOverviewViewModel DelivererOverviewViewModel { get; }
        public EventOverviewViewModel EventOverviewViewModel { get; }
        public LoginViewModel LoginViewModel { get; }
        public MainViewModel MainViewModel { get; }
        public EditCustomerViewModel EditCustomerViewModel { get; }
        public EditDelivererViewModel EditDelivererViewModel { get; }
        public EditEventViewModel EditEventViewModel { get; }
        public EditStaffViewModel EditStaffViewModel { get; }
        public NewDelivererViewModel NewDelivererViewModel { get; set; }
        public NewDishViewModel NewDishViewModel { get; }
        public NewEventViewModel NewEventViewModel { get; }
        public NewMenuViewModel NewMenuViewModel { get; }
        public NewStaffViewModel NewStaffViewModel { get; }
        public StaffViewModel StaffViewModel { get; }


        public ViewModelLocator()
        {
            _navigationService = new NavigationService();
            _dataService = new DataService(new UserRepository(), new MenuRepository(), new DishRepository(), new CustomerRepository(), new DelivererRepository(), new EventRepository(), new IngredientRepository());

            CustomerOverviewViewModel = new CustomerOverviewViewModel(_navigationService, _dataService);
            DelivererOverviewViewModel = new DelivererOverviewViewModel(_navigationService, _dataService);
            EventOverviewViewModel = new EventOverviewViewModel(_navigationService, _dataService);
            LoginViewModel = new LoginViewModel(_navigationService, _dataService);
            MainViewModel = new MainViewModel(_navigationService, _dataService);
            EditCustomerViewModel = new EditCustomerViewModel(_navigationService, _dataService);
            EditDelivererViewModel = new EditDelivererViewModel(_navigationService, _dataService);
            EditEventViewModel = new EditEventViewModel(_navigationService, _dataService);
            EditStaffViewModel = new EditStaffViewModel(_navigationService, _dataService);
            NewDelivererViewModel = new NewDelivererViewModel(_navigationService, _dataService);
            NewDishViewModel = new NewDishViewModel(_navigationService, _dataService);
            NewEventViewModel = new NewEventViewModel(_navigationService, _dataService);
            NewMenuViewModel = new NewMenuViewModel(_navigationService, _dataService);
            NewStaffViewModel = new NewStaffViewModel(_navigationService, _dataService);
            StaffViewModel = new StaffViewModel(_navigationService, _dataService);
        }
    }
}
