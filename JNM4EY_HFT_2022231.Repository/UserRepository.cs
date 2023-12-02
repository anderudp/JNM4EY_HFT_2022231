using Data;
using JNM4EY_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNM4EY_HFT_2022231.Repository
{
    public class UserRepository : IRepository<User>
    {
        private DataContext _db;
        public UserRepository(DataContext db)
        {
            _db = db;
        }

        public int Create(User entity)
        {
            _db.Users.Add(entity);
            _db.SaveChanges();
            return entity.UserId;
        }

        public User Read(int id)
        {
            return _db.Users.FirstOrDefault(u => u.UserId == id);
        }

        public IEnumerable<User> ReadAll()
        {
            return _db.Users;
        }

        public void Update(User entity)
        {
            User toUpdate = Read(entity.UserId);
            toUpdate.AgendaUsers = entity.AgendaUsers;
            toUpdate.Email = entity.Email;
            toUpdate.Name = entity.Name;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Users.Remove(Read(id));
            _db.SaveChanges();
        }
    }
}
