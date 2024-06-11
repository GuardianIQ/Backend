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
    public async Task<ActionResult<Personal>> PostAsync([FromBody] Personal personal)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var createdPersonal = await _personalsafetyService.SaveAsync(personal);
            return CreatedAtAction(nameof(GetAllAsync), createdPersonal);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Personal>> PutAsync(int id, [FromBody] Personal personal)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var updatedPersonal = await _personalsafetyService.UpdateAsync(id, personal);

            if (updatedPersonal == null)
            {
                return NotFound();
            }

            return updatedPersonal;
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
}