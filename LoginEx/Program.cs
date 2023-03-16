using Business;
using Microsoft.EntityFrameworkCore;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IUserBusiness, UserBusiness>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IPasswordBusiness, PasswordBusiness>();
builder.Services.AddControllers();
builder.Services.AddDbContext<Entities.Store214087579Context>(options=>options.UseSqlServer("Data Source=SRV2\\PUPILS;Initial Catalog=Store_214087579;Integrated Security=True"));


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
