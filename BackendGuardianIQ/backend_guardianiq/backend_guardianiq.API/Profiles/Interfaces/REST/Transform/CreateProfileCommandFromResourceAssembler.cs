using backend_guardianiq.API.Profiles.Domain.Model.Commands;
using backend_guardianiq.API.Profiles.Interfaces.REST.Resources;

namespace backend_guardianiq.API.Profiles.Interfaces.REST.Transform;

public static class CreateProfileCommandFromResourceAssembler
{
    public static CreateProfileCommand ToCommandFromResource(CreateProfileResource resource)
    {
        return new CreateProfileCommand(resource.Name, resource.Lastname, resource.Mail, resource.Password);
    }
}