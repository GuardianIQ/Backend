using backend_guardianiq.API.PersonalSafety.Domain.Models;
using backend_guardianiq.API.PersonalSafety.Domain.Repositories;
using backend_guardianiq.API.PersonalSafety.Domain.Services;
using backend_guardianiq.API.Shared.Domain.Repositories;

namespace backend_guardianiq.API.PersonalSafety.Application.Internal;

public class PersonalSafetyService : IPersonalSafetyService
{
    private readonly IPersonalSafetyRepository _personalsafetyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PersonalSafetyService(IPersonalSafetyRepository personalRepository, IUnitOfWork unitOfWork)
    {
        _personalsafetyRepository = personalRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Personal>> ListAsync()
    {
        return await _personalsafetyRepository.ListAsync();
    }

    public async Task<Personal> SaveAsync(Personal personal)
    {
        try
        {
            await _personalsafetyRepository.AddAsync(personal);
            await _unitOfWork.CompleteAsync();
            return personal;
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while saving the personal: {e.Message}", e);
        }
    }

    public async Task<Personal> UpdateAsync(int id, Personal personal)
    {
        var existingPersonal = await _personalsafetyRepository.FindByIdAsync(id);

        if (existingPersonal == null)
        {
            throw new KeyNotFoundException("Personal not found.");
        }

        existingPersonal.Name = personal.Name;
        existingPersonal.District = personal.District;
        existingPersonal.Age = personal.Age;
        existingPersonal.Sex = personal.Sex;
        existingPersonal.Experience = personal.Experience;
        existingPersonal.Avality = personal.Avality;
        existingPersonal.Contract = personal.Contract;
        existingPersonal.Photo = personal.Photo;

        try
        {
            _personalsafetyRepository.Update(existingPersonal);
            await _unitOfWork.CompleteAsync();
            return existingPersonal;
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while updating the personal: {e.Message}", e);
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existingPersonal = await _personalsafetyRepository.FindByIdAsync(id);

        if (existingPersonal == null)
        {
            throw new KeyNotFoundException("Personal not found.");
        }

        try
        {
            _personalsafetyRepository.Remove(existingPersonal);
            await _unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while deleting the personal: {e.Message}", e);
        }
    }
    public async Task<Personal> FindByIdAsync(int id)
    {
        return await _personalsafetyRepository.FindByIdAsync(id);
    }
}