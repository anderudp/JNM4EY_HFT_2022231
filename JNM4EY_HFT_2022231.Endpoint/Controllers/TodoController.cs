using JNM4EY_HFT_2022231.Models;
using Logic.Classes;
using Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : CRUDController<Todo>
    {
        public TodoController(ITodoLogic todoLogic) : base(todoLogic)
        {

        }
    }
}
