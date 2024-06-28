using backend_guardianiq.API.IAM.Domain.Model.Commands;
using Microsoft.AspNetCore.Mvc;

namespace backend_guardianiq.API.IAM.Domain.Model.Aggregates;

public class User
{
    public int Id { get; }
    public string Mail { get; set; }
    public string Password { get; set; }
    
    public User(string mail, string password)
    {
        Mail = mail;
        Password = password;
    }

    public User(SignInCommand command)
    {
        this.Mail = command.Mail;
        this.Password = command.Password;
    }
    
    public User(SignUpCommand command)
    {
        this.Mail = command.Mail;
        this.Password = command.Password;
    }
}