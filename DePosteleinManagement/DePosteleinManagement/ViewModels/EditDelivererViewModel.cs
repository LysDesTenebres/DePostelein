using DePosteleinManagement.DAL;
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
    public class EditDelivererViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private INavigationService _navigationService;
        private IDataService _dataService;
        private User _loggedInUser;
        private Deliverer _deliverer;

        public CustomCommand LoadCommand { get; set; }
        public CustomCommand CreateNewDelivererCommand { get; set; }
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

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public EditDelivererViewModel(INavigationService navigationService, IDataService dataService)
        {
            Messenger.Default.Register<List<object>>(this, OnObjectReceived);
            _dataService = dataService;
            _navigationService = navigationService;
            LoadCommands();

        }

        private void OnObjectReceived(List<object> obj)
        {
            if (obj.ElementAt(0) is Deliverer)
            {
                _deliverer = (Deliverer)obj.ElementAt(0);
            }
          
            _loggedInUser = (User)obj.ElementAt(1);

            if (_deliverer != null)
            {
                Name = _deliverer.Name;
            }

        }

        private void LoadCommands()
        {
            LoadCommand = new CustomCommand((obj) =>
            {
                LoadData();
            }, null);

            CreateNewDelivererCommand = new CustomCommand(CreateNewDeliverer, null);
            BackCommand = new CustomCommand(GoBack, null);
            // CreateEventCommand = new CustomCommand(CreateEvent, CheckEventToCreate);
        }

        private void LoadData()
        {
        }

        private void CreateNewDeliverer(object obj)
        {
            if (_name != null)
            {
                _dataService.EditDeliverer(_name, _deliverer.Id);
                Messenger.Default.Send<User>(_loggedInUser);
                _navigationService.NavigateTo("Deliverer");
            }

        }


        private void GoBack(object obj)
        {
            Messenger.Default.Send<User>(_loggedInUser);
            _navigationService.NavigateTo("Deliverer");
        }

    }
}