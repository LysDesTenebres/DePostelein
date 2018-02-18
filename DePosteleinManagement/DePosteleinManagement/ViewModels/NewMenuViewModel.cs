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
    public class NewMenuViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private INavigationService _navigationService;
        private IDataService _dataService;
        private User _loggedInUser;
        private Menu _menu;

        public CustomCommand CreateNewMenuCommand { get; set; }
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

        private Double _price;
        public Double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                RaisePropertyChanged(nameof(Price));
            }
        }

        private bool _variableAmount;
        public bool VariableAmount
        {
            get
            {
                return _variableAmount;
            }
            set
            {
                _variableAmount = value;
                RaisePropertyChanged(nameof(VariableAmount));
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public NewMenuViewModel(INavigationService navigationService, IDataService dataService)
        {
            Messenger.Default.Register<User>(this, OnUserReceived);
            _dataService = dataService;
            _navigationService = navigationService;
            LoadCommands();

            CreateNewMenuCommand = new CustomCommand(CreateNewMenu, null);
            GoBackCommand = new CustomCommand(GoBack, null);
        }

        private void OnUserReceived(User user)
        {
            _loggedInUser = user;
        }

        private void LoadCommands()
        {
            CreateNewMenuCommand = new CustomCommand(CreateNewMenu, null);
            // CreateEventCommand = new CustomCommand(CreateEvent, CheckEventToCreate);
        }

        private void CreateNewMenu(object obj)
        {
            if (_menuName != null && _price != 0)
            {
                _menu = _dataService.CreateNewMenu(_menuName, _price, _variableAmount);
            }
            if (_menu == null)
            {
                List<object> objList = new List<object>();
                objList.Add(_menu);
                objList.Add(_loggedInUser);
                Messenger.Default.Send(objList);
                _navigationService.NavigateTo("NewDish");
            }
        }

        
        private void GoBack(object obj)
        {
            Messenger.Default.Send<User>(_loggedInUser);
            _navigationService.NavigateTo("Back");
        }

    }
}
