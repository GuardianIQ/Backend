namespace backend_guardianiq.API.Profiles.Interfaces.REST.Resources;

public record CreateProfileResource(string Name, string Lastname, string Mail, string Password);