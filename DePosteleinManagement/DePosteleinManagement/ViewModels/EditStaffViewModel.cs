using ClassLibrary2.Enums;
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
    public class EditStaffViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private PasswordGeneratorService _pwGenerator;
        private EmailService _mailService;
        private INavigationService _navigationService;
        private IDataService _dataService;
        private User _loggedInUser;
        private User _user;

        public CustomCommand CreateNewUserCommand { get; set; }
        public CustomCommand BackCommand { get; set; }
        public CustomCommand LoadCommand { get; set; }

        private ObservableCollection<UserRole> _userRoles;
        public ObservableCollection<UserRole> UserRoles
        {
            get
            {
                return _userRoles;
            }
            set
            {
                _userRoles = value;
                RaisePropertyChanged(nameof(UserRoles));
            }
        }

        private UserRole _userRole;
        public UserRole UserRole
        {
            get
            {
                return _userRole;
            }
            set
            {
                _userRole = value;
                RaisePropertyChanged(nameof(UserRole));
            }
        }

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

        private String _login;
        public String Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                RaisePropertyChanged(nameof(Login));
            }
        }

        private String _email;
        public String EMail
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                RaisePropertyChanged(nameof(EMail));
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public EditStaffViewModel(INavigationService navigationService, IDataService dataService)
        {
            Messenger.Default.Register<List<object>>(this, OnObjectReceived);
            _dataService = dataService;
            _navigationService = navigationService;
            _pwGenerator = new PasswordGeneratorService();
            _mailService = new EmailService();
            LoadCommands();

            BackCommand = new CustomCommand(GoBack, null);
        }

        private void OnObjectReceived(List<object> obj)
        {
            if (obj.ElementAt(0) is User)
            {
                _user = (User)obj.ElementAt(0);
            }

            _loggedInUser = (User)obj.ElementAt(1);

            if (_user != null)
            {
                UserRole = _user.UserRole;
                Name = _user.Name;
                Login = _user.Login;
                EMail = _user.EMail;
            }

        }

        private void LoadCommands()
        {
            LoadCommand = new CustomCommand((obj) => {
                LoadData();
            }, null);
            CreateNewUserCommand = new CustomCommand(CreateNewUser, null);
        }

        private void LoadData()
        {
            List<UserRole> list = Enum.GetValues(typeof(UserRole)).Cast<UserRole>().ToList();
            if (list != null)
            {
                UserRoles = list.ToObservableCollection();
            }
            else
            {
                UserRoles = new ObservableCollection<UserRole>();
            }
        }


        private void CreateNewUser(object obj)
        {
            String password = null;
            if (_name != null && _login != null && _email != null)
            {

                password = _pwGenerator.GeneratePassword();
                _dataService.EditUser(password, _name, _login, _email, _userRole, _user.Id);
                _mailService.SendEmailAsync(_email, _login, password);
                Messenger.Default.Send<User>(_loggedInUser);
                _navigationService.NavigateTo("Staff");
            }

        }


        private void GoBack(object obj)
        {
            Messenger.Default.Send<User>(_loggedInUser);
            _navigationService.NavigateTo("Staff");
        }

    }
}
