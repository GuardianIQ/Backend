using backend_guardianiq.API.Devices.Domain.Models;
using backend_guardianiq.API.Devices.Domain.Repositories;
using backend_guardianiq.API.Devices.Domain.Services;
using backend_guardianiq.API.Shared.Domain.Repositories;

namespace backend_guardianiq.API.Devices.Application.Internal;

public class DeviceService: IDeviceService
{
    private readonly IDeviceRepository _deviceRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeviceService(IDeviceRepository deviceRepository, IUnitOfWork unitOfWork)
    {
        _deviceRepository = deviceRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Device>> ListAsync()
    {
        return await _deviceRepository.ListAsync();
    }

    public async Task<Device> SaveAsync(Device device)
    {
        try
        {
            await _deviceRepository.AddAsync(device);
            await _unitOfWork.CompleteAsync();
            return device;
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while saving the device: {e.Message}", e);
        }
    }

    public async Task<Device> UpdateAsync(int id, Device device)
    {
        var existingDevice = await _deviceRepository.FindByIdAsync(id);

        if (existingDevice == null)
        {
            throw new KeyNotFoundException("Device not found.");
        }

        existingDevice.Type = device.Type;
        existingDevice.Brand = device.Brand;
        existingDevice.Model = device.Model;
        existingDevice.Ubication = device.Ubication;
        existingDevice.Imagen = device.Imagen;

        try
        {
            _deviceRepository.Update(existingDevice);
            await _unitOfWork.CompleteAsync();
            return existingDevice;
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while updating the device: {e.Message}", e);
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existingDevice = await _deviceRepository.FindByIdAsync(id);

        if (existingDevice == null)
        {
            throw new KeyNotFoundException("Device not found.");
        }

        try
        {
            _deviceRepository.Remove(existingDevice);
            await _unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while deleting the device: {e.Message}", e);
        }
    }
}