using AspNetCore.Identity.MongoDbCore.Extensions;
using AspNetCore.Identity.MongoDbCore.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System.Data;
using System.Reflection;
using Tomi.Application;
using Tomi.Application.Mappings;
using Tomi.Application.Services.Handlers.Products;
using Tomi.Domain.Entities;
using Tomi.Domain.IRepositories;
using Tomi.Infrastructure;
using Tomi.Infrastructure.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<Tomi.Infrastructure.Contexts.MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddControllers();

var mongoDbSettings = new AspNetCore.Identity.MongoDbCore.Infrastructure.MongoDbSettings();
builder.Configuration.GetSection("MongoDbSettings").Bind(mongoDbSettings);
var mongoIdentityConfiguration = new MongoDbIdentityConfiguration
{
	MongoDbSettings = mongoDbSettings
};
builder.Services.ConfigureMongoDbIdentity<User>(mongoIdentityConfiguration).AddUserManager<UserManager<User>>().AddSignInManager<SignInManager<User>>();
builder.Services.AddSingleton<ISystemClock, SystemClock>();

builder.Services.AddAuthentication(x =>
{
	x.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(IdentityConstants.ApplicationScheme);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationLayer(builder.Configuration);
builder.Services.AddInfrastructureLayer(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
