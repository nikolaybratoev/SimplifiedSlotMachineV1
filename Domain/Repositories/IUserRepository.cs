using SimplifiedSlotMachineV1.Domain.Models;

namespace SimplifiedSlotMachineV1.Domain.Repositories;

public interface IUserRepository
{
    bool SaveChanges();

    IEnumerable<User> GetAllUsers();

    User GetUserById(int userId);

    void CreateUser(User user);

    double GetUserDepositByUserId(int userId);

    void UpdateUserDepositByUserId(int userId, double deposit);
}