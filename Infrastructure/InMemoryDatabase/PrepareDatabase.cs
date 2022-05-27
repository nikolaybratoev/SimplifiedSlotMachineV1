using SimplifiedSlotMachineV1.Application.Common;
using SimplifiedSlotMachineV1.Domain.Models;
using SimplifiedSlotMachineV1.Infrastructure.Contexts;

namespace SimplifiedSlotMachineV1.Infrastructure.InMemoryDatabase;

public static class PrepareDatabase
{
    public static void Populate(IApplicationBuilder application)
    {
        using (var serviceScope = application.ApplicationServices.CreateScope())
        {
            SeedDatabase(serviceScope.ServiceProvider.GetService<AppDbContext>());
        }
    }

    private static void SeedDatabase(AppDbContext context)
    {
        if (!context.Users.Any())
        {
            Console.WriteLine(ApplicationMessages.SEEDING_DATA);

            context.Users.AddRange(
                new User
                {
                    Name = "Peter",
                    Deposit = 100,
                    StakeAmount = 10
                },
                new User
                {
                    Name = "Alex",
                    Deposit = 300,
                    StakeAmount = 20
                },
                new User
                {
                    Name = "Pavel",
                    Deposit = 500,
                    StakeAmount = 0
                }
            );

            context.SaveChanges();
        }
        else
        {
            Console.WriteLine(ApplicationMessages.ALREADY_SEEDED);
        }
    }
}