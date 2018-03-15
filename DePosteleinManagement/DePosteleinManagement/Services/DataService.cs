using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DePosteleinManagement.DAL.Repository;
using DePosteleinManagement.Domain;

namespace DePosteleinManagement.Services
{
    class DataService:IDataService
    {
        IUserRepository _userRepo;
        IMenuRepository _menuRepo;
        IDishRepository _dishRepo;
        ICustomerRepository _customerRepo;
        IDelivererRepository _delivererRepo;
        IEventRepository _eventRepo;
        IIngredientRepository _ingredientRepo;

        public DataService(IUserRepository userApiRepository, IMenuRepository menuApiRepository, IDishRepository dishApiRepository,
            ICustomerRepository customerApiRepository, IDelivererRepository delivererApiRepository, IEventRepository eventApiRepository,
            IIngredientRepository ingredientApiRepository)
        {
            _userRepo = userApiRepository;
            _menuRepo = menuApiRepository;
            _dishRepo = dishApiRepository;
            _customerRepo = customerApiRepository;
            _delivererRepo = delivererApiRepository;
            _eventRepo = eventApiRepository;
            _ingredientRepo = ingredientApiRepository;
        }

        public User CheckCredentials(string username, string password)
        {
            _userRepo.SetCredentials(username, password);
            _menuRepo.SetCredentials(username, password);
            _dishRepo.SetCredentials(username, password);
            _customerRepo.SetCredentials(username, password);
            _delivererRepo.SetCredentials(username, password);
            _eventRepo.SetCredentials(username, password);
            _ingredientRepo.SetCredentials(username, password);
            return _userRepo.GetAll().Where(user => user.Name == username).FirstOrDefault();
        }

        public Dish CreateNewDish(string dishName, Menu menu, string function, User loggedInUser)
        {
            return _dishRepo.Post(new Dish { Name = dishName, role = function, MenuId = menu.Id });
        }

        public Event CreateNewEvent(Menu menuName, int guests, int bread, string customer, string location, long date, User loggedInUser)
        {
            return _eventRepo.Post(new Event { Guests = guests, Bread = bread, Customer = customer, Location = location, Date = date, Menu = menuName.Name});
        }

        public void CreateNewIngredient(string name, int amount, string unit, string deliverer, int dishId)
        {
             _ingredientRepo.Post(new Ingredient { Name = name, Amount = amount, Unit = unit, Deliverer = deliverer, DishId = dishId });
        }

        public Menu CreateNewMenu(string menuName, double price, bool variableAmount)
        {
            return _menuRepo.Post(new Menu { Name = menuName, Price = price, VariableAmount = variableAmount });
        }

        public void DeleteEvent(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteMenu(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepo.GetAll().ToList();
        }

        public List<Event> GetAllEvents()
        {
            return _eventRepo.GetAll().ToList();
        }

        public List<Ingredient> GetIngredientsByDishId(int id)
        {
            return _ingredientRepo.GetIngredientsByDishId(id).ToList();
        }

        public List<Menu> GetAllMenus()
        {
            return _menuRepo.GetAll().ToList();
        }

        public List<User> GetAllUsers()
        {
            return _userRepo.GetAll().ToList();
        }

        public List<Dish> GetDishesByMenuId(int id)
        {
            return _dishRepo.GetDishesByMenuId(id).ToList();
        }

        public Customer CreateNewCustomer(string name, string surname, string adress, string city, int postcode, User loggedInUser)
        {
            return _customerRepo.Post(new Customer { Name = name, Surname = surname, Adress = adress, City = city, Postcode = postcode });
        }
    }
}
