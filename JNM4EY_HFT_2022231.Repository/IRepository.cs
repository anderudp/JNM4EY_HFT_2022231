using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNM4EY_HFT_2022231.Repository
{
    public interface IRepository<T> where T : class
    {
        int Create(T entity);
        IEnumerable<T> ReadAll();
        T Read(int id);
        void Update(T entity);
        void Delete(int id);
    }
}
