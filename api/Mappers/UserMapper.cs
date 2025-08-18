

using api.DTO;
using api.Entities;

namespace api.Mappers;

public static class UserMapper
{
    public static UserLoginDto ToLoginDto(User user)
    {
        return new UserLoginDto
        {
            Email = user.Email,
            Password = user.Password
        };
    }

    public static UserLoginResponseDto ToLoginResponseDto(User user, string token)
    {
        return new UserLoginResponseDto(
            user.FirstName,
            user.LastName,
            user.Email,
            user.Phone,
            user.Address,
            user.Role,
            token
        );
    }
    
}