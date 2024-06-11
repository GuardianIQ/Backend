using backend_guardianiq.API.Devices.Application.Internal;
using backend_guardianiq.API.Devices.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend_guardianiq.API.Devices.Interfaces.REST.Repositories;

[Route("api/[controller]")]
[ApiController]
public class DeviceController : ControllerBase
{
    private readonly DeviceService _deviceService;

    public DeviceController(DeviceService deviceService)
    {
        _deviceService = deviceService;
    }

    [HttpGet]
    public async Task<IEnumerable<Device>> GetAllAsync()
    {
        var device = await _deviceService.ListAsync();
        return device;
    }

    [HttpPost]
    public async Task<ActionResult<Device>> PostAsync([FromBody] Device device)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var createdDevice = await _deviceService.SaveAsync(device);
            return CreatedAtAction(nameof(GetAllAsync), createdDevice);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Device>> PutAsync(int id, [FromBody] Device device)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var updatedDevice = await _deviceService.UpdateAsync(id, device);

            if (updatedDevice == null)
            {
                return NotFound();
            }

            return updatedDevice;
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
            var success = await _deviceService.DeleteAsync(id);

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