using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DePosteleinManagement.DAL.Repository;
using DePosteleinManagement.Domain;
using ClassLibrary2.Enums;
using DePosteleinManagement.DAL;

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

        public void CreateNewIngredient(string name, int amount, string unit, int deliverer, int dishId)
        {
             _ingredientRepo.Post(new Ingredient { Name = name, Amount = amount, Unit = unit, DelivererId = deliverer, DishId = dishId });
        }

        public Menu CreateNewMenu(string menuName, double price, bool variableAmount)
        {
            return _menuRepo.Post(new Menu { Name = menuName, Price = price, VariableAmount = variableAmount });
        }

        public void DeleteEvent(Event _event)
        {
            _eventRepo.Delete(_event);
        }

        public void DeleteMenu(Menu menu)
        {
           _menuRepo.Delete(menu);
        }

        public void DeleteUser(User user)
        {
            _userRepo.Delete(user);
        }

        public void DeleteCustomer (Customer customer)
        {
            _customerRepo.Delete(customer);
        }

        public void DeleteDeliverer(Deliverer deliverer)
        {
            _delivererRepo.Delete(deliverer);
        }

        public void DeleteIngredient(Ingredient ingredient)
        {
            _ingredientRepo.Delete(ingredient);
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

        public List<Ingredient> GetIngredientsByDelivererId(Deliverer deliverer)
        {
            return _ingredientRepo.GetIngredientsByDelivererId(deliverer.Id).ToList();
        }

        public List<Menu> GetAllMenus()
        {
            return _menuRepo.GetAll().ToList();
        }

        public List<User> GetAllUsers()
        {
            return _userRepo.GetAll().ToList();
        }

        public List<Deliverer> GetAllDeliverers()
        {
            return _delivererRepo.GetAll().ToList();
        }

        public List<Dish> GetDishesByMenuId(int id)
        {
            return _dishRepo.GetDishesByMenuId(id).ToList();
        }

        public Customer CreateNewCustomer(string name, string surname, string adress, string city, int postcode, User loggedInUser)
        {
            return _customerRepo.Post(new Customer { Name = name, Surname = surname, Adress = adress, City = city, Postcode = postcode });
        }

        public User CreateNewUser(string password, string name, string login, string email, UserRole userRole)
        {
            if (userRole.ToString().Equals("ADMIN"))
            {
                return _userRepo.Post(new User { Password = password, Name = name, Login = login, UserRoleHelp = userRole.ToString(), EMail = email, Function = "ADMIN" });
            }
            return _userRepo.Post(new User { Password = password, Name = name, Login = login, UserRoleHelp = userRole.ToString(), EMail = email, Function = "USER"});
        }

        public Deliverer CreateNewDeliverer(string name)
        {
            return _delivererRepo.Post(new Deliverer { Name = name });
        }

        public void EditCustomer(string name, string surname, string adress, string city, int postcode, int id)
        {
             _customerRepo.Update(new Customer { Name = name, Surname = surname, Adress = adress, City = city, Postcode = postcode, Id = id });
        }

        public void EditDeliverer(string name, int id)
        {
            _delivererRepo.Update(new Deliverer { Name = name, Id = id });
        }

        public void EditEvent(Menu menuName, int guests, int bread, string customer, string location, long epocheDate, int id)
        {
            _eventRepo.Update(new Event { Guests = guests, Bread = bread, Customer = customer, Location = location, Date = epocheDate, Menu = menuName.Name, Id = id });
        }

        public void EditUser(string password, string name, string login, string email, UserRole userRole, int id)
        {
            if (userRole.ToString().Equals("ADMIN"))
            {
                _userRepo.Update(new User { Password = password, Name = name, Login = login, UserRoleHelp = userRole.ToString(), EMail = email, Function = "ADMIN", Id = id });
            }
            else
            {
                _userRepo.Update(new User { Password = password, Name = name, Login = login, UserRoleHelp = userRole.ToString(), EMail = email, Function = "USER", Id = id });
            }
        }
    }
}
