using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace YourProjectNamespace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActiveServicesController : ControllerBase
    {
        private readonly List<ActiveService> _services = new List<ActiveService>
        {
            new ActiveService { Id = 1, Name = "Service1", IsActive = true },
            new ActiveService { Id = 2, Name = "Service2", IsActive = false }
        };

        [HttpGet]
        public IEnumerable<ActiveService> GetAllServices()
        {
            return _services;
        }

        [HttpGet("{id}")]
        public ActionResult<ActiveService> GetServiceById(int id)
        {
            var service = _services.FirstOrDefault(s => s.Id == id);
            if (service == null)
            {
                return NotFound();
            }
            return service;
        }

        [HttpPost]
        public ActionResult<ActiveService> CreateService(ActiveService service)
        {
            service.Id = _services.Count + 1;
            _services.Add(service);
            return CreatedAtAction(nameof(GetServiceById), new { id = service.Id }, service);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateService(int id, ActiveService updatedService)
        {
            var service = _services.FirstOrDefault(s => s.Id == id);
            if (service == null)
            {
                return NotFound();
            }

            service.Name = updatedService.Name;
            service.IsActive = updatedService.IsActive;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            var service = _services.FirstOrDefault(s => s.Id == id);
            if (service == null)
            {
                return NotFound();
            }

            _services.Remove(service);
            return NoContent();
        }
    }

    public class ActiveService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
