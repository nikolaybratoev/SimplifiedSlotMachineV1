using SimplifiedSlotMachineV1.Domain.Models;

namespace SimplifiedSlotMachineV1.Domain.Repositories;

public interface IUserRepository
{
    public bool SaveChanges();

    public IEnumerable<User> GetAllUsers();

    public User GetUserById(int userId);

    public decimal GetUserDepositByUserId(int userId);

    public void UpdateUserDepositByUserId(int userId, decimal deposit);

    public bool UserExists(int userId);
}