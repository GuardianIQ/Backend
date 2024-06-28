using System.Net.Mime;
using backend_guardianiq.API.Profiles.Domain.Model.Queries;
using backend_guardianiq.API.Profiles.Domain.Services;
using backend_guardianiq.API.Profiles.Interfaces.REST.Resources;
using backend_guardianiq.API.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace backend_guardianiq.API.Profiles.Interfaces.REST;

[Route("api/v1/[controller]")]
[ApiController]

public class ProfileController(IProfileCommandService profileCommandService, IProfileQueryService profileQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProfile(CreateProfileResource resource)
    {
        var createProfileCommand = CreateProfileCommandFromResourceAssembler.ToCommandFromResource(resource);
        var profile = await profileCommandService.Handle(createProfileCommand);
        if (profile is null) return BadRequest();
        var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return CreatedAtAction(nameof(GetProfileById), new {profileId = profileResource.Id}, profileResource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllProfiles()
    {
        var getAllProfilesQuery = new GetAllProfilesQuery();
        var profiles = await profileQueryService.Handle(getAllProfilesQuery);
        var profileResources = profiles.Select(ProfileResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(profileResources);
    }
    
    [HttpGet("{profileId:int}")]
    public async Task<IActionResult> GetProfileById(int profileId)
    {
        var getProfileByIdQuery = new GetProfileByIdQuery(profileId);
        var profile = await profileQueryService.Handle(getProfileByIdQuery);
        if (profile == null) return NotFound();
        var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return Ok(profileResource);
    }
}