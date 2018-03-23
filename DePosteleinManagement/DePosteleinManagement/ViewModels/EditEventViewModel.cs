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
    public class EditEventViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private INavigationService _navigationService;
        private IDataService _dataService;
        private User _loggedInUser;
        private Event _event;

        public CustomCommand LoadCommand { get; set; }
        public CustomCommand CreateNewEventCommand { get; set; }
        public CustomCommand BackCommand { get; set; }

        private ObservableCollection<Menu> _menus;
        public ObservableCollection<Menu> Menus
        {
            get
            {
                return _menus;
            }
            set
            {
                _menus = value;
                RaisePropertyChanged(nameof(Menus));
            }
        }

        private Menu _menuName;
        public Menu MenuName
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

        private DateTimeOffset _date = DateTime.Now;
        public DateTimeOffset EventDate
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                RaisePropertyChanged(nameof(EventDate));
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public EditEventViewModel(INavigationService navigationService, IDataService dataService)
        {
            Messenger.Default.Register<List<object>>(this, OnObjectReceived);
            _dataService = dataService;
            _navigationService = navigationService;
            LoadCommands();

        }

        private void OnObjectReceived(List<object> obj)
        {
            if (obj.ElementAt(0) is Event)
            {
                _event = (Event)obj.ElementAt(0);
            }
           
            _loggedInUser = (User)obj.ElementAt(1);

            if (_event != null)
            {
                Guests = _event.Guests;
                Bread = _event.Bread;
                Location = _event.Location;

                System.DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                if (_event.Date.ToString().Length == 13)
                {
                    date = date.AddMilliseconds((long)_event.Date);
                }
                else
                {
                    date = date.AddSeconds((long)_event.Date);
                }

                EventDate = date;     
            }

        }

        private void LoadCommands()
        {
            LoadCommand = new CustomCommand((obj) => {
                LoadData();
            }, null);

            CreateNewEventCommand = new CustomCommand(CreateNewEvent, null);
            BackCommand = new CustomCommand(GoBack, null);
            // CreateEventCommand = new CustomCommand(CreateEvent, CheckEventToCreate);
        }

        private void LoadData()
        {
            List<Menu> list = _dataService.GetAllMenus();
            if (list != null)
            {
                Menus = list.ToObservableCollection();
            }
            else
            {
                Menus = new ObservableCollection<Menu>();
            }
            MenuName = Menus.Where(o => o.Name.ToString().Equals(_event.Menu)).ToList().FirstOrDefault();
        }

        private void CreateNewEvent(object obj)
        {
            if (_menuName != null && _guests != 0 && _customer != null && _location != null)
            {
                long epocheDate = (_date.Ticks - 621355968000000000) / 10000;
                _dataService.EditEvent(_menuName, _guests, _bread, _customer, _location, epocheDate, _event.Id);
                Messenger.Default.Send<User>(_loggedInUser);
                _navigationService.NavigateTo("MainView");
            }

        }


        private void GoBack(object obj)
        {
            Messenger.Default.Send<User>(_loggedInUser);
            _navigationService.NavigateTo("EventOverview");
        }

    }
}
