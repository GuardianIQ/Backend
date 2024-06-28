using backend_guardianiq.API.IAM.Domain.Model.Aggregates;

namespace backend_guardianiq.API.IAM.Domain.Repositories;

public interface IUserRepository
{ 
    Task<IEnumerable<User>> ListAsync();
    Task AddAsync(User user);
    Task<User?> FindByIdAsync(int id); 
    void Update(User user); 
    void Remove(User user);
}