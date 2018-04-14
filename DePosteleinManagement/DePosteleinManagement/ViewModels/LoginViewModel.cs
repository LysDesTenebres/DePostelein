using DePosteleinManagement.Domain;
using DePosteleinManagement.Services;
using DePosteleinManagement.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DePosteleinManagement.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private INavigationService _navigationService;
        private IDataService _dataService;

        public CustomCommand LoginCommand { get; set; }

        private String _username;
        public String Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                RaisePropertyChanged(nameof(Username));
            }
        }

        private String _password;
        public String Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }

        public LoginViewModel(INavigationService navigationService, IDataService dataService)
        {
            _dataService = dataService;
            _navigationService = navigationService;
            LoadCommands();
        }
        private void LoadCommands()
        {
            LoginCommand = new CustomCommand(Login, ValidateLogin);
        }

        private bool ValidateLogin(object obj)
        {
            //User user = _dataService.CheckCredentials(Username, Password);

            //return user != null;
            return true;
        }

        private void Login(object obj)
        {
            User user = _dataService.CheckCredentials(Username, Password);
            //User user = _dataService.CheckCredentials("testadmin", "test");
            if (user != null)
            {
                _navigationService.NavigateTo("MainView");
                Messenger.Default.Send(user);
            }
        }
    }
}
