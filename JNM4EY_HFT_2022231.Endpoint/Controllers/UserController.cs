using Endpoint.Controllers;
using JNM4EY_HFT_2022231.Endpoint.Services;
using JNM4EY_HFT_2022231.Models;
using Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace JNM4EY_HFT_2022231.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CRUDController<User>
    {
        public UserController(IUserLogic userLogic, IHubContext<SignalRHub> hub) : base(userLogic, hub)
        {

        }
    }
}
