using DePosteleinManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2.Enums;
using DePosteleinManagement.DAL;

namespace DePosteleinManagement.Services
{
    public interface IDataService
    {
        List<Menu> GetAllMenus();
        List<Dish> GetDishesByMenuId(int id);
        List<Customer> GetAllCustomers();
        List<Event> GetAllEvents();
        List<Ingredient> GetIngredientsByDishId(int id);
        List<Ingredient> GetIngredientsByDelivererId(Deliverer deliverer);
        List<User> GetAllUsers();
        List<Deliverer> GetAllDeliverers();
        User CheckCredentials(String username, String password);
        void DeleteUser(User user);
        void DeleteCustomer(Customer customer);
        void DeleteMenu(Menu menu);
        void DeleteEvent(Event _event);
        void DeleteDeliverer(Deliverer deliverer);
        void DeleteIngredient(Ingredient ingredient);
        void CreateNewIngredient(string name, int amount, string unit, int deliverer, int dishId);
        Dish CreateNewDish(string dishName, Menu menu, string function, User loggedInUser);
        Menu CreateNewMenu(string menuName, double price, bool variableAmount);
        Event CreateNewEvent(Menu menuName, int guests, int bread, string customer, string location, long date, User loggedInUser);
        Customer CreateNewCustomer(string name, string surname, string adress, string city, int postcode, User loggedInUser);
        User CreateNewUser(string password, string name, string login, string email, UserRole userRole);
        Deliverer CreateNewDeliverer(string name);
        void EditCustomer(string name, string surname, string adress, string city, int postcode, int id);
        void EditDeliverer(string name, int id);
        void EditEvent(Menu menuName, int guests, int bread, string customer, string location, long epocheDate, int id);
        void EditUser(string password, string name, string login, string email, UserRole userRole, int id);
    }
}
