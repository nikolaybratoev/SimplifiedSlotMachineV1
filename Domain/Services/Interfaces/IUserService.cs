using SimplifiedSlotMachineV1.Web.Dtos;

namespace SimplifiedSlotMachineV1.Domain.Services.Interfaces;

public interface IUserService
{
    public IEnumerable<UserReadDto> GetAllUsers();

    public UserReadDto GetUserById(int id);

    public UserReadDto CreateUser(UserCreateDto userCreateDto);

    public double GetUserDepositByUserId(int id);

    public void UpdateUserDeposit(int id, double deposit);
}