using backend_guardianiq.API.Devices.Domain.Models;

namespace backend_guardianiq.API.Devices.Domain.Repositories;

public interface IDeviceRepository
{
    Task<IEnumerable<Device>> ListAsync();
    Task AddAsync(Device device);
    Task<Device> FindByIdAsync(int id);
    void Update(Device device);
    void Remove(Device device);
}