using backend_guardianiq.API.Devices.Domain.Models;

namespace backend_guardianiq.API.Devices.Domain.Services;

public interface IDeviceService
{
    Task<IEnumerable<Device>> ListAsync();
    Task<Device> SaveAsync(Device device);
    Task<Device> UpdateAsync(int id, Device device);
    Task<bool> DeleteAsync(int id);
}