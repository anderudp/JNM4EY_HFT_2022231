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
    public class UserLogic : CRUDLogic<User>, IUserLogic
    {
        private IRepository<User> _userRepo;
        public UserLogic(IRepository<User> userRepo) : base(userRepo)
        {
            _userRepo = userRepo;
        }
    }
}
