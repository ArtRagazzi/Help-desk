using System.ComponentModel.DataAnnotations;
using api.Entities.Enuns;

namespace api.DTO;

public class UserLoginResponseDto
{
    public UserLoginResponseDto(string email, UserRole role, string token)
    {
        Email = email;
        Role = role;
        Token = token;
    }

   
    public string Email { get; set; }
    public UserRole Role { get; private set; }
    public string Token {get; private set;}
    
}