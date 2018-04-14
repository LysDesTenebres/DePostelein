using ClassLibrary2.Enums;
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
    public class NewDishViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private INavigationService _navigationService;
        private IDataService _dataService;
        private User _loggedInUser;
        private Menu _menu;
        private List<Ingredient> _ingredients = new List<Ingredient>();

        public CustomCommand CreateNewIngredientCommand { get; set; }
        public CustomCommand CreateNewDishCommand { get; set; }
        public CustomCommand FinishMenuCommand { get; set; }
        public CustomCommand BackCommand { get; set; }
        public CustomCommand LoadCommand { get; set; }

        private ObservableCollection<Deliverer> _deliverers;
        public ObservableCollection<Deliverer> Deliverers
        {
            get
            {
                return _deliverers;
            }
            set
            {
                _deliverers = value;
                RaisePropertyChanged(nameof(Deliverers));
            }
        }

        private Deliverer _selectedDeliverer;
        public Deliverer SelectedDeliverer
        {
            get
            {
                return _selectedDeliverer;
            }
            set
            {
                _selectedDeliverer = value;
                RaisePropertyChanged(nameof(SelectedDeliverer));
            }
        }

        private String _dishName;
        public String DishName
        {
            get
            {
                return _dishName;
            }
            set
            {
                _dishName = value;
                RaisePropertyChanged(nameof(DishName));
            }
        }

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

        private String _ingredientName;
        public String IngredientName
        {
            get
            {
                return _ingredientName;
            }
            set
            {
                _ingredientName = value;
                RaisePropertyChanged(nameof(IngredientName));
            }
        }


        private int _amount;
        public int Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
                RaisePropertyChanged(nameof(Amount));
            }
        }

        private String _unit;
        public String Unit
        {
            get
            {
                return _unit;
            }
            set
            {
                _unit = value;
                RaisePropertyChanged(nameof(Unit));
            }
        }

        private String _ingredientText;
        public String IngredientText
        {
            get
            {
                return _ingredientText;
            }
            set
            {
                _ingredientText = value;
                RaisePropertyChanged(nameof(IngredientText));
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public NewDishViewModel(INavigationService navigationService, IDataService dataService)
        {
            Messenger.Default.Register<List<object>>(this, OnObjectReceived);
            _dataService = dataService;
            _navigationService = navigationService;
            LoadCommands();

            BackCommand = new CustomCommand(GoBack, null);
        }

        private void OnObjectReceived(List<object> obj)
        {
            if (obj.ElementAt(0) is Menu)
            {
                _menu = (Menu)obj.ElementAt(0);
            }
            
            _loggedInUser = (User)obj.ElementAt(1);
        }

        private void LoadCommands()
        {
            LoadCommand = new CustomCommand((obj) => {
                LoadData();
            }, null);
            CreateNewIngredientCommand = new CustomCommand(CreateNewIngredient, null);
            CreateNewDishCommand = new CustomCommand(CreateNewDish, null);
            FinishMenuCommand = new CustomCommand(FinishMenu, null);
        }

        private void LoadData()
        {
            List<Deliverer> list = _dataService.GetAllDeliverers().ToList();
            if (list != null)
            {
                Deliverers = list.ToObservableCollection();
            }
            else
            {
                Deliverers = new ObservableCollection<Deliverer>();
            }

            List<UserRole> uList = Enum.GetValues(typeof(UserRole)).Cast<UserRole>().ToList();
            if (list != null)
            {
                UserRoles = uList.ToObservableCollection();
            }
            else
            {
                UserRoles = new ObservableCollection<UserRole>();
            }
        }

        private void CreateNewIngredient(object obj)
        {
            if (_ingredientName != null && _amount != 0 && _unit != null && _selectedDeliverer != null)
            {

                _ingredients.Add(new Ingredient { Name = _ingredientName, Amount = _amount, Unit = _unit, DelivererId = _selectedDeliverer.Id, DishId = 0 });

               IngredientText = _ingredientText + _ingredientName + "\r\n";
                RaisePropertyChanged(nameof(IngredientText));

                IngredientName = null;
                Amount = 0;
                Unit = null;
            

            }
        }

        private void CreateNewDish(object obj)
        {
            Dish _dish = null;
            if (_ingredients != null && _dishName != null)
            {
                _dish = _dataService.CreateNewDish(_dishName, _menu, _userRole, _loggedInUser);
            }

            if (_ingredientName != null && _amount != 0 && _unit != null && _selectedDeliverer != null)
            {
                _ingredients.Add(new Ingredient { Name = _ingredientName, Amount = _amount, Unit = _unit, DelivererId = _selectedDeliverer.Id, DishId = 0 });
            }

            if (_dish != null)
            {
                foreach (Ingredient ingredient in _ingredients)
                {
                    _dataService.CreateNewIngredient(ingredient.Name, ingredient.Amount, ingredient.Unit, ingredient.DelivererId, _dish.Id);
                }

                IngredientName = null;
                Amount = 0;
                Unit = null;
                DishName = null;
                IngredientText = null;
                _ingredients.Clear();

                List<object> objList = new List<object>();
                objList.Add(_menu);
                objList.Add(_loggedInUser);
                Messenger.Default.Send(objList);
                _navigationService.NavigateTo("NewDish");
            }
        }

        private void FinishMenu(object obj)
        {
            Dish _dish = null;
            if (_dishName != null)
            {
                _dish = _dataService.CreateNewDish(_dishName, _menu, _userRole, _loggedInUser);
            }

            if (_dish != null)
            {
                if (_ingredients != null)
                {
                    foreach (Ingredient ingredient in _ingredients)
                    {
                        _dataService.CreateNewIngredient(ingredient.Name, ingredient.Amount, ingredient.Unit, ingredient.DelivererId, _dish.Id);
                    }
                }

                if (_ingredientName != null && _amount != 0 && _unit != null && _selectedDeliverer != null)
                {
                    _dataService.CreateNewIngredient(_ingredientName, _amount, _unit, _selectedDeliverer.Id, _dish.Id);
                }

                Messenger.Default.Send<User>(_loggedInUser);
                _navigationService.NavigateTo("MainView");
            }
        }

        private void GoBack(object obj)
        {
            Messenger.Default.Send<User>(_loggedInUser);
            _navigationService.NavigateTo("MainView");
        }

    }
}
