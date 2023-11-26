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

        public CRUDController(ICRUDLogic<T> logic)
        {
            _logic = logic;
        }

        [HttpPost]
        public void Create([FromBody] T value)
        {
            _logic.Create(value);
            //_hub.Clients.All.SendAsync($"{typeof(T).FullName}Created", value);
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
            //_hub.Clients.All.SendAsync($"{typeof(T).FullName}Updated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var toDelete = _logic.Read(id);
            _logic.Delete(id);
            //_hub.Clients.All.SendAsync($"{typeof(T).FullName}Deleted", toDelete);
        }
    }
}
