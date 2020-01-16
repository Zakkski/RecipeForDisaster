using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Disaster.API.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace RecipeForDisaster
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
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddCors();
            services.AddDbContext<DataContext>();
            // Single instance can be problematic for concurrent requests
            // services.AddSingleton();
            // Creates a new instance each time it is called, best for lightweight statless services
            // services.AddTransient();
            // Like Singleton but uses same instance for calls in the same http request
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IListItemRepository, ListItemRepository>();
            services.AddScoped<IUserListRepository, UserListRepository>();
            // Authentication scheme that will be used
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                        .AddJwtBearer(options => {
                            options.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuerSigningKey = true,
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                                ValidateIssuer = false,
                                ValidateAudience = false
                            };
                        });            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // something about UseHttpsRedircetion makes this not work as a Cors policy
                // with origins and then you can set the client to use
                app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            }


            // app.UseHttpsRedirection();

            app.UseRouting();
            // Needs to be before authorization, used to implement auth scheme
            // Must send requests with header (Authorization: Bearer jwttoken)
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
