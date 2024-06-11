using backend_guardianiq.API.ActiveService.Application.Internal;
using backend_guardianiq.API.ActiveService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend_guardianiq.API.ActiveService.Interfaces.REST;

[Route("api/[controller]")]
[ApiController]
public class ServiceController : ControllerBase
{
    private readonly ServiceService _serviceService;

    public ServiceController(ServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    [HttpGet]
    public async Task<IEnumerable<Service>> GetAllAsync()
    {
        var services = await _serviceService.ListAsync();
        return services;
    }

    [HttpPost]
    public async Task<ActionResult<Service>> PostAsync([FromBody] Service service)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var createdService = await _serviceService.SaveAsync(service);
            return CreatedAtAction(nameof(GetAllAsync), createdService);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Service>> PutAsync(int id, [FromBody] Service service)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var updatedService = await _serviceService.UpdateAsync(id, service);

            if (updatedService == null)
            {
                return NotFound();
            }

            return updatedService;
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        try
        {
            var success = await _serviceService.DeleteAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
}