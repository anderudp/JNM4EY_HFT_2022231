using JNM4EY_HFT_2022231.Repository;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Classes
{
    public class CRUDLogic<T> where T : class
    {
        private IRepository<T> _repo;
        public CRUDLogic(IRepository<T> repo)
        {
            _repo = repo;   
        }

        public int Create(T entity)
        {
            return _repo.Create(entity);
        }

        public T Read(int id)
        {
            return _repo.Read(id);
        }

        public IEnumerable<T> ReadAll()
        {
            return _repo.ReadAll();
        }

        public void Update(T entity)
        {
            _repo.Update(entity);
        }
        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
