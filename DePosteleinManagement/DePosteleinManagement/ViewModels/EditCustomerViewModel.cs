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
    public class EditCustomerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private INavigationService _navigationService;
        private IDataService _dataService;
        private User _loggedInUser;
        private Customer _customer;

        public CustomCommand LoadCommand { get; set; }
        public CustomCommand CreateNewCustomerCommand { get; set; }
        public CustomCommand BackCommand { get; set; }

        private String _name;
        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        private String _surname;
        public String Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                RaisePropertyChanged(nameof(Surname));
            }
        }

        private String _adress;
        public String Adress
        {
            get
            {
                return _adress;
            }
            set
            {
                _adress = value;
                RaisePropertyChanged(nameof(Adress));
            }
        }

        private String _city;
        public String City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                RaisePropertyChanged(nameof(City));
            }
        }

        private int _postcode;
        public int Postcode
        {
            get
            {
                return _postcode;
            }
            set
            {
                _postcode = value;
                RaisePropertyChanged(nameof(Postcode));
            }
        }


        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public EditCustomerViewModel(INavigationService navigationService, IDataService dataService)
        {
            Messenger.Default.Register<List<object>>(this, OnObjectReceived);
            _dataService = dataService;
            _navigationService = navigationService;
            LoadCommands();

        }

        private void OnObjectReceived(List<object> obj)
        {
            if (obj.ElementAt(0) is Customer)
            {
                _customer = (Customer)obj.ElementAt(0);
            }

            _loggedInUser = (User)obj.ElementAt(1);

            if (_customer != null)
            {
                Name = _customer.Name;
                Surname = _customer.Surname;
                Adress = _customer.Adress;
                City = _customer.City;
                Postcode = _customer.Postcode;
            }

        }

        private void LoadCommands()
        {
            LoadCommand = new CustomCommand((obj) => {
                LoadData();
            }, null);

            CreateNewCustomerCommand = new CustomCommand(CreateNewCustomer, null);
            BackCommand = new CustomCommand(GoBack, null);
            // CreateEventCommand = new CustomCommand(CreateEvent, CheckEventToCreate);
        }

        private void LoadData()
        {
        }

        private void CreateNewCustomer(object obj)
        {
            if (_name != null && _surname != null && _adress != null && _city != null && _postcode != 0)
            {
                _dataService.EditCustomer(_name, _surname, _adress, _city, _postcode, _customer.Id);
                Messenger.Default.Send<User>(_loggedInUser);
                _navigationService.NavigateTo("MainView");
            }

        }


        private void GoBack(object obj)
        {
            Messenger.Default.Send<User>(_loggedInUser);
            _navigationService.NavigateTo("CustomerOverview");
        }

    }
}
