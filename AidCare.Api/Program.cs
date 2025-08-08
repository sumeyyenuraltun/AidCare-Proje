using AidCare.API.Filters;
using AidCare.Business.Abstract;
using AidCare.Business.Concrete;
using AidCare.Business.Concrete.Mapping;
using AidCare.DataAccess.Abtract;
using AidCare.DataAccess.Concrete.Context;
using AidCare.DataAccess1.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddDbContext<AidCareDbContext>(option=>option.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IUserDAL, UserRepository>();

builder.Services.AddAutoMapper(typeof(MapProfile).Assembly);
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
});


builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
