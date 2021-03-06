using SimplifiedSlotMachineV1.Web.Dtos;

namespace SimplifiedSlotMachineV1.Domain.Services.Interfaces;

public interface IUserService
{
    public IEnumerable<UserReadDto> GetAllUsers();

    public UserReadDto GetUserById(int userId);

    public decimal GetUserDepositByUserId(int userId);

    public void UpdateUserDeposit(int userId, decimal deposit);
}