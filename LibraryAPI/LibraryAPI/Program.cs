using LibraryAPI.Data;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Controllers;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using static System.Net.WebRequestMethods;
using static System.Reflection.Metadata.BlobBuilder;
using System.Security.AccessControl;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.Extensions.Options;
using System.Collections.Concurrent;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LibraryAPI;

public class Program
{
    public static void Main(string[] args)
    {

        

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
       
        builder.Services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationContext"))
        );
        builder.Services.AddIdentity<ApplicationUser,IdentityRole>( options =>
        {
            options.User.RequireUniqueEmail = true;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(7);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = false;
           
        })
            .AddEntityFrameworkStores<ApplicationContext>()
            .AddDefaultTokenProviders();



        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("AllUsers", policy =>
                policy.RequireRole("Admin", "Employee", "Child", "Worker", "Donator", "Member"));
        });
     

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        var configuration = builder.Configuration;

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
      .AddJwtBearer(options =>
      {
          options.SaveToken = true;
          options.RequireHttpsMetadata = false;
          options.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateIssuerSigningKey = true,
              IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"])), // Replace with your secret key
              ValidateIssuer = true,
              ValidateAudience = true,
              ValidateLifetime = true,
              ValidIssuer = configuration["Jwt:Issuer"], // Replace with your issuer
              ValidAudience = configuration["Jwt:Audience"], // Replace with your audience
              RoleClaimType = ClaimTypes.Role,
              ClockSkew = TimeSpan.Zero
          };
      });

        builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT", // Opsiyonel: JWT formatında olduğunu belirtmek için
                Description = "Bearer token format. Enter 'Bearer {token}'"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>() // Buraya gereken rolleri virgülle ayırarak ekleyin, eğer roller gerekiyorsa
        }
    });
        });

        var app = builder.Build();


        app.UseAuthentication();
        app.UseAuthorization();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

            app.MapControllers();
        Task.Run(async () =>
        {
            
            using (var scope = app.Services.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                if (_context.Database.GetPendingMigrations().Any())
                {
                    _context.Database.Migrate();//Auto Migration
                }
                var _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();


                await _context.Database.MigrateAsync();

                // Check and create role if not exists
                var adminRole = await _roleManager.FindByNameAsync("Admin");
                if (adminRole == null)
                {
                    var identityRole = new IdentityRole("Admin");
                    await _roleManager.CreateAsync(identityRole);
                }

                using (var _userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>())
                {
                    var adminUser = await _userManager.FindByNameAsync("Admin");
                    if (adminUser == null)
                    {
                        var applicationUser = new ApplicationUser
                        {
                            UserName = "Admin",
                            Email = "admin@admin",
                            isActive = true
                        };
                        var result = await _userManager.CreateAsync(applicationUser, "Admin123!");
                        if (result.Succeeded)
                        {
                            await _userManager.AddToRoleAsync(applicationUser, "Admin");
                        }
                       
                    }
                }

                // Check and add language if not exists
                var language = await _context.Languages!.FindAsync("tr");
                if (language == null)
                {
                    language = new Language
                    {
                        Code = "tr",
                        Name = "Türkçe"
                    };
                    await _context.Languages.AddAsync(language);
                    await _context.SaveChangesAsync();
                }
            }
        });
        


        app.Run();

    }

}

