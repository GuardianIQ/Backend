using backend_guardianiq.API.Profiles.Domain.Model.Aggregates;
using backend_guardianiq.API.Profiles.Domain.Model.Commands;

namespace backend_guardianiq.API.Profiles.Domain.Services;

public interface IProfileCommandService
{
    Task<Profile?> Handle(CreateProfileCommand command);
}