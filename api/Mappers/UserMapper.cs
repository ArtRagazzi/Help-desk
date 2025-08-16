using api.DTO;
using api.Entities;

namespace api.Mappers;

public static class UserMapper
{
    public static UserLoginDto toDto(User user)
    {
        return new UserLoginDto
        {
            Email = user.Email,
            Password = user.Password
        };
    }
    
}