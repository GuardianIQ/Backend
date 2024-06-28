namespace backend_guardianiq.API.Profiles.Domain.Model.Commands;

public record CreateProfileCommand(string Name, string Lastname, string Mail, string Password);