using JNM4EY_HFT_2022231.Models;
using JNM4EY_HFT_2022231.Repository;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Classes
{
    public class AgendaLogic : CRUDLogic<Agenda>, IAgendaLogic
    {
        private IRepository<Agenda> _agendaRepo;
        public AgendaLogic(IRepository<Agenda> agendaRepo) : base(agendaRepo)
        {
            _agendaRepo = agendaRepo;
        }
    }
}
