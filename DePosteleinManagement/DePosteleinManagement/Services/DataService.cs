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

        public DataService(IUserRepository userApiRepository, IMenuRepository menuApiRepository, IDishRepository dishApiRepository)
        {
            _userRepo = userApiRepository;
            _menuRepo = menuApiRepository;
            _dishRepo = dishApiRepository;
        }

        public User CheckCredentials(string username, string password)
        {
            return _userRepo.GetAll().Where(user => user.Name == username).FirstOrDefault();
        }

        public List<Menu> GetAllMenus()
        {
            return _menuRepo.GetAll().ToList();
        }

        public List<Dish> GetDishesByMenuId(int id)
        {
            return _dishRepo.GetDishesByMenuId(id).ToList();
        }
    }
}
