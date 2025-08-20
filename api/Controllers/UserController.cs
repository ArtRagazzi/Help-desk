using api.DTO;
using api.Entities;
using api.Mappers;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;


[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;


    public UserController(IConfiguration configuration, IUserService userService)
    {
        _configuration = configuration;
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
    {
        try
        {
            var user = await _userService.FindByEmailAndPassword(loginDto.Email, loginDto.Password);
            var token = TokenService.GenerateToken(user, _configuration["JwtSettings:SecretKey"]);

            var response = UserMapper.ToLoginResponseDto(user, token);
            return Ok(response);
        }
        catch (Exception e)
        {
            return Unauthorized(new { message = "Credenciais Invalidas" });
        }
    }


    [HttpPost("register")]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto registerDto)
    {
        if (registerDto == null)
        {
            return BadRequest("Dados Invalidos");
        }

        try
        {
            var user = UserMapper.RegisterDtoToEntity(registerDto);
            await _userService.Insert(user);
            
            var result = UserMapper.ToRegisterDto(user);
            return CreatedAtAction(nameof(Register), new{id = user.Id}, result);
        }
        catch (Exception e)
        {
            return StatusCode(500, new { message = $"Erro ao registar usuario: {e.Message}" });
        }
    }
    
}