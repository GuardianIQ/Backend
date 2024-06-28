using backend_guardianiq.API.IAM.Domain.Model.Commands;

namespace backend_guardianiq.API.IAM.Domain.Services;

public interface IUserCommandService
{
    Task Handle(SignUpCommand command);
    Task Handle(SignInCommand command);
}