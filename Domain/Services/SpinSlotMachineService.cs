using SimplifiedSlotMachineV1.Application.Common;
using SimplifiedSlotMachineV1.Domain.Common;
using SimplifiedSlotMachineV1.Domain.Helpers;
using SimplifiedSlotMachineV1.Domain.Repositories;
using SimplifiedSlotMachineV1.Domain.Services.Interfaces;
using SimplifiedSlotMachineV1.Web.Dtos;

namespace SimplifiedSlotMachineV1.Domain.Services;

public class SpinSlotMachineService : ISpinSlotMachineService
{
    private readonly IUserRepository _userRepository;

    public SpinSlotMachineService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public SlotMachineResultReadDto Spin(int userId)
    {
        var user = _userRepository.GetUserById(userId);
        var stake = user.StakeAmount;
        var deposit = user.Deposit;

        if (stake > 0)
        {
            Console.WriteLine(ApplicationMessages.SPINNING_SLOT_MACHINE);
            var generatedResult = GenerateRandomRows();

            var resultDto = GenerateSpinResultReadDto(userId, generatedResult);

            var win = CheckResult(generatedResult);
            var result = win * stake;

            resultDto.Won = Formatter.Format(result);
            deposit += result;
            user.Deposit += result;
            user.StakeAmount = 0;
            resultDto.CurrentBalance = Formatter.Format(deposit);

            _userRepository.SaveChanges();

            return resultDto;
        }
        else
        {
            Console.WriteLine(ApplicationMessages.ENTER_STAKE_AMOUNT);
        }

        return null;
    }

    private string[,] GenerateRandomRows()
    {
        string[,] array = new string[4, 3];

        int uBound0 = array.GetUpperBound(0);
        int uBound1 = array.GetUpperBound(1);

        for (int row = 0; row <= uBound0; row++)
        {
            for (int col = 0; col <= uBound1; col++)
            {
                var random = new Random();
                var game = random.NextInt64(0, 100);

                if (game <= Probability.WILDCARD_PROBABILITY)
                {
                    array[row, col] = SlotMachineSymbols.WILDCARD_SYMBOL;
                    continue;
                }

                if (game <= Probability.PINEAPPLE_PROBABILITY)
                {
                    array[row, col] = SlotMachineSymbols.PINEAPPLE_SYMBOL;
                    continue;
                }

                if (game <= Probability.BANANA_PROBABILITY)
                {
                    array[row, col] = SlotMachineSymbols.BANANA_SYMBOL;
                    continue;
                }

                array[row, col] = SlotMachineSymbols.APPLE_SYMBOL;
            }
        }

        return array;
    }

    private double CheckResult(string[,] generatedResult)
    {
        double win = 0;
        for (int row = 0; row < generatedResult.GetLength(0); row++)
        {
            var firstElement = generatedResult[row, 0];
            var secondElement = generatedResult[row, 1];
            var thirdElement = generatedResult[row, 2];

            var combinedResult = firstElement + secondElement + thirdElement;

            win += WinCalculationHelper.CalculateWin(combinedResult);
        }

        return win;
    }

    private SlotMachineResultReadDto GenerateSpinResultReadDto(int userId, string [,] generatedResult)
    {
        return new SlotMachineResultReadDto
            {
                UserId = userId,
                FirstRow = generatedResult[0, 0] + generatedResult[0, 1] + generatedResult[0, 2],
                SecondRow = generatedResult[1, 0] + generatedResult[1, 1] + generatedResult[1, 2],
                ThirdRow = generatedResult[2, 0] + generatedResult[2, 1] + generatedResult[2, 2],
                FourthRow = generatedResult[3, 0] + generatedResult[3, 1] + generatedResult[3, 2],
            };
    }
}