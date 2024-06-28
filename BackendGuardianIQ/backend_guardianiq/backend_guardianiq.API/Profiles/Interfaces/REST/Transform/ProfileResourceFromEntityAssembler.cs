using backend_guardianiq.API.Profiles.Domain.Model.Aggregates;
using backend_guardianiq.API.Profiles.Interfaces.REST.Resources;

namespace backend_guardianiq.API.Profiles.Interfaces.REST.Transform;

public static class ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResourceFromEntity(Profile entity)
    {
        return new ProfileResource(entity.Id, entity.Name, entity.Lastname, entity.Mail, entity.Password);
    }
}