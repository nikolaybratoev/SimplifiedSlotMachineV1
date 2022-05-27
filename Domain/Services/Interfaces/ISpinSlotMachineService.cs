using SimplifiedSlotMachineV1.Web.Dtos;

namespace SimplifiedSlotMachineV1.Domain.Services.Interfaces;

public interface ISpinSlotMachineService
{
    public SlotMachineResultReadDto Roll(int id);
}