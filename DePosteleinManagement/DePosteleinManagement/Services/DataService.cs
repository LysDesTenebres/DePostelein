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
            return _userRepo.GetAll().Where(user => user.Name == username).FirstOrDefault();
        }

        public bool CreateNewDish(string dishName, Menu menu, string function, User loggedInUser)
        {
            throw new NotImplementedException();
        }

        public bool CreateNewEvent(string menuName, int guests, int bread, string customer, string location, DateTime date, User loggedInUser)
        {
            throw new NotImplementedException();
        }

        public void CreateNewIngredient(string name, int amount, string unit, string deliverer, object dishId)
        {
            throw new NotImplementedException();
        }

        public bool CreateNewMenu(string menuName, double price, bool variableAmount)
        {
            throw new NotImplementedException();
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

        public List<Ingredient> GetAllIngredientsByDishId(int id)
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
    }
}
