using backend_guardianiq.API.Profiles.Domain.Model.Aggregates;
using backend_guardianiq.API.Profiles.Domain.Repositories;
using backend_guardianiq.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend_guardianiq.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend_guardianiq.API.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class ProfileRepository: BaseRepository, IProfileRepository
{
    public ProfileRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Profile>> ListAsync()
    {
        return await _context.Profile.ToListAsync();
    }

    public async Task AddAsync(Profile profile)
    {
        await _context.Profile.AddAsync(profile);
    }

    public async Task<Profile?> FindByIdAsync(int id)
    {
        return await _context.Profile.FindAsync(id);
    }

    public void Update(Profile profile)
    {
        _context.Profile.Update(profile);
    }

    public void Remove(Profile profile)
    {
        _context.Profile.Remove(profile);
    }
}