using backend_guardianiq.API.PersonalSafety.Domain.Models;

namespace backend_guardianiq.API.PersonalSafety.Domain.Services;

public interface IPersonalSafetyService
{
    Task<IEnumerable<Personal>> ListAsync();
    Task<Personal> SaveAsync(Personal personal);
    Task<Personal> UpdateAsync(int id, Personal device);
    Task<bool> DeleteAsync(int id);
}