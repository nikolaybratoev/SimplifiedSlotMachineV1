using SimplifiedSlotMachineV1.Web.Dtos;

namespace SimplifiedSlotMachineV1.Domain.Services.Interfaces;

public interface IStakeAmountService
{
    public StakeAmountReadDto GetUserStakeAmountByUserId(int id);

    public StakeAmountReadDto EnterUserStakeAmountByUserId(int id, double stake);
}