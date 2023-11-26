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
    public class TodoLogic : CRUDLogic<Todo>, ITodoLogic
    {
        private IRepository<Todo> _todoRepo;
        public TodoLogic(IRepository<Todo> todoRepo) : base(todoRepo)
        {
            _todoRepo = todoRepo;
        }
    }
}
