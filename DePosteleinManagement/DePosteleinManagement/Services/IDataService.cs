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
        List<Ingredient> GetAllIngredientsByDishId(int id);
        List<User> GetAllUsers();
        User CheckCredentials(String username, String password);
        void DeleteUser(int id);
        void DeleteMenu(int id);
        void DeleteEvent(int id);
    }
}
