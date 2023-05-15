using Business;
using Microsoft.EntityFrameworkCore;
using Repository;
using NLog.Web;
using Microsoft.AspNetCore.Hosting;
using LoginEx;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseNLog();

// Add services to the container.
builder.Services.AddTransient<IUserBusiness, UserBusiness>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ICategoryBusiness, CategoryBusiness>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductBusiness, ProductBusiness>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IOrderBusiness, OrderBusiness>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IPasswordBusiness, PasswordBusiness>();
builder.Services.AddControllers();
builder.Services.AddDbContext<Store214087579Context>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("Store_214087579")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
app.UseErrrorHadlingMiddleware();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == 404)
    {
        await next();
    }
});

app.Run();
