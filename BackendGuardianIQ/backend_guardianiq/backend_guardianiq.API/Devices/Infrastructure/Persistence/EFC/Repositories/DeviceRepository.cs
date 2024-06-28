using backend_guardianiq.API.Devices.Domain.Models;
using backend_guardianiq.API.Devices.Domain.Repositories;
using backend_guardianiq.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend_guardianiq.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend_guardianiq.API.Devices.Infrastructure.Persistence.EFC.Repositories;

public class DeviceRepository : BaseRepository, IDeviceRepository
{
    public DeviceRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Device>> ListAsync()
    {
        return await _context.Device.ToListAsync();
    }

    public async Task AddAsync(Device device)
    {
        await _context.Device.AddAsync(device);
    }

    public async Task<Device?> FindByIdAsync(int id)
    {
        return await _context.Device.FindAsync(id);
    }

    public void Update(Device device)
    {
        _context.Device.Update(device);
    }

    public void Remove(Device device)
    {
        _context.Device.Remove(device);
    }
}