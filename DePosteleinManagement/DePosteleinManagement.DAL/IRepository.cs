using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DePosteleinManagement.DAL
{
        public interface IRepository<T>
        {
            void SetCredentials(String username, String password);

            IList<T> GetAll();
            T GetById(int id);

            T Post(T t);
            bool Delete(T t);
            void Update(T t);
         }
}