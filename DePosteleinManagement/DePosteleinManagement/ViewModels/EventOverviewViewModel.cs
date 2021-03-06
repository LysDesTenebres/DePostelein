﻿using DePosteleinManagement.Domain;
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
    public class EventOverviewViewModel : INotifyPropertyChanged
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
        public CustomCommand EditEventCommand { get; set; }
        public CustomCommand DeleteEventCommand { get; set; }
        public CustomCommand LogOutCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private ObservableCollection<Event> _events;
        public ObservableCollection<Event> Events
        {
            get
            {
                return _events;
            }
            set
            {
                _events = value;
                RaisePropertyChanged(nameof(Events));
            }
        }

        private Event _selectedEvent  ;
        public Event SelectedEvent
        {
            get
            {
                return _selectedEvent;
            }
            set
            {
                _selectedEvent = value;
                RaisePropertyChanged(nameof(SelectedEvent));
}
        }


        public EventOverviewViewModel(INavigationService navigationService, IDataService dataService)
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
            List<Event> list = _dataService.GetAllEvents();
            if (list != null)
            {
                DateTime dateNow = DateTime.Now;
                long epocheDate = (dateNow.Ticks - 621355968000000000) / 10000;
                List<Event> SortedList = list.OrderBy(o => o.Date).Where(o => o.Date > epocheDate).ToList();
                Events = SortedList.ToObservableCollection();
            }
            else
            {
                Events = new ObservableCollection<Event>();
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
            EditEventCommand = new CustomCommand(EditEvent, null);
            DeleteEventCommand = new CustomCommand(DeleteEvent, null);
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

        private void EditEvent(object obj)
        {
            if (_selectedEvent != null)
            {
                List<object> objList = new List<object>();
                objList.Add(_selectedEvent);
                objList.Add(_loggedInUser);
                Messenger.Default.Send(objList);
                _navigationService.NavigateTo("EditEvent");
            }
        }

        private void DeleteEvent(object obj)
        {
            if (_selectedEvent != null)
            {

                _dataService.DeleteEvent(_selectedEvent);

                Messenger.Default.Send(_loggedInUser);
                _navigationService.NavigateTo("EventOverview");
            }
        }
    }
}
