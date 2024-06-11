namespace backend_guardianiq.API.PersonalSafety.Domain.Repositories;
using backend_guardianiq.API.PersonalSafety.Domain.Models;

public interface IPersonalSafetyRepository
{
    Task<IEnumerable<Personal>> ListAsync();
    Task AddAsync(Personal personal);
    Task<Personal> FindByIdAsync(int id);
    void Update(Personal service);
    void Remove(Personal service);
}