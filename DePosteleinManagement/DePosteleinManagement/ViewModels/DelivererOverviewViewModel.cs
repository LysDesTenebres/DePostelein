using DePosteleinManagement.DAL;
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
    public class DelivererOverviewViewModel : INotifyPropertyChanged
    {
        private INavigationService _navigationService;
        private IDataService _dataService;
        private User _loggedInUser;

        public CustomCommand LoadCommand { get; set; }
        public CustomCommand CreateMenuCommand { get; set; }
        public CustomCommand CreateEventCommand { get; set; }
        public CustomCommand EventlistCommand { get; set; }
        public CustomCommand WorkersCommand { get; set; }
        public CustomCommand DeliverersCommand { get; set; }
        public CustomCommand CustomersCommand { get; set; }
        public CustomCommand NewDelivererCommand { get; set; }
        public CustomCommand EditDelivererCommand { get; set; }
        public CustomCommand DeleteDelivererCommand { get; set; }
        public CustomCommand LogOutCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private ObservableCollection<Deliverer> _deliverers;
        public ObservableCollection<Deliverer> Deliverer
        {
            get
            {
                return _deliverers;
            }
            set
            {
                _deliverers = value;
                RaisePropertyChanged(nameof(Deliverer));
            }
        }

        private Deliverer _selectedDeliverer ;
        public Deliverer SelectedDeliverer
        {
            get
            {
                return _selectedDeliverer ;
            }
            set
            {
                 _selectedDeliverer = value;
                RaisePropertyChanged(nameof(SelectedDeliverer));
            }
        }


        public DelivererOverviewViewModel(INavigationService navigationService, IDataService dataService)
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
            List<Deliverer> list = _dataService.GetAllDeliverers();
            if (list != null)
            {
                Deliverer = list.ToObservableCollection();
            }
            else
            {
                Deliverer = new ObservableCollection<Deliverer>();
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
            DeliverersCommand = new CustomCommand(Deliverers, null);
            CustomersCommand = new CustomCommand(Customers, null);
            NewDelivererCommand = new CustomCommand(NewDeliverer, null);
            EditDelivererCommand = new CustomCommand(EditDeliverer, null);
            DeleteDelivererCommand = new CustomCommand(DeleteDeliverer, null);
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

        private void Deliverers(object obj)
        {
            Messenger.Default.Send(_loggedInUser);
            _navigationService.NavigateTo("Deliverer");
        }

        private void Workers(object obj)
        {
            Messenger.Default.Send(_loggedInUser);
            _navigationService.NavigateTo("Staff");
        }
        private void Customers(object obj)
        {
            Messenger.Default.Send(_loggedInUser);
            _navigationService.NavigateTo("CustomerOverview");
        }

        private void NewDeliverer(object obj)
        {
            Messenger.Default.Send(_loggedInUser);
            _navigationService.NavigateTo("NewDeliverer");
        }

        private void EditDeliverer(object obj)
        {
            if (_selectedDeliverer != null)
            {
                List<object> objList = new List<object>();
                objList.Add(_selectedDeliverer);
                objList.Add(_loggedInUser);
                Messenger.Default.Send(objList);
                _navigationService.NavigateTo("EditDeliverer");
            }
        }

        private void DeleteDeliverer(object obj)
        {
            if (_selectedDeliverer != null)
            {
                List<Ingredient> list = _dataService.GetIngredientsByDelivererId(_selectedDeliverer);
                foreach (Ingredient ingredient in list)
                {
                    _dataService.DeleteIngredient(ingredient);
                }
                _dataService.DeleteDeliverer(_selectedDeliverer);

                Messenger.Default.Send(_loggedInUser);
                _navigationService.NavigateTo("DelivererOverview");
            }
        }
    }
}
