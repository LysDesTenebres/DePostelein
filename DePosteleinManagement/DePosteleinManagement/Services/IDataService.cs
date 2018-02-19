using DePosteleinManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DePosteleinManagement.Services
{
    public interface IDataService
    {
        List<Menu> GetAllMenus();
        List<Dish> GetDishesByMenuId(int id);
        List<Customer> GetAllCustomers();
        List<Event> GetAllEvents();
        List<Ingredient> GetIngredientsByDishId(int id);
        List<User> GetAllUsers();
        User CheckCredentials(String username, String password);
        void DeleteUser(int id);
        void DeleteMenu(int id);
        void DeleteEvent(int id);
        void CreateNewIngredient(string name, int amount, string unit, string deliverer, int dishId);
        Dish CreateNewDish(string dishName, Menu menu, string function, User loggedInUser);
        Menu CreateNewMenu(string menuName, double price, bool variableAmount);
        bool CreateNewEvent(string menuName, int guests, int bread, string customer, string location, DateTime date, User loggedInUser);
    }
}
