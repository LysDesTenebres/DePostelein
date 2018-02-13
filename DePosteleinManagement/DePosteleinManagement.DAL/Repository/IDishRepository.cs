using DePosteleinManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DePosteleinManagement.DAL.Repository
{
    public interface IDishRepository : IRepository<Dish>
    {
        IList<Dish> GetDishesByMenuId(int id);
    }
}
