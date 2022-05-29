using Microsoft.EntityFrameworkCore;
using SimplifiedSlotMachineV1.Domain.Repositories;
using SimplifiedSlotMachineV1.Domain.Services;
using SimplifiedSlotMachineV1.Domain.Services.Interfaces;
using SimplifiedSlotMachineV1.Infrastructure.Contexts;
using SimplifiedSlotMachineV1.Infrastructure.InMemoryDatabase;
using SimplifiedSlotMachineV1.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Adds database contexts
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseInMemoryDatabase("InMemory")
);

// Adds repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Adds services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStakeAmountService, StakeAmountService>();
builder.Services.AddScoped<ISpinSlotMachineService, SpinSlotMachineService>();

builder.Services.AddControllers();

builder.Services.AddAutoMapper(
    AppDomain.CurrentDomain.GetAssemblies()
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

PrepareDatabase.Populate(app);

app.Run();
