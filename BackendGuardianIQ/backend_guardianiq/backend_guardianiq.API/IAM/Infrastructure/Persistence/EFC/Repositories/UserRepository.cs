using backend_guardianiq.API.IAM.Domain.Model.Aggregates;
using backend_guardianiq.API.IAM.Domain.Repositories;
using backend_guardianiq.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend_guardianiq.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace backend_guardianiq.API.IAM.Infrastructure.Persistence.EFC.Repositories;

public class UserRepository: BaseRepository, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _context.User.ToListAsync();
    }

    public async Task AddAsync(User user)
    {
        await _context.User.AddAsync(user);
    }

    public async Task<User?> FindByIdAsync(int id)
    {
        return await _context.User.FindAsync(id);
    }

    public void Update(User user)
    {
        _context.User.Update(user);
    }

    public void Remove(User user)
    {
        _context.User.Remove(user);
    }
}