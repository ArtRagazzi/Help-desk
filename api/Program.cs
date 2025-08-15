using api.Context;
using api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder);



var app = builder.Build();

app.Run();





void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddCors(options=>{
        options.AddPolicy("PermitirFrontend",policy=>{
            policy.WithOrigins("http://localhost:5173","http://localhost:5174")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });
    
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
    
    builder.Services.AddScoped<IUserService, UserService>();
    
    builder.Services.AddControllers();
}