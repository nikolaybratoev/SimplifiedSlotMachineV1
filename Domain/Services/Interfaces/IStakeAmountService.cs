using SimplifiedSlotMachineV1.Web.Dtos;

namespace SimplifiedSlotMachineV1.Domain.Services.Interfaces;

public interface IStakeAmountService
{
    public StakeAmountReadDto GetUserStakeAmountByUserId(int userId);

    public StakeAmountReadDto EnterUserStakeAmountByUserId(int userId, double stakeAmount);
}