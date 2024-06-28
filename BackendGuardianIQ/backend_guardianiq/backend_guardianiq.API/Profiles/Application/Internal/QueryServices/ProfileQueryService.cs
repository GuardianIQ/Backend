using backend_guardianiq.API.Profiles.Domain.Model.Aggregates;
using backend_guardianiq.API.Profiles.Domain.Model.Queries;
using backend_guardianiq.API.Profiles.Domain.Repositories;
using backend_guardianiq.API.Profiles.Domain.Services;

namespace backend_guardianiq.API.Profiles.Application.Internal.QueryServices;

public class ProfileQueryService(IProfileRepository profileRepository) : IProfileQueryService
{
    public async Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query)
    {
        return await profileRepository.ListAsync();
    }
    
    public async Task<Profile?> Handle(GetProfileByIdQuery query)
    {
        return await profileRepository.FindByIdAsync(query.ProfileId);
    }
}