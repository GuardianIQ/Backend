using backend_guardianiq.API.IAM.Domain.Model.Aggregates;
using backend_guardianiq.API.IAM.Domain.Model.Commands;

namespace backend_guardianiq.API.IAM.Domain.Services;

public interface IUserCommandService
{
    Task<User?> Handle(SignInCommand command);
    Task<User?> Handle(SignUpCommand command);

}