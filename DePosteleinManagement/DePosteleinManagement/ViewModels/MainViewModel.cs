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

namespace DePosteleinManagement.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
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
        public CustomCommand LogOutCommand { get; set; }

        public CustomCommand DeleteMenuCommand { get; set; }
        public CustomCommand DeleteDishCommand { get; set; }
        public CustomCommand DeleteIngredientCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



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

        private Menu _selectedMenu;
        public Menu SelectedMenu
        {
            get
            {
                return _selectedMenu;
            }
            set
            {
                _selectedMenu = value;
                RaisePropertyChanged(nameof(SelectedMenu));
                if (_selectedMenu != null)
                {
                    List<Dish> list = _dataService.GetDishesByMenuId(value.Id);
                    if (list != null)
                    {
                        Dishes = list.ToObservableCollection<Dish>();
                    }
                    else
                    {
                        Dishes = new ObservableCollection<Dish>();
                    }

                    if (Dishes != null)
                    {
                        List<Ingredient> iList = _dataService.GetIngredientsByDishId(Dishes.FirstOrDefault().Id);
                        if (list != null)
                        {
                            Ingredients = iList.ToObservableCollection<Ingredient>();
                        }
                        else
                        {
                            Ingredients = new ObservableCollection<Ingredient>();
                        }
                    }
                }
            }
        }

        ObservableCollection<Dish> _dishes;
        public ObservableCollection<Dish> Dishes
        {
            get
            {
                return _dishes;
            }
            set
            {
                _dishes = value;
                RaisePropertyChanged(nameof(Dishes));
            }
        }

        private Dish _selectedDish;
        public Dish SelectedDish
        {
            get
            {
                return _selectedDish;
            }
            set
            {
                _selectedDish = value;
                RaisePropertyChanged(nameof(SelectedDish));
                if (_selectedDish != null)
                {
                    List<Ingredient> list = _dataService.GetIngredientsByDishId(value.Id);
                    if (list != null)
                    {
                        Ingredients = list.ToObservableCollection<Ingredient>();
                    }
                    else
                    {
                        Ingredients = new ObservableCollection<Ingredient>();
                    }
                }
               
            }
        }

        ObservableCollection<Ingredient> _ingredients;
        public ObservableCollection<Ingredient> Ingredients
        {
            get
            {
                return _ingredients;
            }
            set
            {
                _ingredients = value;
                RaisePropertyChanged(nameof(Ingredients));
            }
        }

        private Ingredient _selectedIngredient;
        public Ingredient SelectedIngredient
        {
            get
            {
                return _selectedIngredient;
            }
            set
            {
                _selectedIngredient = value;
                RaisePropertyChanged(nameof(SelectedIngredient));
            }
        }


        public MainViewModel(INavigationService navigationService, IDataService dataService)
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
                List<Menu> list = _dataService.GetAllMenus();
                if (list != null)
                {
                    Menus = list.ToObservableCollection();
                }
                else
                {
                    Menus = new ObservableCollection<Menu>();
                }
            if (Menus.Count > 0)
                SelectedMenu = Menus.First();
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
            LogOutCommand = new CustomCommand(LogOut, null);
            DeleteMenuCommand = new CustomCommand(DeleteMenu, null);
            DeleteDishCommand = new CustomCommand(DeleteDish, null);
            DeleteIngredientCommand = new CustomCommand(DeleteIngredient, null);
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

        private void DeleteMenu(object obj)
        {
            if (_selectedMenu != null)
            {

                _dataService.DeleteMenu(_selectedMenu);

                Dishes = null;
                SelectedDish = null;
                Ingredients = null;
                SelectedIngredient = null;

                Messenger.Default.Send(_loggedInUser);
                _navigationService.NavigateTo("MainView");
            }
        }

        private void DeleteDish(object obj)
        {
            if (_selectedDish != null)
            {

                _dataService.DeleteDish(_selectedDish);
                Ingredients = null;
                SelectedIngredient = null;

                Messenger.Default.Send(_loggedInUser);
                _navigationService.NavigateTo("MainView");
            }
        }

        private void DeleteIngredient(object obj)
        {
            if (_selectedIngredient != null)
            {

                _dataService.DeleteIngredient(_selectedIngredient);

                Messenger.Default.Send(_loggedInUser);
                _navigationService.NavigateTo("MainView");
            }
        }
    }
}
