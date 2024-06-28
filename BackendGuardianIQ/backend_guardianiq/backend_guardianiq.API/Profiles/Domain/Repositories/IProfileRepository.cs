using backend_guardianiq.API.Profiles.Domain.Model.Aggregates;

namespace backend_guardianiq.API.Profiles.Domain.Repositories;

public interface IProfileRepository
{
    Task<IEnumerable<Profile>> ListAsync();
    Task AddAsync(Profile profile);
    Task<Profile?> FindByIdAsync(int id);
    void Update(Profile profile);
    void Remove(Profile profile);
}