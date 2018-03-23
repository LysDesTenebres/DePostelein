using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DePosteleinManagement.Domain;

namespace DePosteleinManagement.DAL.Repository {

    public interface IIngredientRepository : IRepository<Ingredient>
    {
        List<Ingredient> GetIngredientsByDishId(int id);
        List<Ingredient> GetIngredientsByDelivererId(int id);
    }
}
