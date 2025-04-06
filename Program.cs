using Microsoft.EntityFrameworkCore;
using gp2.Data;
using Microsoft.AspNetCore.Builder;
using gp2.Services.Services;
using gp2.Services.Interfaces;
using gp2.Repositories.Interfaces;
using gp2.Repositories;
using gp2.Helpers.AutoMapperProfiles;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FinanceDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddSwaggerGen();

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
