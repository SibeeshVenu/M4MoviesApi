using M4Movie.Api.Business;
using M4Movie.Api.Business.Interfaces;
using M4Movie.Api.Contracts;
using M4Movie.Api.Data;
using M4Movie.Api.Data.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace M4Movie_Api
{
    public static class ConfigureServices
    {
        public static void ConfigureService(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddCors(cors => cors.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
            }));

            services.AddTransient<IRepository<Movie>, Repository<Movie>>();
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IMovieApiContext, MovieApiContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<MovieApiContext>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["TokenIssuer"],
                    ValidAudience = Configuration["TokenAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SignInKey"]))
                };
            });
        }
    }
}
