using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface ICRUDLogic <T> where T : class  
    {
        void Create(T entity);
        IEnumerable<T> ReadAll();
        T Read(int id);
        void Update(T entity);
        void Delete(int id);
    }
}
