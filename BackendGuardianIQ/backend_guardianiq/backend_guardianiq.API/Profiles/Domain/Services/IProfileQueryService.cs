using backend_guardianiq.API.Profiles.Domain.Model.Aggregates;
using backend_guardianiq.API.Profiles.Domain.Model.Queries;

namespace backend_guardianiq.API.Profiles.Domain.Services;

public interface IProfileQueryService
{
    Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query);
    Task<Profile?> Handle(GetProfileByIdQuery query);
}