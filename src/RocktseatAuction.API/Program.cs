using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RocktseatAuction.API.Contracts;
using RocktseatAuction.API.Filters;
using RocktseatAuction.API.Repositories;
using RocktseatAuction.API.Repositories.DataAccess;
using RocktseatAuction.API.Services;
using RocktseatAuction.API.UseCases.Auctions.GetCurrent;
using RocktseatAuction.API.UseCases.Offers.CreateOffer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.
                      Enter 'Bearer' [space] and then your token in the text input bellow.
                      Example: 'Bearer 1234abcdf'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
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
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

builder.Services.AddDbContext<RocketseatAuctionDbContext>(
    options =>
    {
        options.UseSqlite(@"Data Source=C:\Users\henri\Desktop\RocketseatAuction\leilaoDbNLW.db");
    }
);

builder.Services.AddScoped<AuthenticationUserAttribute>();
builder.Services.AddScoped<CreateOfferUseCase>();
builder.Services.AddScoped<GetCurrentAuctionUseCase>();
builder.Services.AddScoped<ILoggeduser, LoggedUser>();
builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
builder.Services.AddScoped<IOfferRepository, OfferRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
