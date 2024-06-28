using backend_guardianiq.API.Profiles.Domain.Model.Commands;

namespace backend_guardianiq.API.Profiles.Domain.Model.Aggregates;

public class Profile
{
    public int Id { get; }
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Mail { get; set; }
    public string Password { get; set; }

    public Profile(string name, string lastname, string mail, string password)
    {
        Name = name;
        Lastname = lastname;
        Mail = mail;
        Password = password;
    }

    public Profile(CreateProfileCommand command)
    {
        this.Name = command.Name;
        this.Lastname = command.Lastname;
        this.Mail = command.Mail;
        this.Password = command.Password;
    }
}