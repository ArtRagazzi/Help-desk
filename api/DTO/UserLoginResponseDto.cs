using System.ComponentModel.DataAnnotations;
using api.Entities.Enuns;

namespace api.DTO;

public class UserLoginResponseDto
{
    public UserLoginResponseDto(string firstName, string lastName, string email, string? phone, string? address, UserRole role, string token)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        Address = address;
        Role = role;
        Token = token;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; set; }
    public string? Phone { get; private set; }
    public string? Address { get; private set; }
    public UserRole Role { get; private set; }
    public string Token {get; private set;}
    
}