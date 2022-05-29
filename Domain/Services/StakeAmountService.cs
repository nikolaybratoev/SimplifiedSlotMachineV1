using AutoMapper;
using SimplifiedSlotMachineV1.Application.Common;
using SimplifiedSlotMachineV1.Domain.Repositories;
using SimplifiedSlotMachineV1.Domain.Services.Interfaces;
using SimplifiedSlotMachineV1.Web.Dtos;

namespace SimplifiedSlotMachineV1.Domain.Services;

public class StakeAmountService : IStakeAmountService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public StakeAmountService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public StakeAmountReadDto GetUserStakeAmountByUserId(int userId)
    {
        var userModel = _userRepository.GetUserById(userId);

        return _mapper.Map<StakeAmountReadDto>(userModel);
    }

    public StakeAmountReadDto EnterUserStakeAmountByUserId(int userId, decimal stakeAmount)
    {
        Console.WriteLine(ApplicationMessages.GET_DEPOSIT);
        var userModel = _userRepository.GetUserById(userId);

        if (userModel.Deposit > 0)
        {
            Console.WriteLine(ApplicationMessages.DEPOSIT_ENOUGH);

            userModel.Deposit -= stakeAmount;
            userModel.StakeAmount = stakeAmount;
            _userRepository.SaveChanges();

            return _mapper.Map<StakeAmountReadDto>(userModel);
        }

        Console.WriteLine(ApplicationMessages.DEPOSIT_NOT_ENOUGH);
        return null;
    }
}