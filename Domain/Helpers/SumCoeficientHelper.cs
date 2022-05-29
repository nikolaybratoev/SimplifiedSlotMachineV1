using SimplifiedSlotMachineV1.Application.Common;
using SimplifiedSlotMachineV1.Domain.Common;

namespace SimplifiedSlotMachineV1.Domain.Helpers;

public static class SumCoeficientHelper
{
    public static decimal SumCoeficient(string element, int numberElements)
    {
        switch(element)
        {
            case SlotMachineSymbols.APPLE_SYMBOL:
                return (numberElements * Coeficients.APPLE_COEFICIENT);
            case SlotMachineSymbols.BANANA_SYMBOL:
                return (numberElements * Coeficients.BANANA_COEFICIENT);
            case SlotMachineSymbols.PINEAPPLE_SYMBOL:
                return (numberElements * Coeficients.PINEAPPLE_COEFICIENT);
            default:
                return (numberElements * Coeficients.WILDCARD_COEFICIENT);
        }
    }
}