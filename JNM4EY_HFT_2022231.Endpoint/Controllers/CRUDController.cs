using JNM4EY_HFT_2022231.Endpoint.Services;
using Logic.Classes;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Endpoint.Controllers
{
    [Controller]
    public class CRUDController<T> : ControllerBase where T : class
    {
        private ICRUDLogic<T> _logic;
        IHubContext<SignalRHub> hub;

        public CRUDController(ICRUDLogic<T> logic, IHubContext<SignalRHub> hub)
        {
            _logic = logic;
            this.hub = hub;
        }

        [HttpPost]
        public int Create([FromBody] T value)
        {
            hub.Clients.All.SendAsync($"{typeof(T).FullName}Created", value);
            return _logic.Create(value);
        }

        [HttpGet]
        public IEnumerable<T> ReadAll()
        {
            return _logic.ReadAll();
        }

        [HttpGet("{id}")]
        public T Read(int id)
        { 
            return _logic.Read(id);
        }

        [HttpPut]
        public void Update([FromBody] T value)
        {
            _logic.Update(value);
            hub.Clients.All.SendAsync($"{typeof(T).FullName}Updated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var toDelete = _logic.Read(id);
            _logic.Delete(id);
            hub.Clients.All.SendAsync($"{typeof(T).FullName}Deleted", toDelete);
        }
    }
}
