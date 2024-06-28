using System.Security;
using backend_guardianiq.API.PersonalSafety.Application.Internal;
using backend_guardianiq.API.PersonalSafety.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend_guardianiq.API.PersonalSafety.Interfaces.REST;

[Route("api/[controller]")]
[ApiController]
public class PersonalSafetyController : ControllerBase
{
    private readonly PersonalSafetyService _personalsafetyService;

    public PersonalSafetyController(PersonalSafetyService personalService)
    {
        _personalsafetyService = personalService;
    }

    [HttpGet]
    public async Task<IEnumerable<Personal>> GetAllAsync()
    {
        var personal = await _personalsafetyService.ListAsync();
        return personal;
    }

    [HttpPost]
    [ActionName(nameof(PostAsync))]
    public async Task<ActionResult<Personal>> PostAsync([FromBody] Personal personal)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var createdPersonal = await _personalsafetyService.SaveAsync(personal);
            return CreatedAtAction(nameof(PostAsync), new { id = createdPersonal.Id }, createdPersonal);
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
            var success = await _personalsafetyService.DeleteAsync(id);

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

    [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var device = await _personalsafetyService.FindByIdAsync(id);

            if (device == null)
                return NotFound();
            return Ok(device);
        }
}