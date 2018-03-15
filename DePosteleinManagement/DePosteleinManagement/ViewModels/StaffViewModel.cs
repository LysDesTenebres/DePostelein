using DePosteleinManagement.Domain;
using DePosteleinManagement.Extensions;
using DePosteleinManagement.Services;
using DePosteleinManagement.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DePostelein.ViewModels
{
    public class StaffViewModel : INotifyPropertyChanged
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
        public CustomCommand StaffCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get
            {
                return _users;
            }
            set
            {
                _users = value;
                RaisePropertyChanged(nameof(Users));
            }
        }

        public StaffViewModel(INavigationService navigationService, IDataService dataService)
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
            List<User> list = _dataService.GetAllUsers();
            if (list != null)
            {
                Users = list.ToObservableCollection();
            }
            else
            {
                Users = new ObservableCollection<User>();
            }
;
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
            CustomersCommand = new CustomCommand(Customers, null);
            LogOutCommand = new CustomCommand(LogOut, null);
            StaffCommand = new CustomCommand(Staff, null);
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

        private void Customers(object obj)
        {
            Messenger.Default.Send<User>(_loggedInUser);
            _navigationService.NavigateTo("CustomerOverview");
        }

        private void Staff(object obj)
        {
            Messenger.Default.Send<User>(_loggedInUser);
            _navigationService.NavigateTo("NewStaff");
        }
    }
}
