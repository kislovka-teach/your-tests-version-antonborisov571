using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Freelance.Abstractions;
using Freelance.Models;
using Freelance.Repositories;
using Freelance.Services;

namespace Freelance;

public static class ServiceCollectionExtensions
{
    public static AuthenticationBuilder AddJwtTokens(this IServiceCollection services)
    {
        return services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    
                    ValidateIssuer = true,
                    ValidIssuer = AuthOptions.Issuer,
                    ValidateAudience = true,
                    ValidAudience = AuthOptions.Audience,
                    ValidateLifetime = true,
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                    ValidateIssuerSigningKey = true,
                };
            });
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IFreelancerRepository, FreelancerRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        return services.AddScoped<IUserRepository, UserRepository>();
    }
    
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPasswordHasherService, PasswordHasherService>();
        services.AddScoped<IFreelancerProjectService, FreelancerProjectService>();
        services.AddScoped<IFreelancerService, FreelancerService>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IReviewService, ReviewService>();
        return services.AddScoped<ILoginHelperService, LoginHelperService>();
    }
}