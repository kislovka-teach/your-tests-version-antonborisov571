using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PassingTrips.Abstractions;
using PassingTrips.Models;
using PassingTrips.Options;
using PassingTrips.Repositories;
using PassingTrips.Services;

namespace PassingTrips.Configurations;

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
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<ITripRepository, TripRepository>();
        return services.AddScoped<IUserRepository, UserRepository>();
    }
    
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IFindTripsByCoordinates, FindTripsByCoordinatesService>();
        services.AddScoped<PasswordHasherService, PasswordHasherService>();
        return services.AddScoped<ILoginHelper, LoginHelperService>();
    }
}