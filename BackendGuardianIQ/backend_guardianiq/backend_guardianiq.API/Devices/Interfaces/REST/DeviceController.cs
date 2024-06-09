using backend_guardianiq.API.Devices.Models;
using Microsoft.AspNetCore.Mvc;
namespace backend_guardianiq.API.Devices.Controllers;

[ApiController]
[Route("[controller]")]
public class DeviceController : ControllerBase
{
    private static List<Device> Devices = new List<Device>();

    [HttpGet]
    public IEnumerable<Device> GetDevices()
    {
        return Devices;
    }

    [HttpGet("{id}")]
    public ActionResult<Device> GetDevice(int id)
    {
        var device = Devices.FirstOrDefault(d => d.Id == id);
        if (device == null)
        {
            return NotFound();
        }
        return device;
    }

    [HttpPost]
    public ActionResult<Device> CreateDevice(Device device)
    {
        Devices.Add(device);
        return CreatedAtAction(nameof(GetDevice), new { id = device.Id }, device);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateDevice(int id, Device device)
    {
        if (id != device.Id)
        {
            return BadRequest();
        }

        var existingDevice = Devices.FirstOrDefault(d => d.Id == id);
        if (existingDevice == null)
        {
            return NotFound();
        }

        existingDevice.Tipo = device.Tipo;
        existingDevice.Marca = device.Marca;
        existingDevice.Modelo = device.Modelo;
        existingDevice.Ubicacion = device.Ubicacion;
        existingDevice.Imagen = device.Imagen;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteDevice(int id)
    {
        var device = Devices.FirstOrDefault(d => d.Id == id);
        if (device == null)
        {
            return NotFound();
        }

        Devices.Remove(device);
        return NoContent();
    }
}