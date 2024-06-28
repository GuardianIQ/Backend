using backend_guardianiq.API.ActiveService.Domain.Repositories;
using backend_guardianiq.API.ActiveService.Infrastructure.Persistence.EFC.Repositories;
using backend_guardianiq.API.Shared.Domain.Repositories;
using backend_guardianiq.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend_guardianiq.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using backend_guardianiq.API.ActiveService.Application.Internal;
using backend_guardianiq.API.ActiveService.Domain.Services;
using backend_guardianiq.API.Devices.Application.Internal;
using backend_guardianiq.API.Devices.Domain.Repositories;
using backend_guardianiq.API.Devices.Domain.Services;
using backend_guardianiq.API.Devices.Infrastructure.Persistence.EFC.Repositories;
using backend_guardianiq.API.Devices.Interfaces.REST.Repositories;
using backend_guardianiq.API.PersonalSafety.Application.Internal;
using backend_guardianiq.API.PersonalSafety.Domain.Repositories;
using backend_guardianiq.API.PersonalSafety.Domain.Services;
using backend_guardianiq.API.PersonalSafety.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
   options =>
   {
       if (connectionString != null)
       {
           if (builder.Environment.IsDevelopment())
           {
               options.UseMySQL(connectionString)
                   .LogTo(Console.WriteLine, LogLevel.Information)
                   .EnableSensitiveDataLogging()
                   .EnableDetailedErrors();
           }
           else if (builder.Environment.IsProduction())
           {
               options.UseMySQL(connectionString)
                   .LogTo(Console.WriteLine, LogLevel.Error)
                   .EnableDetailedErrors();
           }
       }
   });

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddScoped<ServiceService>();
builder.Services.AddScoped<DeviceService>();
builder.Services.AddScoped<PersonalSafetyService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<IPersonalSafetyRepository, PersonalSafetyRepository>();
builder.Services.AddScoped<IPersonalSafetyService, PersonalSafetyService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
