

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
            user.Email,
            user.Role,
            token
        );
    }

    public static UserRegisterDto ToRegisterDto(User user)
    {
        return new UserRegisterDto(
            user.FirstName,
            user.LastName,
            user.Email,
            user.Password,
            user.Phone,
            user.Address,
            user.Role
        );
    }

    public static User RegisterDtoToEntity(UserRegisterDto dto)
    {
        return new User(
            firstName: dto.FirstName,
            lastName: dto.LastName,
            email: dto.Email,
            password: dto.Password,
            phone: dto.Phone,
            address: dto.Address,
            role: dto.Role
        );
    }

    public static User UpdateDtoToEntity(UserUpdateDto dto)
    {
        return new User(
            firstName: dto.FirstName,
            lastName: dto.LastName,
            email: dto.Email,
            password: dto.Password,
            phone: dto.Phone,
            address: dto.Address,
            role: dto.Role
        );
    }
    
}