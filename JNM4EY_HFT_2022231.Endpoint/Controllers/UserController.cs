using Endpoint.Controllers;
using JNM4EY_HFT_2022231.Models;
using Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JNM4EY_HFT_2022231.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CRUDController<User>
    {
        public UserController(IUserLogic userLogic) : base(userLogic)
        {

        }
    }
}
