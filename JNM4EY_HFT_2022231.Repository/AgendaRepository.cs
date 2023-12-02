using Data;
using JNM4EY_HFT_2022231.Models;
using JNM4EY_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AgendaRepository : IRepository<Agenda>
    {
        private DataContext _db;
        public AgendaRepository(DataContext db)
        {
            _db = db;
        }

        public int Create(Agenda entity)
        {
            _db.Agendas.Add(entity);
            _db.SaveChanges();
            return entity.AgendaId;
        }

        public Agenda Read(int id)
        {
            return _db.Agendas.FirstOrDefault(a => a.AgendaId == id);
        }

        public IEnumerable<Agenda> ReadAll()
        {
            return _db.Agendas;
        }

        public void Update(Agenda entity)
        {
            Agenda toUpdate = Read(entity.AgendaId);
            toUpdate.AgendaUsers = entity.AgendaUsers;
            toUpdate.Description = entity.Description;
            toUpdate.Title = entity.Title;
            toUpdate.Todos = entity.Todos;
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            _db.Agendas.Remove(Read(id));
            _db.SaveChanges();
        }
    }
}
