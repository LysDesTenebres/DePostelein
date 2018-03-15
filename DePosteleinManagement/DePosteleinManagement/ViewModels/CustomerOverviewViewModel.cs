using DePosteleinManagement.Domain;
using DePosteleinManagement.Services;
using DePosteleinManagement.Utility;
using DePosteleinManagement.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace DePostelein.ViewModels
{
    public class CustomerOverviewViewModel : INotifyPropertyChanged
    {
        private INavigationService _navigationService;
        private IDataService _dataService;
        private User _loggedInUser;

        public CustomCommand LoadCommand { get; set; }
        public CustomCommand CreateMenuCommand { get; set; }
        public CustomCommand CreateEventCommand { get; set; }
        public CustomCommand EventlistCommand { get; set; }
        public CustomCommand WorkersCommand { get; set; }
        public CustomCommand CustomersCommand { get; set; }
        public CustomCommand LogOutCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            get
            {
                return _customers;
            }
            set
            {
                _customers = value;
                RaisePropertyChanged(nameof(Customers));
            }
        }


        public CustomerOverviewViewModel(INavigationService navigationService, IDataService dataService)
        {
            Messenger.Default.Register<User>(this, OnUserReceived);
            _dataService = dataService;
            _navigationService = navigationService;
            LoadCommands();
        }

        private void OnUserReceived(User user)
        {
            _loggedInUser = user;
        }

        private void LoadData()
        {
            List<Customer> list = _dataService.GetAllCustomers();
            if (list != null)
            { 
                Customers = list.ToObservableCollection();
            }
            else
            {
                Customers = new ObservableCollection<Customer>();
            }
        }

        private void LoadCommands()
        {
            LoadCommand = new CustomCommand((obj) => {
                LoadData();
            }, null);
            CreateMenuCommand = new CustomCommand(CreateMenu, null);
            CreateEventCommand = new CustomCommand(CreateEvent, null);
            EventlistCommand = new CustomCommand(Eventlist, null);
            WorkersCommand = new CustomCommand(Workers, null);
            CustomersCommand = new CustomCommand(Customer, null);
            LogOutCommand = new CustomCommand(LogOut, null);
        }

        private void LogOut(object obj)
        {
            _navigationService.NavigateTo("Login");
        }

        private void CreateMenu(object obj)
        {
            Messenger.Default.Send(_loggedInUser);
            _navigationService.NavigateTo("NewMenu");
        }

        private void CreateEvent(object obj)
        {
            Messenger.Default.Send(_loggedInUser);
            _navigationService.NavigateTo("NewEvent");
        }

        private void Eventlist(object obj)
        {
            Messenger.Default.Send(_loggedInUser);
            _navigationService.NavigateTo("EventOverview");
        }

        private void Workers(object obj)
        {
            Messenger.Default.Send(_loggedInUser);
            _navigationService.NavigateTo("Staff");
        }
        private void Customer(object obj)
        {
            Messenger.Default.Send(_loggedInUser);
            _navigationService.NavigateTo("CustomerOverview");
        }
    }
}
