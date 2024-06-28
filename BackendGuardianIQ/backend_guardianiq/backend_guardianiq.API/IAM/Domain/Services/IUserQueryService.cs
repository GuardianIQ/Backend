using backend_guardianiq.API.IAM.Domain.Model.Aggregates;
using backend_guardianiq.API.IAM.Domain.Model.Queries;

namespace backend_guardianiq.API.IAM.Domain.Services;

public interface IUserQueryService
{
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    Task<User?> Handle(GetUserByIdQuery query);
}