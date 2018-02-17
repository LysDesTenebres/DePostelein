using DePosteleinManagement.Domain;
using DePosteleinManagement.Services;
using DePosteleinManagement.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DePostelein.ViewModels
{
    public class NewEventViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private INavigationService _navigationService;
        private IDataService _dataService;
        private User _loggedInUser;

        public CustomCommand CreateNewEventCommand { get; set; }
        public CustomCommand GoBackCommand { get; set; }

        private String _menuName;
        public String MenuName
        {
            get
            {
                return _menuName;
            }
            set
            {
                _menuName = value;
                RaisePropertyChanged(nameof(MenuName));
            }
        }

        private int _guests;
        public int Guests
        {
            get
            {
                return _guests;
            }
            set
            {
                _guests = value;
                RaisePropertyChanged(nameof(Guests));
            }
        }

        private int _bread;
        public int Bread
        {
            get
            {
                return _bread;
            }
            set
            {
                _bread = value;
                RaisePropertyChanged(nameof(Bread));
            }
        }

        private String _customer;
        public String Customer
        {
            get
            {
                return _customer;
            }
            set
            {
                _customer = value;
                RaisePropertyChanged(nameof(Customer));
            }
        }

        private String _location;
        public String Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
                RaisePropertyChanged(nameof(Location));
            }
        }

        private DateTime _date;
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                RaisePropertyChanged(nameof(Date));
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public NewEventViewModel(INavigationService navigationService, IDataService dataService)
        {
            Messenger.Default.Register<User>(this, OnUserReceived);
            _dataService = dataService;
            _navigationService = navigationService;
            LoadCommands();

            GoBackCommand = new CustomCommand(GoBack, null);
        }

        private void OnUserReceived(User user)
        {
            _loggedInUser = user;
        }

        private void LoadCommands()
        {
            CreateNewEventCommand = new CustomCommand(CreateNewEvent, null);
            // CreateEventCommand = new CustomCommand(CreateEvent, CheckEventToCreate);
        }

        private void CreateNewEvent(object obj)
        {
            bool result = false;
            if (_menuName != null && _guests != 0 && _bread != 0 && _customer != null && _location != null )
            {
                result = _dataService.CreateNewEvent(_menuName, _guests, _bread, _customer, _location, _date, _loggedInUser);
            }
            if (result == true)
            {
                Messenger.Default.Send<User>(_loggedInUser);
                _navigationService.NavigateTo("MainView");
            }
        }


        private void GoBack(object obj)
        {
            Messenger.Default.Send<User>(_loggedInUser);
            _navigationService.NavigateTo("Back");
        }

    }
}
