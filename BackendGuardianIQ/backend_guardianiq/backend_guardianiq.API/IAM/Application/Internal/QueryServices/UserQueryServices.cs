using backend_guardianiq.API.IAM.Domain.Model.Aggregates;
using backend_guardianiq.API.IAM.Domain.Model.Queries;
using backend_guardianiq.API.IAM.Domain.Repositories;
using backend_guardianiq.API.IAM.Domain.Services;

namespace backend_guardianiq.API.IAM.Application.Internal.QueryServices;

public class UserQueryServices(IUserRepository userRepository) : IUserQueryService
{
    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.ListAsync();
    }
    
    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.UserId);
    }
}