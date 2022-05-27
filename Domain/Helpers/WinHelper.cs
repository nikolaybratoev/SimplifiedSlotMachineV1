using SimplifiedSlotMachineV1.Domain.Common;

namespace SimplifiedSlotMachineV1.Domain.Helpers;

public static class WinHelper
{
    public static double CalculateWin(string combinedResult)
    {
        switch(combinedResult) 
        {
            case "AAA":
                return 3 * Coeficients.APPLE_COEFICIENT;
            case "AA*":
            case "A*A":
            case "*AA":
                return 2 * Coeficients.APPLE_COEFICIENT;
            case "A**":
            case "*A*":
            case "**A":
                return 1 * Coeficients.APPLE_COEFICIENT;
            case "BBB":
                return 3 * Coeficients.BANANA_COEFICIENT;
            case "BB*":
            case "B*B":
            case "*BB":
                return 2 * Coeficients.BANANA_COEFICIENT;
            case "B**":
            case "*B*":
            case "**B":
                return 1 * Coeficients.BANANA_COEFICIENT;
            case "PPP":
                return 3 * Coeficients.PINEAPPLE_COEFICIENT;
            case "PP*":
            case "P*P":
            case "*PP":
                return 2 * Coeficients.PINEAPPLE_COEFICIENT;
            case "P**":
            case "*P*":
            case "**P":
                return 1 * Coeficients.PINEAPPLE_COEFICIENT;
            default:
                return 0;
        }
    }
}