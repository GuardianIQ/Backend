using backend_guardianiq.API.IAM.Domain.Model.Aggregates;
using backend_guardianiq.API.IAM.Domain.Model.Commands;
using backend_guardianiq.API.IAM.Domain.Repositories;
using backend_guardianiq.API.IAM.Domain.Services;
using backend_guardianiq.API.Shared.Domain.Repositories;

namespace backend_guardianiq.API.IAM.Application.Internal.CommandServices;

public class UserCommandService(IUserRepository userRepository, IUnitOfWork unitOfWork) : IUserCommandService
{
    public async Task<User?> Handle(SignInCommand command)
    {
        var user = new User(command);
        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
            return user;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the user: {e.Message}");
            return null;
        }
    }
    
    public async Task<User?> Handle(SignUpCommand command)
    {
        var user = new User(command);
        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
            return user;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the user: {e.Message}");
            return null;
        }
    }
}