using SimplifiedSlotMachineV1.Domain.Models;
using SimplifiedSlotMachineV1.Domain.Repositories;
using SimplifiedSlotMachineV1.Infrastructure.Contexts;

namespace SimplifiedSlotMachineV1.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public void CreateUser(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        _context.Users.Add(user);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _context.Users.ToList();
    }

    public User GetUserById(int userId)
    {
        return _context.Users.FirstOrDefault(u => u.UserId == userId);
    }

    public double GetUserDepositByUserId(int userId)
    {
        return this.GetUserById(userId).Deposit;
    }

    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }

    public void UpdateUserDepositByUserId(int userId, double deposit)
    {
        var user = _context.Users.First(u => u.UserId == userId);
        user.Deposit += deposit;

        _context.SaveChanges();
    }
}