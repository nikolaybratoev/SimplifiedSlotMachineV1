using AutoMapper;
using SimplifiedSlotMachineV1.Application.Common;
using SimplifiedSlotMachineV1.Domain.Models;
using SimplifiedSlotMachineV1.Domain.Repositories;
using SimplifiedSlotMachineV1.Domain.Services.Interfaces;
using SimplifiedSlotMachineV1.Web.Dtos;

namespace SimplifiedSlotMachineV1.Domain.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public IEnumerable<UserReadDto> GetAllUsers()
    {
        var users = _userRepository.GetAllUsers();

        return _mapper.Map<IEnumerable<UserReadDto>>(users);
    }

    public UserReadDto GetUserById(int id)
    {
        var user = _userRepository.GetUserById(id);

        return _mapper.Map<UserReadDto>(user);
    }

    public UserReadDto CreateUser(UserCreateDto userCreateDto)
    {
        Console.WriteLine(ApplicationMessages.CREATING_USER);
        var userModel = _mapper.Map<User>(userCreateDto);

        try
        {
            _userRepository.CreateUser(userModel);
            _userRepository.SaveChanges();

            Console.WriteLine(ApplicationMessages.CREATED_USER);
            return _mapper.Map<UserReadDto>(userModel);
        }
        catch (Exception exception)
        {
            Console.WriteLine(ApplicationMessages.CANNOT_CREATE_USER);
            throw exception;
        }
    }

    public double GetUserDepositByUserId(int id)
    {
        var deposit = _userRepository.GetUserDepositByUserId(id);

        Console.WriteLine(ApplicationMessages.GET_DEPOSIT);

        return deposit;
    }

    public void UpdateUserDeposit(int id, double deposit)
    {
        Console.WriteLine(ApplicationMessages.UPDATING_DEPOSIT);

        _userRepository.UpdateUserDepositByUserId(id, deposit);
    }
}