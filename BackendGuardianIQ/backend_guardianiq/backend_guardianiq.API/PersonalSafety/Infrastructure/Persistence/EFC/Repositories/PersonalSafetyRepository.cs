using backend_guardianiq.API.PersonalSafety.Domain.Repositories;
using backend_guardianiq.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend_guardianiq.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using backend_guardianiq.API.PersonalSafety.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_guardianiq.API.PersonalSafety.Infrastructure.Persistence.EFC.Repositories;

public class PersonalSafetyRepository : BaseRepository, IPersonalSafetyRepository
{
    public PersonalSafetyRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Personal>> ListAsync()
    {
        return await _context.Personal.ToListAsync();
    }

    public async Task AddAsync(Personal personal)
    {
        await _context.Personal.AddAsync(personal);
    }

    public async Task<Personal> FindByIdAsync(int id)
    {
        return await _context.Personal.FindAsync(id);
    }

    public void Update(Personal personal)
    {
        _context.Personal.Update(personal);
    }

    public void Remove(Personal personal)
    {
        _context.Personal.Remove(personal);
    }
}