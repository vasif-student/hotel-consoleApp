using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    interface IService<T>
    {
        List<T> GetAll();
        T Get(int id);
        T Create(T model);
        T Update(int id, T model);
        bool Delete(int id);
    }
}
