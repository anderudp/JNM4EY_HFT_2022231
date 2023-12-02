using Data;
using JNM4EY_HFT_2022231.Models;
using JNM4EY_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TodoRepository : IRepository<Todo>
    {
        private DataContext _db;
        public TodoRepository(DataContext db)
        {
            _db = db;
        }

        public int Create(Todo entity)
        {
            _db.Todos.Add(entity);
            _db.SaveChanges();
            return entity.TodoId;
        }
        public Todo Read(int id)
        {
            return _db.Todos.FirstOrDefault(t => t.TodoId == id);
        }

        public IEnumerable<Todo> ReadAll()
        {
            return _db.Todos;
        }

        public void Update(Todo entity)
        {
            Todo toUpdate = Read(entity.TodoId);
            toUpdate.Agenda = entity.Agenda;
            toUpdate.AgendaId = entity.AgendaId;
            toUpdate.IsImportant = entity.IsImportant;
            toUpdate.IsComplete = entity.IsComplete;
            toUpdate.IsUrgent = entity.IsUrgent;
            toUpdate.Description = entity.Description;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Todos.Remove(Read(id));
            _db.SaveChanges();
        }

    }
}
