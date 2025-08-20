using System.ComponentModel.DataAnnotations;
using api.Entities.Enuns;

namespace api.DTO;

public class UserRegisterDto
{
    public UserRegisterDto(string firstName, string lastName, string email, string password, string? phone, string? address, UserRole role)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        Phone = phone;
        Address = address;
        Role = role;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    
    [EmailAddress]
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string? Phone { get; private set; }
    public string? Address { get; private set; }
    public UserRole Role { get; private set; }
}