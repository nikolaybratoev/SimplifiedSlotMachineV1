using SimplifiedSlotMachineV1.Web.Dtos;

namespace SimplifiedSlotMachineV1.Domain.Services.Interfaces;

public interface ISpinSlotMachineService
{
    public SlotMachineResultReadDto Spin(int userId);
}