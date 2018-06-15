using System.Text;
using M4Movie.Api.Business;
using M4Movie.Api.Business.Interfaces;
using M4Movie.Api.Contracts;
using M4Movie.Api.Data;
using M4Movie.Api.Data.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace A4Auth
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
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
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
              {
                  builder.AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowAnyOrigin();
              }));
            services.AddTransient<IAuthApiContext, AuthApiContext>();
            services.AddTransient<AuthApiContext>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRepository<User>, Repository<User>>();
            services.AddTransient<IAuthUnitOfWork, AuthUnitOfWork>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddDbContext<AuthApiContext>(options => options.UseSqlServer(Configuration.GetConnectionString("A4AuthConnection")));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            
            app.UseMvc();
        }
    }
}
